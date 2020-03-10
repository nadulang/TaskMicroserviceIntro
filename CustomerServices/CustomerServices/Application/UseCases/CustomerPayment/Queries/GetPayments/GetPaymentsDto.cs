using CustomerServices.Domain.Entities;
using System;
using System.Collections.Generic;
using CustomerServices.Application.Models.Query;

namespace CustomerServices.Application.UseCases.CustomerPayment.Queries.GetPayments
{
    public class GetPaymentsDto : BaseDto
    {
        public IList<CustomerPayments> Data { get; set; }
    }
}
