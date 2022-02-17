using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace BackendExercise.Models
{
    public class PersonContext : DbContext
    {
        //DbContextOptions<PersonContext> options
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Person>().HasData(
    new Person { Name = "Fredrik", City = "Stockholm", Phone = 12345, IDnr = -2 });
            modelBuilder.Entity<Person>().HasData(
   new Person { Name = "Bosse", City = "Göteborg", Phone = 54321, IDnr = -1 });
        }
    }

    public class Class
    {
    }

}