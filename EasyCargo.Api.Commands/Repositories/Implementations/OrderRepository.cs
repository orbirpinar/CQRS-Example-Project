using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCargo.Api.Data;
using EasyCargo.Api.Domains;
using EasyCargo.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyCargo.Api.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        private bool _disposed;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> FindAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Products)
                .ToListAsync();
        }

        public async Task<Order?> FindByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.Products)
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Order?> CreateAsync(Order order)
        {
            var response = await _context.Orders.AddAsync(order);
            return response.Entity;
        }

        public async Task<bool> UpdateAsync(Order order, Guid id)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null) return false;
            existingOrder.CargoKey = order.CargoKey;
            existingOrder.IsShipped = order.IsShipped;
            existingOrder.ShippingProvider = order.ShippingProvider;
            _context.Update(existingOrder);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;
            _context.Orders.Remove(order);
            return true;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}