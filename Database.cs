using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DSEDRazor.Data
{
    public class Customer
    {
        public int Id {get;set;}
        public string FirstName { get;set; }
        public string LastName { get; set; }
        public string Address { get;set; }
        public int PhoneNumber { get;set; }
    }


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Customer> Customers {get;set;}
    }
}