using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System;
using ProductsServices.Application.Models.Query;
using ProductsServices.Infrastructure.Persistences;
using ProductsServices.Domain.Entities;

namespace ProductsServices.Application.UseCases.Products.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<BaseRequest<Products_>, BaseDto<Products_>>
    {
        private readonly ProductContext _context;

        public CreateProductHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Products_>> Handle(BaseRequest<Products_> request, CancellationToken cancellationToken)
        {
            var req = request.data.attributes;
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            
            var merch = new Domain.Entities.Products_
            {
                merchant_id = req.merchant_id,
                name = req.name,
                price = req.price,
                created_at = (long)time,
                updated_at = (long)time
            };

            _context.ProductsData.Add(merch);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseDto<Products_>
            {
                Message = "Success add product data",
                Status = true,
                Data = req
            };
        }
    }
}
