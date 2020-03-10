﻿using System;
namespace ProductsServices.Domain.Entities
{
    public class Products_
    {
        public int id { get; set; }
        public int merchant_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }

        //public Merchants merchant { get; set; }
    }
}
