using System;
using MerchantsServices.Application.Models.Query;
using MerchantsServices.Domain.Entities;

namespace MerchantsServices.Application.UseCases.Merchants.Command.UpdateMerchant
{
    public class UpdateMerchantCommand : BaseRequest<Merchants_>
    {
        public int id { get; set; }
    }
}

