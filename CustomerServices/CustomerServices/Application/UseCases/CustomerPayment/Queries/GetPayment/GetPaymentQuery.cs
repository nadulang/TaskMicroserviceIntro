using MediatR;
namespace CustomerServices.Application.UseCases.CustomerPayment.Queries.GetPayment
{
    public class GetPaymentQuery : IRequest<GetPaymentDto>
    {
        public int id { get; set; }

        public GetPaymentQuery(int Id)
        {
            id = Id;
        }

    }
}

