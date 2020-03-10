using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using ProductsServices.Application.Models.Query;
using ProductsServices.Domain.Entities;

namespace ProductsServices.Application.UseCases.Products.Command.CreateProduct
{
    public class CreateProductValidation : AbstractValidator<BaseRequest<Products_>>
    {
        public CreateProductValidation()
        {
            RuleFor(x => x.data.attributes.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.data.attributes.name).MaximumLength(50).WithMessage("max username length is 50");
            RuleFor(x => x.data.attributes.price).NotEmpty().WithMessage("price can't be empty");
            RuleFor(x => x.data.attributes.price).GreaterThan(1000).WithMessage("price must be greater than 1000");
        }
    }
}
