using System.Collections.Generic;
using MediatR;
using ProductsServices.Application.Models.Query;
using ProductsServices.Domain.Entities;

namespace ProductsServices.Application.UseCases.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<BaseDto<List<Products_>>>
    {
        
    }
}
