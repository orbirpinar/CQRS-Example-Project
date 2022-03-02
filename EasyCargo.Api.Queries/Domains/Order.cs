using System;
using System.Collections.Generic;

namespace EasyCargo.Api.Queries.Domains
{
    public class Order
    {
        public Guid Id { get; set; }
        public int ShippingProvider { get; set; }
        public bool IsShipped { get; set; }
        public string? CargoKey { get; set; }
        public IEnumerable<Product>? Products { get; set; }

    }
}