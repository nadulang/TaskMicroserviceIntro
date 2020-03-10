using MediatR;
using System.Threading.Tasks;
using System.Threading;
using MerchantsServices.Application.Models.Query;
using MerchantsServices.Infrastructure.Persistences;
using MerchantsServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace MerchantsServices.Application.UseCases.Merchants.Queries.GetMerchants
{
    public class GetMerchantsQueryHandler : IRequestHandler<GetMerchantsQuery, BaseDto<List<Merchants_>>>
    {
        private readonly MerchantContext _context;

        public GetMerchantsQueryHandler(MerchantContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<List<Merchants_>>> Handle(GetMerchantsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.MerchantsData.ToListAsync();

            var result = data.Select(e => new Merchants_
            {
                id = e.id,
                name = e.name,
                image = e.image,
                address = e.address,
                rating = e.rating,
                created_at = e.created_at,
                updated_at = e.updated_at
            });

            return new BaseDto<List<Merchants_>>
            {
                Message = "Success retrieving data",
                Status = true,
                Data = result.ToList()
            };
        }
    }
}
