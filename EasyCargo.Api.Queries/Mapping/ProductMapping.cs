using System.Collections.Generic;
using System.Linq;
using EasyCargo.Api.Queries.Domains;
using Shared.Model;

namespace EasyCargo.Api.Queries.Mapping
{
    public static class ProductMapping
    {
        public static ProductResponse DomainToResponse(this Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Deci = product.Deci,
                Depth = product.Depth,
                Height = product.Height,
                Qty = product.Qty,
                Width = product.Width
            };
        }
        
        public static List<ProductResponse> DomainToResponse(IEnumerable<Product>? products)
        {
            return products.Select(product => product.DomainToResponse()).ToList();
        }
        
        public static Product ResponseToDomain(this ProductResponse product)
        {
            return new Product
            {
                Id= product.Id,
                Deci = product.Deci,
                Depth = product.Depth,
                Height = product.Height,
                Qty = product.Qty,
                Width = product.Width
            };
        }

        public static IEnumerable<Product> ResponseToDomain(IEnumerable<ProductResponse> responses)
        {
            return responses.Select(response => response.ResponseToDomain()).ToList();
        }
    }
}