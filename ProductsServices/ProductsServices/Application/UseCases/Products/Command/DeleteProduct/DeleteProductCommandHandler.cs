using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using MediatR;
using ProductsServices.Infrastructure.Persistences;
using ProductsServices.Application.Models.Query;
using ProductsServices.Domain.Entities;


namespace ProductsServices.Application.UseCases.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, BaseDto<Products_>>
    {
        private readonly ProductContext _context;

        public DeleteProductCommandHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Products_>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.ProductsData.FindAsync(request.Id);

            if (delete == null)
            {
                return new BaseDto<Products_>
                {
                    Status = false,
                    Message = "Not Found"
                };
            }

            else
            {
                _context.ProductsData.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<Products_>
                {
                    Status = true,
                    Message = "Successfully retrieved customer"
                };

            }

        }
    }
}
