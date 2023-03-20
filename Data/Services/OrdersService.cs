using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public class OrdersService : IOrdersService
    {
        //implement dependency injection of the database
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByIdAsync(string userId)
        {
            var orders = await  _context.Order.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Where(n => n.UserId == userId).ToListAsync();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string emailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = emailAddress
            };

            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItems = new OrderItem()
                {
                    Amount = item.Amount,
                    Price = item.Movie.Price,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id
                };

                await _context.OrderItems.AddAsync(orderItems);
            }
            await _context.SaveChangesAsync();
        }
    }
}
