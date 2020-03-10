using System;
using Microsoft.EntityFrameworkCore;
using MerchantsServices.Domain.Entities;

namespace MerchantsServices.Infrastructure.Persistences
{
    public class MerchantContext : DbContext
    {
        public MerchantContext(DbContextOptions<MerchantContext> options) : base(options) { }
        public DbSet<Merchants_> MerchantsData { get; set; }
    }
}
