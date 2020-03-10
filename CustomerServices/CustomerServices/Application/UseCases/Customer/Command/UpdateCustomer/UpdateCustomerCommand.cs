using CustomerServices.Domain.Entities;
using MediatR;

namespace CustomerServices.Application.UseCases.Customer.Command.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<UpdateCustomerCommandDto>
    {
        public Attributes data { get; set; }
    }
    public class Attributes
    {
        public Customers attributes {get; set;}
    }
}

