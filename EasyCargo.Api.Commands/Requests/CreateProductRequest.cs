namespace EasyCargo.Api.Requests
{
    public class CreateProductRequest
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public int Deci { get; set; }
        public int Qty { get; set; }
    }
}