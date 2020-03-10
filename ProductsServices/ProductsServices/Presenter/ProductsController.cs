using ProductsServices.Application.UseCases.Products.Queries.GetProduct;
using ProductsServices.Application.UseCases.Products.Queries.GetProducts;
using ProductsServices.Application.UseCases.Products.Command.CreateProduct;
using ProductsServices.Application.UseCases.Products.Command.DeleteProduct;
using ProductsServices.Application.UseCases.Products.Command.UpdateProduct;
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
using ProductsServices.Domain.Entities;
using ProductsServices.Infrastructure.Persistences;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using ProductsServices.Application.Models.Query;


namespace ProductsServices.Presenter.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/Product")]

    public class ProductsController : ControllerBase
    {
        private IMediator _mediatr;

        public ProductsController(IMediator mediatr)
        {
            _mediatr = mediatr;

        }

        [HttpGet]
        public async Task<ActionResult<BaseDto<List<Products_>>>> Get()
        {
            return Ok(await _mediatr.Send(new GetProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto<Products_>>> Get(int id)
        {
  
            var command = new GetProductQuery(id);
            var result = await _mediatr.Send(command);
            return result != null ? (ActionResult)Ok(new { Message = "success", data = result }) : NotFound(new { Message = "not found" });

        }

        [HttpPost]
        public async Task<IActionResult> Post(BaseRequest<Products_> data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _mediatr.Send(command);

            return command != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BaseRequest<Products_> req)
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
