using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Infrastructure.Persistences;
using CustomerServices.Application.Models.Query;
using CustomerServices.Domain.Entities;
using MediatR;


namespace CustomerServices.Application.UseCases.CustomerPayment.Command.UpdatePayment
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, UpdatePaymentCommandDto>
    {
        private readonly CustomerContext _context;

        public UpdatePaymentCommandHandler(CustomerContext context)
        {
            _context = context;
        }
        public async Task<UpdatePaymentCommandDto> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = _context.PaymentsData.Find(request.data.attributes.id);

            if (payment == null)
            {
                return null;
            }

            else
            {

                payment.customer_id = request.data.attributes.customer_id;
                payment.name_on_card = request.data.attributes.name_on_card;
                payment.exp_month = request.data.attributes.exp_month;
                payment.exp_year = request.data.attributes.exp_year;
                payment.postal_code = request.data.attributes.postal_code;
                payment.credit_card_number = request.data.attributes.credit_card_number;
                var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
                payment.updated_at = (long)time;

                await _context.SaveChangesAsync(cancellationToken);

                return new UpdatePaymentCommandDto
                {
                    Success = true,
                    Message = "Customer successfully updated",
                };
            }
        }
    }
}
