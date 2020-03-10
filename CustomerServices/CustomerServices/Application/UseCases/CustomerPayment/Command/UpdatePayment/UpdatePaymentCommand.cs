using System;
using CustomerServices.Domain.Entities;
using MediatR;

namespace CustomerServices.Application.UseCases.CustomerPayment.Command.UpdatePayment
{
    public class UpdatePaymentCommand : IRequest<UpdatePaymentCommandDto>
    {
        public Attribute data { get; set; }
    }

    public class Attribute
    {
        public CustomerPayments attributes { get; set; }
    }

      
}
