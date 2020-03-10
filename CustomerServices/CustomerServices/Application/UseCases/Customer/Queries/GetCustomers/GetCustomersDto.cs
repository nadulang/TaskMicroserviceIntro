using CustomerServices.Domain.Entities;
using System;
using System.Collections.Generic;
using CustomerServices.Application.Models.Query;

namespace CustomerServices.Application.UseCases.Customer.Queries.GetCustomers
{
        public class GetCustomersDto : BaseDto
        {
            public IList<Customers> Data { get; set; }
        }
    
}
