using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Infrastructure.Persistences;
using CustomerServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CustomerServices.Application.UseCases.CustomerPayment.Command.DeletePayment
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, DeletePaymentCommandDto>
    {
        private readonly CustomerContext _context;

        public DeletePaymentCommandHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<DeletePaymentCommandDto> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.PaymentsData.FindAsync(request.Id);

            if (delete == null)
            {
                return null;
            }

            else
            {
                _context.PaymentsData.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new DeletePaymentCommandDto
                {
                    Success = true,
                    Message = "Successfully retrieved customer"
                };

            }
        }   
        
    }
}
