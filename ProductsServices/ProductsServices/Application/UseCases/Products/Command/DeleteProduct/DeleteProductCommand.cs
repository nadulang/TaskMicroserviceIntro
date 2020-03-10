using MediatR;
using ProductsServices.Application.Models.Query;
using ProductsServices.Domain.Entities;

namespace ProductsServices.Application.UseCases.Products.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest<BaseDto<Products_>>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
