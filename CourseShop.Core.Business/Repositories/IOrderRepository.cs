using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.Repositories
{
    public interface IOrderRepository
    {
        Task AddNewOrder(string userId, List<Course> courses);
        Task<IEnumerable<Order>> GetNotCompletedOrdersAsync();
        Task UpdateStatusAsync(int orderId, int orderStatusIdTo);
        Task<IEnumerable<Order>> GetUsersOrdersAsync(string userId);
        Task<IEnumerable<Course>> GetPurchasedCoursesAsync(string userId);
        Task<bool> IsCoursePurchasedAsync(int courseId, string userId);
    }
}
