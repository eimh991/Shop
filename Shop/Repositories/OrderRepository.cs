﻿using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Interfaces;
using Shop.Model;

namespace Shop.Repositories
{
    public class OrderRepository : IRepositoryWithUser<Order>
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(int userId, Order entity)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user != null)
            {
                user.Orders.Add(entity);
                await _context.SaveChangesAsync();
            }

        }

        public Task AddRange(int userId, List<Order> entitys)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int entityId)
        {
            await _context.Orders
                .Where(o=>o.OrderId == entityId)
                .ExecuteDeleteAsync();
        }

        public  async Task<IEnumerable<Order>> GetAllAsync(int userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user != null)
            {
                return user.Orders;
            }
            return Enumerable.Empty<Order>();
        }

        public async Task<Order> GetByIdAsync(int userId, int entityId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user != null)
            {
                return user.Orders
                    .FirstOrDefault(o=>o.OrderId == entityId)
                    ?? throw new Exception(message: "Заказ который вы ищите не существует");
            }
            return null;
        }

        public Task Update(int userId, Order entity)
        {
            throw new NotImplementedException();
        }
    }
}