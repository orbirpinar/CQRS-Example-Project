using System;

namespace EasyCargo.Api.Queries.Responses
{
    public class ProductResponse
    {
        
        public string Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public int Deci { get; set; }
        public int Qty { get; set; }
    }
}