using System;

namespace EasyCargo.Api.Domains
{
    public class Product
    {
        public Guid Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public int Deci { get; set; }
        public int Qty { get; set; }

        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
    }
}