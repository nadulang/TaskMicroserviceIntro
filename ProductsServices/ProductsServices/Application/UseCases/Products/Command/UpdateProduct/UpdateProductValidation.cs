using System;
using FluentValidation;
using ProductsServices.Application.Models.Query;
using ProductsServices.Infrastructure.Persistences;
using ProductsServices.Domain.Entities;

namespace ProductsServices.Application.UseCases.Products.Command.UpdateProduct
{
    public class UpdateProductValidation : AbstractValidator<BaseRequest<Products_>>
    {
        public UpdateProductValidation()
        {
            RuleFor(x => x.data.attributes.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.data.attributes.name).MaximumLength(50).WithMessage("max username length is 50");
            RuleFor(x => x.data.attributes.price).NotEmpty().WithMessage("price can't be empty");
            RuleFor(x => x.data.attributes.price).GreaterThan(1000).WithMessage("price must be greater than 1000");
        }
    }
}
