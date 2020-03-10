using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchantsServices.Application.Models.Query;
using MerchantsServices.Domain.Entities;
using MerchantsServices.Infrastructure.Persistences;
using FluentValidation;

namespace MerchantsServices.Application.UseCases.Merchants.Command.CreateMerchant
{
    public class CreateMerchantValidation : AbstractValidator<BaseRequest<Merchants_>>
    {
        public CreateMerchantValidation()
        {
            RuleFor(x => x.data.attributes.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.data.attributes.address).NotEmpty().WithMessage("address can't be empty");
            RuleFor(x => x.data.attributes.rating).ExclusiveBetween(0, 6).WithMessage("rating is bettween 1-5");
        }
    }
}
