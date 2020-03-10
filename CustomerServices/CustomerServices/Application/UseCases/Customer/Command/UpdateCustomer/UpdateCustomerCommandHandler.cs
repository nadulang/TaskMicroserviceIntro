using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Infrastructure.Persistences;
using CustomerServices.Application.Models.Query;
using CustomerServices.Domain.Entities;
using MediatR;

namespace CustomerServices.Application.UseCases.Customer.Command.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandDto>
    {
        private readonly CustomerContext _context;
        public UpdateCustomerCommandHandler(CustomerContext context)
        {
            _context = context;
        }
        public async Task<UpdateCustomerCommandDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customers = _context.CustomersData.Find(request.data.attributes.id);

            customers.full_name = request.data.attributes.full_name;
            customers.username = request.data.attributes.username;
            customers.birthdate = request.data.attributes.birthdate;
            customers.password = request.data.attributes.password;
            customers.gender = request.data.attributes.gender;
            customers.email = request.data.attributes.email;
            customers.phone_number = request.data.attributes.phone_number;
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            customers.updated_at = (long)time;

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateCustomerCommandDto
            {
                Success = true,
                Message = "Customer successfully updated",
            };
        }
    }
}
