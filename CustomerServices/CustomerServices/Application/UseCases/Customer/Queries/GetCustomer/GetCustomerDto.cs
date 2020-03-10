using System;
using CustomerServices.Application.Models.Query;
using CustomerServices.Domain.Entities;

namespace CustomerServices.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerDto : BaseDto
    {
        public Customers Data { get; set; }
    }

}

