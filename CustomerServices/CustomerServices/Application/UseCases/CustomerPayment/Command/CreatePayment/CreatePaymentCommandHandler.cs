using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Infrastructure.Persistences;
using MediatR;
using System;

namespace CustomerServices.Application.UseCases.CustomerPayment.Command.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentCommandDto>
    {
        private readonly CustomerContext _context;

        public CreatePaymentCommandHandler(CustomerContext context)
        {
            _context = context;
        }
        public async Task<CreatePaymentCommandDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new Domain.Entities.CustomerPayments
            {
                customer_id = request.data.attributes.customer_id,
                name_on_card = request.data.attributes.name_on_card,
                exp_month = request.data.attributes.exp_month,
                exp_year = request.data.attributes.exp_year,
                postal_code = request.data.attributes.postal_code,
                credit_card_number = request.data.attributes.credit_card_number
            };

            _context.PaymentsData.Add(payment);
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            payment.created_at = (long)time;
            payment.updated_at = (long)time;
            await _context.SaveChangesAsync(cancellationToken);

            return new CreatePaymentCommandDto
            {
                Success = true,
                Message = "Your data succesfully created"
            };
        }
    }
}
