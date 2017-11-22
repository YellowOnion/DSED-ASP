using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations;
using System;

namespace DSEDRazor.Data
{
        public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<RentedMovie>()
                .HasOne(a => a.Customer)
                .WithMany()
                .HasForeignKey(a => a.CustIDFK);

            modelBuilder.Entity<RentedMovie>()
                .HasOne(a => a.Movie)
                .WithMany()
                .HasForeignKey(a => a.MovieIDFK);

            modelBuilder.Entity<RentedMovie>()
                .Property(b => b.DateRented)
                .ValueGeneratedOnAdd();
        }
        public DbSet<Customer> Customers {get;set;}

        public DbSet<Movie> Movies {get;set;}

        public DbSet<RentedMovie> RentedMovies {get;set;}
    }


    public class Customer
    {
        [Key]
        public int CustID {get;set;}
        public string FirstName { get;set; }
        public string LastName { get; set; }
        public string Address { get;set; }
        public string Phone { get;set; }
    }

    public class Movie
    {
        [Key]
        public int MovieID { get; set;}

        public string Rating {get; set; }

        public string Title {get; set;}

        public string Year {get; set; }
        
        public int? Rental_Cost {get; set; }
        public string Copies {get; set;}

        public string Plot {get; set;}

        public string Genre {get; set; }

    }

    public class RentedMovie
    {
        [Key]
        public int RMID {get; set;}

        [Required]
        public int MovieIDFK {get;set;}
        [Required]
        public Movie Movie {get; set;}

        [Required]
        public int CustIDFK {get;set;}
        [Required]
        public Customer Customer {get; set;}

        public DateTime DateRented {get;set;}

        public DateTime? DateReturned {get;set;}
    }

}