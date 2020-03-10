using MediatR;
using MerchantsServices.Application.Models.Query;
using MerchantsServices.Domain.Entities;

namespace MerchantsServices.Application.UseCases.Merchants.Queries.GetMerchant
{
    public class GetMerchantQuery : IRequest<BaseDto<Merchants_>>
    {
        public int Id { get; set; }

        public GetMerchantQuery(int id)
        {
            Id = id;
        }
    }
}
