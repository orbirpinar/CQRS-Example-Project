using System.Collections.Generic;

namespace EasyCargo.Api.Requests
{
    public class CreateOrderRequest
    {
        public string CargoKey { get; set; }
        public int ShippingProvider { get; set; }
        public bool IsShipped { get; set; }
        public ICollection<CreateProductRequest> Products { get; set; }
    }
}