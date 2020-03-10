using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Infrastructure.Persistences;
using CustomerServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;

namespace CustomerServices.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerDto>
    {
        private readonly CustomerContext _context;

        public CreateCustomerCommandHandler(CustomerContext context)
        {
            _context = context;
        }
        public async Task<CreateCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Domain.Entities.Customers
            {
                full_name = request.data.attributes.full_name,
                username = request.data.attributes.username,
                gender = request.data.attributes.gender,
                birthdate = request.data.attributes.birthdate,
                password = request.data.attributes.password,
                email = request.data.attributes.email,
                phone_number = request.data.attributes.phone_number
            };

            _context.CustomersData.Add(customer);
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            customer.created_at = (long)time;
            customer.updated_at = (long)time;
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCustomerDto
            {
                Success = true,
                Message = "Your data succesfully created"
            };
        }
    }
}
