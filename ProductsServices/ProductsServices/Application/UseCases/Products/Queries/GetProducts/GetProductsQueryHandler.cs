using MediatR;
using System.Threading.Tasks;
using System.Threading;
using ProductsServices.Application.Models.Query;
using ProductsServices.Infrastructure.Persistences;
using ProductsServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace ProductsServices.Application.UseCases.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, BaseDto<List<Products_>>>
    {
        private readonly ProductContext _context;

        public GetProductsQueryHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<List<Products_>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.ProductsData.ToListAsync();

            var result = data.Select(e => new Products_
            {
                id = e.id,
                merchant_id = e.merchant_id,
                name = e.name,
                price = e.price,
                created_at = e.created_at,
                updated_at = e.updated_at
            });

            return new BaseDto<List<Products_>>
            {
                Message = "Success retrieving data",
                Status = true,
                Data = result.ToList()
            };
        }
    }
}
