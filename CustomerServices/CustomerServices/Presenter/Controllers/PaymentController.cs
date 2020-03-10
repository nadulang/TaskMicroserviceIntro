using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using System.Threading.Tasks;
using CustomerServices.Application.UseCases.CustomerPayment.Command.CreatePayment;
using CustomerServices.Application.UseCases.CustomerPayment.Command.DeletePayment;
using CustomerServices.Application.UseCases.CustomerPayment.Command.UpdatePayment;
using CustomerServices.Application.UseCases.CustomerPayment.Queries.GetPayment;
using CustomerServices.Application.UseCases.CustomerPayment.Queries.GetPayments;
using System;

namespace CustomerServices.Presenter.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/Payment")]

    public class PaymentController : ControllerBase
    {
        private IMediator _mediatr;

        public PaymentController(IMediator mediatr)
        {
            _mediatr = mediatr;

        }
        [HttpGet]
        public async Task<ActionResult<GetPaymentsDto>> Get()
        {
            var result = new GetPaymentsQuery();
            return Ok(await _mediatr.Send(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPaymentDto>> Get(int id)
        {
            var command = new GetPaymentQuery(id);
            var result = await _mediatr.Send(command);

            return result != null ? (ActionResult)Ok(new { Message = "success", data = result }) : NotFound(new { Message = "not found" });
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePaymentCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePaymentCommand(id);
            var result = await _mediatr.Send(command);

            return command != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdatePaymentCommand req)
        {
            try
            {
                req.data.attributes.id = id;
                var result = await _mediatr.Send(req);
                return Ok(result);
            }

            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
