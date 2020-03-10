using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchantsServices.Application.Models.Query;
using MerchantsServices.Infrastructure.Persistences;
using MerchantsServices.Domain.Entities;
using System;

namespace MerchantsServices.Application.UseCases.Merchants.Command.UpdateMerchant
{
    public class UpdateMerchantHandler : IRequestHandler<UpdateMerchantCommand, BaseDto<Merchants_>>
    {
        private readonly MerchantContext _context;

        public UpdateMerchantHandler(MerchantContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Merchants_>> Handle(UpdateMerchantCommand request, CancellationToken cancellationToken)
        {
            var merch = _context.MerchantsData.Find(request.id);
            merch.name = request.data.attributes.name;
            merch.image = request.data.attributes.image;
            merch.address = request.data.attributes.address;
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            merch.updated_at = (long)time;

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseDto<Merchants_>
            {
                Status = true,
                Message = "Customer successfully updated",
            };
        }
    }
}
