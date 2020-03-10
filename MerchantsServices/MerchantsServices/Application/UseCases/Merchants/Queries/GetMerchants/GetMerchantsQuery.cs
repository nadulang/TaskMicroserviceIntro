using System.Collections.Generic;
using MediatR;
using MerchantsServices.Application.Models.Query;
using MerchantsServices.Domain.Entities;

namespace MerchantsServices.Application.UseCases.Merchants.Queries.GetMerchants
{
    public class GetMerchantsQuery : IRequest<BaseDto<List<Merchants_>>>
    {
        
    }
}
