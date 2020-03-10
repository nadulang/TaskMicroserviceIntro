using MediatR;
namespace CustomerServices.Application.UseCases.CustomerPayment.Command.DeletePayment
{
    public class DeletePaymentCommand : IRequest<DeletePaymentCommandDto>
    {
        public int Id { get; set; }

        public DeletePaymentCommand(int id)
        {
            Id = id;
        }
    }
}
