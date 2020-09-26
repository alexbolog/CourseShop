using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using CourseShop.Core.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CourseContext courseContext;
        private readonly ICourseRepository courseRepository;

        public OrderRepository(CourseContext courseContext, ICourseRepository courseRepository)
        {
            this.courseContext = courseContext;
            this.courseRepository = courseRepository;
        }

        public async Task AddNewOrder(string userId, List<Course> courses)
        {
            var order = new Order
            {
                AppUserId = userId,
                InsertedDate = DateTime.UtcNow,
                OrderStatus = Entities.Enums.OrderStatus.New,
                TotalPrice = courses.Sum(c => c.Price)
            };
            courseContext.Orders.Add(order);
            await courseContext.SaveChangesAsync();

            var coursesInOrder = courses.Select(c => new CoursesInOrder
            {
                CourseId = c.CourseId,
                OrderId = order.OrderId
            });
            courseContext.CoursesInOrder.AddRange(coursesInOrder);

            await courseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetNotCompletedOrdersAsync()
        {
            var orders = await courseContext
                .Orders
                .Where(o => o.OrderStatusId != (int)OrderStatus.Completed)
                .ToListAsync();
            foreach(var order in orders)
            {
                order.Courses = await courseRepository.GetCoursesByOrderIdAsync(order.OrderId);
            }
            return orders;
        }

        public async Task<IEnumerable<Order>> GetUsersOrdersAsync(string userId)
        {
            return await courseContext.Orders.Where(o => o.AppUserId == userId).ToListAsync();
        }

        public async Task UpdateStatusAsync(int orderId, int orderStatusIdTo)
        {
            var dbOrder = await courseContext.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            dbOrder.OrderStatusId = orderStatusIdTo;
            await courseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetPurchasedCoursesAsync(string userId)
        {
            return await
                courseContext.Courses
                .Join(courseContext.CoursesInOrder, c => c.CourseId, m => m.CourseId, (course, map) => new { course, map.OrderId })
                .Join(courseContext.Orders, o => o.OrderId, orders => orders.OrderId, (obj, o) => new { obj.course, order = o })
                .Where(o => o.order.AppUserId == userId && o.order.OrderStatusId == (int)OrderStatus.Completed)
                .Select(o => o.course)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> IsCoursePurchasedAsync(int courseId, string userId)
        {
            return await
                courseContext.Orders
                .Where(o => o.AppUserId == userId && o.OrderStatusId == (int)OrderStatus.Completed)
                .Join(courseContext.CoursesInOrder, o => o.OrderId, map => map.OrderId, (orders, map) => map)
                .AnyAsync(m => m.CourseId == courseId);
        }
    }
}
