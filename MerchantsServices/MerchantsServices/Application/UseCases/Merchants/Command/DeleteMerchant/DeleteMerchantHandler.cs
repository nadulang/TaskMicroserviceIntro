using System;
using System.Threading;
using System.Threading.Tasks;
using MerchantsServices.Application.Models.Query;
using MerchantsServices.Infrastructure.Persistences;
using MerchantsServices.Domain.Entities;
using MediatR;

namespace MerchantsServices.Application.UseCases.Merchants.Command.DeleteMerchant
{
    public class DeleteMerchantHandler : IRequestHandler<DeleteMerchantCommand, BaseDto<Merchants_>>
    {
        private readonly MerchantContext _context;

        public DeleteMerchantHandler(MerchantContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Merchants_>> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.MerchantsData.FindAsync(request.Id);

            if (delete == null)
            {
                return null;
            }

            else
            {
                _context.MerchantsData.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<Merchants_>
                {
                    Status = true,
                    Message = "Successfully retrieved customer"
                };

            }
        }
    }
}
