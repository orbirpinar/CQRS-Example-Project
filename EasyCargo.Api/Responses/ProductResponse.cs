using System;

namespace EasyCargo.Api.Responses
{
    public class ProductResponse
    {
        
        public Guid Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; } 
        public float Depth { get; set; }
        public int Deci { get; set; }
        public int Qty { get; set; }
    }
}