using MediatR;
using CustomerServices.Domain.Entities;

namespace CustomerServices.Application.UseCases.CustomerPayment.Command.CreatePayment
{
    public class CreatePaymentCommand : IRequest<CreatePaymentCommandDto>
    {

        public Attributes data { get; set; }
        
    }

    public class Attributes
    {
        public CustomerPayments attributes { get; set; }
    }

}
