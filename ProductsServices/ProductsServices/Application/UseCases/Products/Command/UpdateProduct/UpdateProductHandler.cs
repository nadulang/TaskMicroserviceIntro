using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductsServices.Application.Models.Query;
using ProductsServices.Infrastructure.Persistences;
using ProductsServices.Domain.Entities;
using System;

namespace ProductsServices.Application.UseCases.Products.Command.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, BaseDto<Products_>>
    {
        private readonly ProductContext _context;

        public UpdateProductHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Products_>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var merch = _context.ProductsData.Find(request.id);
            merch.merchant_id = request.data.attributes.merchant_id;
            merch.name = request.data.attributes.name;
            merch.price = request.data.attributes.price;
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            merch.updated_at = (long)time;

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseDto<Products_>
            {
                Status = true,
                Message = "Customer successfully updated",
            };
        }
    }
}
