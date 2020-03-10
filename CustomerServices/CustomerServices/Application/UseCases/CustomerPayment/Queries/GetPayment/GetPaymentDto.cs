using CustomerServices.Domain.Entities;
using CustomerServices.Application.Models.Query;

namespace CustomerServices.Application.UseCases.CustomerPayment.Queries.GetPayment
{
    public class GetPaymentDto : BaseDto
    {
        public CustomerPayments Data { get; set; }
    }
}
