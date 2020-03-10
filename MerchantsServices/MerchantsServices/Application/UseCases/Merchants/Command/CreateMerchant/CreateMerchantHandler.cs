using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchantsServices.Application.Models.Query;
using MerchantsServices.Infrastructure.Persistences;
using MerchantsServices.Domain.Entities;
using System;

namespace MerchantsServices.Application.UseCases.Merchants.Command.CreateMerchant
{
    public class CreateMerchantHandler : IRequestHandler<BaseRequest<Merchants_>, BaseDto<Merchants_>>
    {
        private readonly MerchantContext _context;

        public CreateMerchantHandler(MerchantContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Merchants_>> Handle(BaseRequest<Merchants_> request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            
            var merch = new Domain.Entities.Merchants_
            {
                name = input.name,
                image = input.image,
                address = input.address,
                rating = input.rating,
                created_at = (long)time,
                updated_at = (long)time
            };

            _context.MerchantsData.Add(merch);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseDto<Merchants_>
            {
                Message = "Success add merchant data",
                Status = true,
                Data = input
            };
        }
    }
}
