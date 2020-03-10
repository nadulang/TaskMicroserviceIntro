using System;
using Microsoft.EntityFrameworkCore;
using CustomerServices.Domain.Entities;
namespace CustomerServices.Infrastructure.Persistences
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }
        public DbSet<Customers> CustomersData { get; set; }
        public DbSet<CustomerPayments> PaymentsData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPayments>()
                        .HasOne(j => j.customer)
                        .WithMany()
                        .HasForeignKey(j => j.customer_id);
        }
    }
}
