using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using CustomerServices.Infrastructure.Persistences;
using System;


namespace CustomerServices.Application.UseCases.CustomerPayment.Queries.GetPayment
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, GetPaymentDto>
    {
        private readonly CustomerContext _context;

        public GetPaymentQueryHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<GetPaymentDto> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.PaymentsData.FindAsync(request.id);
            if (result == null)
            {
                return null;
            }
            else
            {


                return new GetPaymentDto
                {
                    Success = true,
                    Message = "Payment succesfully retrieved",
                    Data = result
                };
            }

        }
    }
}
