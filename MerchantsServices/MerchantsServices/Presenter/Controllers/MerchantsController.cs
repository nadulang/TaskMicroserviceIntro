using MerchantsServices.Application.UseCases.Merchants.Queries.GetMerchant;
using MerchantsServices.Application.UseCases.Merchants.Queries.GetMerchants;
using MerchantsServices.Application.UseCases.Merchants.Command.CreateMerchant;
using MerchantsServices.Application.UseCases.Merchants.Command.DeleteMerchant;
using MerchantsServices.Application.UseCases.Merchants.Command.UpdateMerchant;
using System.Net.NetworkInformation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MerchantsServices.Domain.Entities;
using MerchantsServices.Infrastructure.Persistences;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using MerchantsServices.Application.Models.Query;

namespace MerchantsServices.Presenter.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/Merchants")]

    public class MerchantsController : ControllerBase
    {
        private IMediator _mediatr;

        public MerchantsController(IMediator mediatr)
        {
            _mediatr = mediatr;

        }

        [HttpGet]
        public async Task<ActionResult<BaseDto<List<Merchants_>>>> Get()
        {
            return Ok(await _mediatr.Send(new GetMerchantsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto<Merchants_>>> Get(int id)
        {
  
            var command = new GetMerchantQuery(id);
            var result = await _mediatr.Send(command);
            return result != null ? (ActionResult)Ok(new { Message = "success", data = result }) : NotFound(new { Message = "not found" });

        }

        [HttpPost]
        public async Task<IActionResult> Post(BaseRequest<Merchants_> data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMerchantCommand(id);
            var result = await _mediatr.Send(command);

            return command != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BaseRequest<Merchants_> req)
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
