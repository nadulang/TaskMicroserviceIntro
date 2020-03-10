using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using CustomerServices.Infrastructure.Persistences;

namespace CustomerServices.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerDto>
    {
        private readonly CustomerContext _context;

        public GetCustomerQueryHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<GetCustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {



            var result = await _context.CustomersData.FindAsync(request.id);
            if (result == null)
            {
                return null;
            }
            else
            {
                return new GetCustomerDto
                {
                    Success = true,
                    Message = "Customer succesfully retrieved",
                    Data = result
                };
            }


        }
    }
}
