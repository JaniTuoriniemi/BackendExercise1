using Microsoft.AspNetCore.Mvc;

using BackendExercise.Models;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Reflection;
using System.Text;

using System.Web;
using Newtonsoft.Json;
using System.Data.Entity;
namespace BackendExercise.Controllers
{
   public class Controller2 : Controller
    {
        private readonly Models.PersonContext _context;

        public Controller2(Models.PersonContext context)
        {
            _context = context;
        }
        public IActionResult Country()
        {
            foreach (City x in _context.Cities.ToList())
            { Models.Citylist.AddCity(x); }
            foreach (Country x in _context.Countries.ToList())
            { Models.Countrylist.AddCountry(x); }
            foreach (Person x in _context.Persons.ToList())
            { Personlist.AddPerson(x); }

            Models.Viewlist Viewlist = new Models.Viewlist();
            Viewlist.List = Models.Personlist.Persons;
            Viewlist.Citylist = Models.Citylist.Cities;
            Viewlist.Countrylist = Models.Countrylist.Countries;


            return View(Viewlist);
        }
        [HttpGet]
        public IActionResult Country(int IDnr)
        {

            Models.Countrylist.RemoveCountry(IDnr);
            Models.Country toberemoved = _context.Countries.Find(IDnr);
            if (toberemoved != null)
            {
                _context.Countries.Remove(toberemoved);
                _context.SaveChanges();
            }
            Models.Viewlist Viewlist = new Models.Viewlist();

            Viewlist.List = Models.Personlist.Persons;

            Viewlist.List = Models.Personlist.Persons;
            Viewlist.Citylist = Models.Citylist.Cities;
            Viewlist.Countrylist = Models.Countrylist.Countries;
            return View(Viewlist);

        }
        [HttpPost]
        public IActionResult Country(Models.Viewlist the_list)
        {
            Models.Country country = new Models.Country();
            country.Countryname = the_list.Viewcountry.Countryname;
            


            Models.Viewlist Viewlist = new Models.Viewlist();

            country = Models.Countrylist.AddCountry(country);

            Viewlist.List = Models.Personlist.Persons;
            Viewlist.Citylist = Models.Citylist.Cities;
            Viewlist.Countrylist = Models.Countrylist.Countries;



            using (var transaction = _context.Database.BeginTransaction())

            {
                _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Country] ON");
                _context.Countries.Add(country);

                _context.SaveChanges();
                _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Country] OFF");
            }
            return View(Viewlist);

        }
    }
   
}
