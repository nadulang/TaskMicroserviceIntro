using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Application.Models.Query;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerServices.Domain.Entities;
using CustomerServices.Infrastructure.Persistences;
namespace CustomerServices.Application.UseCases.CustomerPayment.Queries.GetPayments
{
    public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, GetPaymentsDto>
    {
        private readonly CustomerContext _context;

        public GetPaymentsQueryHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<GetPaymentsDto> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {

            var data = await _context.PaymentsData.ToListAsync();

            var result = data.Select(e => new CustomerPayments
            {
                id = e.id,
                customer_id = e.customer_id,
                name_on_card = e.name_on_card,
                exp_month = e.exp_month,
                exp_year = e.exp_year,
                postal_code = e.postal_code,
                credit_card_number = e.credit_card_number,
                created_at = e.created_at,
                updated_at = e.updated_at
            });

            return new GetPaymentsDto
            {
                Message = "Success retrieving data",
                Success = true,
                Data = result.ToList()
            };
        }
    }
}
