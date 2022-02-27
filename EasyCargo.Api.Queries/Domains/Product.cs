using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;

namespace EasyCargo.Api.Queries.Domains
{
    public class Product : Entity
    {
        
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public int Deci { get; set; }
        public int Qty { get; set; }
        public One<Order>? Order { get; set; }
    }
}