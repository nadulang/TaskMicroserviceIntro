using System;
using MediatR;
using CustomerServices.Domain.Entities;

namespace CustomerServices.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerDto>
    {
        public Attributes data { get; set; }
    }

    public class Attributes
    {
        public Customers attributes { get; set; }
    }
}
