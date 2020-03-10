using MediatR;
using System.Threading.Tasks;
using System.Threading;
using MerchantsServices.Application.Models.Query;
using MerchantsServices.Infrastructure.Persistences;
using MerchantsServices.Domain.Entities;

namespace MerchantsServices.Application.UseCases.Merchants.Queries.GetMerchant
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantQuery, BaseDto<Merchants_>>
    {
        private readonly MerchantContext _context;

        public GetMerchantQueryHandler(MerchantContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Merchants_>> Handle(GetMerchantQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.MerchantsData.FindAsync(request.Id);
            if (result == null)
            {
                return null;
            }
            else
            {
                return new BaseDto<Merchants_>
                {
                    Status = true,
                    Message = "Merchant succesfully retrieved",
                    Data = result
                };
            }
        }
    }
}
