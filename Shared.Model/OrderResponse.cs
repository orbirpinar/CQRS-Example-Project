using System;
using System.Collections.Generic;

namespace Shared.Model
{
    public class OrderResponse
    {
        
        public Guid Id { get; set; }
        public int ShippingProvider { get; set; }
        public bool IsShipped { get; set; }
        public string? CargoKey { get; set; }
        public IEnumerable<ProductResponse>? Products { get; set; }
    }
}