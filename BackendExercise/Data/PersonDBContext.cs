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
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Country>().HasData(
    new Country { Countryname = "Sweden",  CountryID = -1 });
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<City>().HasData(
    new City { CityName = "Stockholm", Countryname = "Sweden", CountryID=-1,CityID = -1 }); 
            modelBuilder.Entity<City>().HasData(
     new City { CityName = "Göteborg", Countryname = "Sweden", CountryID = -1, CityID = -2 });
    
            modelBuilder.Entity<Language>().ToTable("Language");
            modelBuilder.Entity<Language>().HasData(
             new Language { Languagename = "Swedish", LanguageID=-2 });
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Person>().HasData(
    new Person { Name = "Fredrik", CityName = "Stockholm", CityID = -1, Phone = 12345, PersonID = -1, });
           modelBuilder.Entity<PersonLanguage>().ToTable("PersonLanguage");
           modelBuilder.Entity<PersonLanguage>().HasData(

            new PersonLanguage { LanguageID = -2, PersonID = -1, ID= -1});
    }
    }
}