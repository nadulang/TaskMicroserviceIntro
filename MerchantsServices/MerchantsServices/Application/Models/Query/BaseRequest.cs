﻿using System;
using MediatR;

namespace MerchantsServices.Application.Models.Query
{
    public class BaseRequest<T> : IRequest<BaseDto<T>>
    {
        public Data<T> data { get; set; }
    }

    public class Data<T>
    {
        public T attributes { get; set; }
    }
}
