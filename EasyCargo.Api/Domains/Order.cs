using System;
using System.Collections;
using System.Collections.Generic;

namespace EasyCargo.Api.Domains
{
    public class Order
    {
        public Guid Id { get; set; }
        public int ShippingProvider { get; set; }
        public bool IsShipped { get; set; }
        public string? CargoKey { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}