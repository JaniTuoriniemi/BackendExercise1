using BackendExercise.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Web;
using Newtonsoft.Json;
using System.Data.Entity;
namespace BackendExercise.Controllers
{
    public class CityController : Controller
    {
        private readonly Models.PersonContext _context;

        public CityController(Models.PersonContext context)
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
            
            if (nr > -1)
            {
                Citylist.RemoveCity(nr);

                Models.City toberemoved = _context.Cities.Find(nr);
                if (toberemoved != null)
                {
                    _context.Cities.Remove(toberemoved);
                    _context.SaveChanges();
                }
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
            city.CityName = the_list.Viewcity.CityName;
            city.Countryname= the_list.Viewcity.Countryname;

           Models.Country tobeadded = the_list.Countrylist.Find(x => x.Equals(the_list.Viewcity.Countryname));
            city.CountryID = tobeadded.CountryID;
            city = Models.Citylist.AddCity(city);
            Models.Countrylist.Countries.Find(x => x.Countryname.Equals(tobeadded.Countryname)).Cities.Add(city);
            Models.Viewlist Viewlist = new Models.Viewlist();

            Viewlist.List = Models.Personlist.Persons;
            Viewlist.Citylist = Models.Citylist.Cities;
            Viewlist.Countrylist = Models.Countrylist.Countries;

            _context.Cities.Add(city);

            _context.SaveChanges();
            var uppdated_country = _context.Countries.First(x=> x.Countryname==(tobeadded.Countryname));
            uppdated_country.Cities = Models.Countrylist.Countries.Find(x => x.Countryname.Equals(tobeadded.Countryname)).Cities;
            _context.SaveChanges();

            //using (var transaction = _context.Database.BeginTransaction())

            //{
            // _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Person] ON");
            //  _context.Cities.Add(city);

            //_context.SaveChanges();
            // _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Person] OFF");

            //var uppdated_country = _context.Countries.First(a => a.Countryname == tobeadded.Countryname);
            //uppdated_country.Cities = Models.Countrylist.Countries.Find(x => x.Countryname.Equals(tobeadded.Countryname)).Cities;
            //_context.SaveChanges();
            //}
            return View( Viewlist);

        }
    }
}
