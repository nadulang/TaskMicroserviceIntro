using System;
using ProductsServices.Application.Models.Query;
using ProductsServices.Domain.Entities;

namespace ProductsServices.Application.UseCases.Products.Command.UpdateProduct
{
    public class UpdateProductCommand : BaseRequest<Products_>
    {
        public int id { get; set; }
    }
}

