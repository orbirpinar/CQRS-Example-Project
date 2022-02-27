using System;
using System.Collections.Generic;

namespace EasyCargo.Api.Queries.Responses
{
    public class OrderResponse
    {
        
        public string Id { get; set; }
        public int ShippingProvider { get; set; }
        public bool IsShipped { get; set; }
        public string? CargoKey { get; set; }
        public List<ProductResponse>? Products { get; set; }
    }
} 