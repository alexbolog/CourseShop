using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.Services
{
    public interface IOrderService
    {
        Task AddNewOrderAsync(string userId, List<Course> courses);
        Task<IEnumerable<Order>> GetNotCompletedOrdersAsync();
        Task UpdateStatusAsync(int orderId, int orderStatusIdTo);
        Task<IEnumerable<Order>> GetAllOrdersForUserAsync(string userId);
        Task<IEnumerable<Course>> GetPurchasedCoursesAsync(string userId);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task AddNewOrderAsync(string userId, List<Course> courses)
        {
            await orderRepository.AddNewOrder(userId, courses);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersForUserAsync(string userId)
        {
            return await orderRepository.GetUsersOrdersAsync(userId);
        }

        public async Task<IEnumerable<Order>> GetNotCompletedOrdersAsync()
        {
            return await orderRepository.GetNotCompletedOrdersAsync();
        }

        public async Task UpdateStatusAsync(int orderId, int orderStatusIdTo)
        {
            await orderRepository.UpdateStatusAsync(orderId, orderStatusIdTo);
        }

        public async Task<IEnumerable<Course>> GetPurchasedCoursesAsync(string userId)
        {
            return await orderRepository.GetPurchasedCoursesAsync(userId);
        }
    }
}
