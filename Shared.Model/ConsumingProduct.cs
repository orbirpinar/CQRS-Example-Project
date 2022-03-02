using System;

namespace Shared.Model
{
    public class ConsumingProduct
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public int Deci { get; set; }
        public int Qty { get; set; }
    }
}