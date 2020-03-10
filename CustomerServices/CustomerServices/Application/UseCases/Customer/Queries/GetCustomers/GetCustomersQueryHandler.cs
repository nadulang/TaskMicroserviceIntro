using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Application.Models.Query;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerServices.Domain.Entities;
using CustomerServices.Infrastructure.Persistences;
using System.Collections.Generic;

namespace CustomerServices.Application.UseCases.Customer.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersDto>
    {
        private readonly CustomerContext _context;

        public GetCustomersQueryHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<GetCustomersDto> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {


            var data = await _context.CustomersData.ToListAsync();

            var result = data.Select(e => new Customers
            {
                id = e.id,
                full_name = e.full_name,
                username = e.username,
                birthdate = e.birthdate,
                password = e.password,
                gender = e.gender,
                email = e.email,
                phone_number = e.phone_number,
                created_at = e.created_at,
                updated_at = e.updated_at

            });


            return new GetCustomersDto
            {
                Message = "Success retrieving data",
                Success = true,
                Data = result.ToList()
            };
        }
    }
}

