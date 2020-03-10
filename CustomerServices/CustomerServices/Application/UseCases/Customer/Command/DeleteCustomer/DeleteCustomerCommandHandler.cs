using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Infrastructure.Persistences;
using CustomerServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CustomerServices.Application.UseCases.Customer.Command.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandDto>
    {
        private readonly CustomerContext _context;

        public DeleteCustomerCommandHandler(CustomerContext context)
        {
            _context = context;
        }
        public async Task<DeleteCustomerCommandDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.CustomersData.FindAsync(request.Id);

            if (delete == null)
            {
                return new DeleteCustomerCommandDto
                {
                    Success = false,
                    Message = "Not Found"
                };
            }

            else
            {
                _context.CustomersData.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new DeleteCustomerCommandDto
                {
                    Success = true,
                    Message = "Successfully retrieved customer"
                };

            }
        }
    }
}

