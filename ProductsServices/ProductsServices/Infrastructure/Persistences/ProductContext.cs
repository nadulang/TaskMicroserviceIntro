using System;
using Microsoft.EntityFrameworkCore;
using ProductsServices.Domain.Entities;

namespace ProductsServices.Infrastructure.Persistences
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Products_> ProductsData { get; set; }
    }
}
