using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BackendExercise.ApplicationUserSpace;

using System.Linq;
using System.Threading.Tasks;

namespace BackendExercise.Models
{
    public class PersonContext : IdentityDbContext<ApplicationUser>
    {

        //DbContextOptions<PersonContext> options
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().ToTable("Country");
           // modelBuilder.Entity<Country>().HasData(
   // new Country { Countryname = "Sweden", CountryID = -1 });
            modelBuilder.Entity<City>().ToTable("City");
           // modelBuilder.Entity<City>().HasData(
   // new City { CityName = "Stockholm", Countryname = "Sweden", CountryID = -1, CityID = -1 });
     //       modelBuilder.Entity<City>().HasData(
    //new City { CityName = "Göteborg", Countryname = "Sweden", CountryID = -1, CityID = -2 });

            modelBuilder.Entity<Language>().ToTable("Language");
      //      modelBuilder.Entity<Language>().HasData(
        //     new Language { Languagename = "Swedish", LanguageID = -2 });
            modelBuilder.Entity<Person>().ToTable("Person");
            //modelBuilder.Entity<Person>().HasData(
    //new Person { Name = "Fredrik", CityName = "Stockholm", CityID = -1, Phone = 12345, PersonID = -1, });
            modelBuilder.Entity<PersonLanguage>().ToTable("PersonLanguage");
          //  modelBuilder.Entity<PersonLanguage>().HasData(

            // new PersonLanguage { LanguageID = -2, PersonID = -1, ID = -1 });

        
        string roleId = Guid.NewGuid().ToString();
        string userRoleId = Guid.NewGuid().ToString();
        string userId = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"

            });
modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
{
    Id = userRoleId,
    Name = "User",
    NormalizedName = "USER"
}

);

PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
{
    Id = userId,
    Email = "admin@admin.com",
    NormalizedEmail = "ADMIN@ADMIN.COM",
    UserName = "admin@admin.com",
    NormalizedUserName = "ADMIN@ADMIN.COM",
    PasswordHash = hasher.HashPassword(null, "password"),
    FirstName = "Admin",
    LastName = "Adminsson",
    Age = 294
});

modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
{
    RoleId = roleId,
    UserId = userId
});
        
}
}
}

