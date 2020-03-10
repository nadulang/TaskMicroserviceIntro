using MediatR;
using MerchantsServices.Application.Models.Query;
using MerchantsServices.Domain.Entities;

namespace MerchantsServices.Application.UseCases.Merchants.Command.DeleteMerchant
{
    public class DeleteMerchantCommand : IRequest<BaseDto<Merchants_>>
    {
        public int Id { get; set; }

        public DeleteMerchantCommand(int id)
        {
            Id = id;
        }
    }
}
