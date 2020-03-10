using System;
using FluentValidation;
using MerchantsServices.Application.Models.Query;
using MerchantsServices.Infrastructure.Persistences;
using MerchantsServices.Domain.Entities;

namespace MerchantsServices.Application.UseCases.Merchants.Command.UpdateMerchant
{
    public class UpdateMerchantValidation : AbstractValidator<BaseRequest<Merchants_>>
    {
        public UpdateMerchantValidation()
        {
            RuleFor(x => x.data.attributes.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.data.attributes.address).NotEmpty().WithMessage("address can't be empty");
            RuleFor(x => x.data.attributes.rating).ExclusiveBetween(0, 6).WithMessage("rating is bettween 1-5");
        }
    }
}
