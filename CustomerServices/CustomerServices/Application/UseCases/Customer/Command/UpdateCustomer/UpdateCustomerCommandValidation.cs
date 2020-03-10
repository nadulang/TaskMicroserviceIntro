using System;
using FluentValidation;
namespace CustomerServices.Application.UseCases.Customer.Command.UpdateCustomer
{
    public class UpdateCustomerCommandValidation : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            RuleFor(x => x.data.attributes.username).NotEmpty().WithMessage("username can't be empty");
            RuleFor(x => x.data.attributes.username).MaximumLength(20).WithMessage("max username length is 20");
            RuleFor(x => x.data.attributes.email).NotEmpty().WithMessage("email can't be empty");
            RuleFor(x => x.data.attributes.email).EmailAddress().WithMessage("email is not valid email address");
            RuleFor(x => x.data.attributes.gender).IsInEnum().WithMessage("gender is one of male or female");
            RuleFor(x => x.data.attributes.gender).NotEmpty().WithMessage("gender can't be empty");
            RuleFor(x => x.data.attributes.birthdate).NotEmpty().WithMessage("birthdate can't be empty");
            RuleFor(x => DateTime.Now.Year - x.data.attributes.birthdate.Year).GreaterThanOrEqualTo(18).WithMessage("age must be greater than 18");
        }
    }
}
