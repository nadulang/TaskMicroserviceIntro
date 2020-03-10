using MediatR;
using ProductsServices.Application.Models.Query;
using ProductsServices.Domain.Entities;

namespace ProductsServices.Application.UseCases.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<BaseDto<Products_>>
    {
        public int Id { get; set; }

        public GetProductQuery(int id)
        {
            Id = id;
        }
    }
}
