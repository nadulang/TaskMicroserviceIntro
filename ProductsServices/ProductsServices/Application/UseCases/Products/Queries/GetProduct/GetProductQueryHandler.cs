using MediatR;
using System.Threading.Tasks;
using System.Threading;
using ProductsServices.Application.Models.Query;
using ProductsServices.Infrastructure.Persistences;
using ProductsServices.Domain.Entities;

namespace ProductsServices.Application.UseCases.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, BaseDto<Products_>>
    {
        private readonly ProductContext _context;

        public GetProductQueryHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Products_>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.ProductsData.FindAsync(request.Id);
            if (result == null)
            {
                return null;
            }
            else
            {
                return new BaseDto<Products_>
                {
                    Status = true,
                    Message = "Product succesfully retrieved",
                    Data = result
                };
            }
        }
    }
}
