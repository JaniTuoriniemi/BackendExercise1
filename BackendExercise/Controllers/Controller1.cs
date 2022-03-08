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
    public class Controller1 : Controller
    {
        private readonly Models.PersonContext _context;

        public Controller1(Models.PersonContext context)
        {
            _context = context;
        }
        public IActionResult City()
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
        public IActionResult City(int nr)
        {
                Citylist.RemoveCity(nr);

                Models.City toberemoved = _context.Cities.Find(nr);
                if (toberemoved != null)
                {
                    _context.Cities.Remove(toberemoved);
                    _context.SaveChanges();
                }
            
            Models.Viewlist Viewlist = new Models.Viewlist();
            Viewlist.List = Models.Personlist.Persons;
            Viewlist.Citylist = Models.Citylist.Cities;
            Viewlist.Countrylist = Models.Countrylist.Countries;

            return View(Viewlist);

        }

        [HttpPost]
        public IActionResult City(Models.Viewlist the_list)
        {
            Models.City city = new Models.City();
            Country tobeadded = Countrylist.Countries.Find(x=>x.Countryname ==the_list.Viewcity.Countryname);
            if (tobeadded != null)
            {
                city.CityName = the_list.Viewcity.CityName;
                city.Countryname = the_list.Viewcity.Countryname;
                city.CountryID = tobeadded.CountryID;
                city = Models.Citylist.AddCity(city);
                using (var transaction = _context.Database.BeginTransaction())
                {
                    _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [City] ON");
                    _context.Cities.Add(city);

                    _context.SaveChanges();
                    _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [City] OFF");
                    _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Country] ON");
                    var uppdated_country = _context.Countries.First(x => x.Countryname == (tobeadded.Countryname));
                    uppdated_country.Cities.Add(city);

                    _context.SaveChanges();
                    _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Country] OFF");
                }
            }
            else
            {
                ViewBag.text = "No such country in database!";
            }
                    
            Models.Viewlist Viewlist = new Models.Viewlist();

            Viewlist.List = Models.Personlist.Persons;
            Viewlist.Citylist = Models.Citylist.Cities;
            Viewlist.Countrylist = Models.Countrylist.Countries;
            return View(Viewlist);
        }
        }
}
