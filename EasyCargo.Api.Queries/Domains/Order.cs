using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;

namespace EasyCargo.Api.Queries.Domains
{
    public class Order: Entity
    {
        
        public int ShippingProvider { get; set; }
        public bool IsShipped { get; set; }
        public string? CargoKey { get; set; }
        public Many<Product>? Products { get; set; }

        public Order() => this.InitOneToMany(() => Products);
    }
}