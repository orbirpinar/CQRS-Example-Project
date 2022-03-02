using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCargo.Api.Data;
using EasyCargo.Api.Domains;
using EasyCargo.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace EasyCargo.Api.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AttachAsync(Guid orderId, Product product)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) throw new BadHttpRequestException("Entity Not Found");
            order.Products = new List<Product>();
            order.Products.Add(product);
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order.Products.Last();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}