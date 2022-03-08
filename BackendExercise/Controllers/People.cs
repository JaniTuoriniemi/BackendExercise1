using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Web;
using Newtonsoft.Json;
using BackendExercise.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
namespace BackendExercise.Controllers
{
    public class People : Controller
    {
        private readonly PersonContext _context;

        public People(PersonContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult People_main(string search, int? id)
        {
            if (search == null & id == null )
            {
                foreach (City x in _context.Cities.ToList())
                { Models.Citylist.AddCity(x); }
                foreach (Country x in _context.Countries.ToList())
                { Models.Countrylist.AddCountry(x); }
                foreach (Person x in _context.Persons.ToList())
                { Personlist.AddPerson(x); }
                foreach (Language x in _context.Languages.ToList())
                { Languagelist.AddLanguage(x); }
            }
          

            int _id;
            if (search != null )
            {

                List<Models.Person> list = Models.Personlist.Persons;
                List<Models.Person> a = list.FindAll(x => x.Name.Contains(search));
                List<Models.Person> b = list.FindAll(x => Convert.ToString(x.CityName).Contains(search));
                List<Models.Person> c = list.FindAll(x => Convert.ToString(x.Phone).Contains(search));
                Viewlist viewlist = new Viewlist();
                viewlist.List = a.Union(b).Union(c).ToList();
                viewlist.Citylist = Models.Citylist.Cities;
                viewlist.Countrylist = Models.Countrylist.Countries;


                return View(viewlist);
            }
            else if (id != null)
            {
                _id = Convert.ToInt32(id);
                Models.Personlist.RemovePerson(_id);
                Person toberemoved = _context.Persons.Find(_id);
                if (toberemoved != null)
                { 
                _context.Persons.Remove(toberemoved);
                _context.SaveChanges();
                }
                Viewlist viewlist = new Viewlist();

                viewlist.List = Models.Personlist.Persons;

                viewlist.Citylist = Models.Citylist.Cities;
                viewlist.Countrylist = Models.Countrylist.Countries;


                return View(viewlist);
            }
            else
            {
                
                Viewlist viewlist = new Viewlist();

                viewlist.List = Models.Personlist.Persons;
                viewlist.Citylist = Models.Citylist.Cities;
                viewlist.Countrylist = Models.Countrylist.Countries;
                viewlist.Languagelist = Models.Languagelist.Languages;
                return View(viewlist);
            }
        }

        [HttpPost]
        public IActionResult People_main(Models.Viewlist the_list)
        {
           Language language = the_list.Viewlanguage;
            Person person = the_list.Viewperson;
            
            if (language != null && person !=null)    
            {
                
                List<Language> person_languages = new List<Language>();

                Language languageadded = Languagelist.Languages.Find(x => x.Languagename.Equals(the_list.Viewlanguage.Languagename));
               
               Person _person = Personlist.Persons.Find(x => x.Name.Equals(the_list.Viewperson.Name));
                if (languageadded != null)
                {
                    using (var transaction = _context.Database.BeginTransaction())

                    {
                        _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Person] ON");
                        
                        var uppdated_language = _context.Languages.First(a => a.Languagename == languageadded.Languagename);

                        List<Person> updated_persons = new List<Person>();
                        List<Person> the_persons = uppdated_language.Persons;
                        if (the_persons != null)
                        { updated_persons.AddRange(the_persons); }
                        if (_person != null && updated_persons != null)
                        { updated_persons.Add(_person); }
                        uppdated_language.Persons = updated_persons;

                        _context.SaveChanges();
                        
                        languageadded = Models.Languagelist.AddLanguage(languageadded);
                       
                        var uppdated_person = _context.Persons.First(a => a.PersonID == person.PersonID);
                        uppdated_person.Languages.Add(languageadded);
                        _context.SaveChanges();
                        _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Person] OFF");
                    }
                }
                else
                {
                    ViewBag.text1 = "No such language or person in database!";
                }
            }
            City city = the_list.Viewcity;
            if (city != null)
            {
                City tobeadded = Citylist.Cities.Find(x => x.CityName.Equals(the_list.Viewcity.CityName));
                if (tobeadded != null)
                {

                    person.Name = the_list.Viewperson.Name;
                    person.CityID = tobeadded.CityID;
                    person.CityName = tobeadded.CityName;
                    person.Phone = the_list.Viewperson.Phone;
                    person = Models.Personlist.AddPerson(person);
                    var index = Models.Citylist.Cities.FindIndex(x => x.CityName == tobeadded.CityName);
                    Models.Citylist.Cities[index] = tobeadded;

                    using (var transaction = _context.Database.BeginTransaction())

                    {
                        _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Person] ON");
                        _context.Persons.Add(person);

                        _context.SaveChanges();
                        _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Person] OFF");

                        var uppdated_city = _context.Cities.First(a => a.CityName == tobeadded.CityName);
                        uppdated_city.Inhabitants = Models.Citylist.Cities.Find(x => x.CityName.Equals(tobeadded.CityName)).Inhabitants;
                        _context.SaveChanges();
                    }

                }
                else if (tobeadded != null)
                {
                    ViewBag.text2 = "No such city in database!";
                }
            }
            foreach (City x in _context.Cities.ToList())
            { Models.Citylist.AddCity(x); }
            foreach (Country x in _context.Countries.ToList())
            { Models.Countrylist.AddCountry(x); }
            foreach (Person x in _context.Persons.ToList())
            { Personlist.AddPerson(x); }
            foreach (Language x in _context.Languages.ToList())
            { Languagelist.AddLanguage(x); }

            Viewlist viewlist = new Viewlist();
            viewlist.List = Models.Personlist.Persons;
            viewlist.Citylist = Models.Citylist.Cities;
            viewlist.Countrylist = Models.Countrylist.Countries;
            viewlist.Languagelist = Models.Languagelist.Languages;
            return View(viewlist);

        }
        [HttpGet]
        public IActionResult People_WithPartial(string search, int? id)
        {
            Models.Person person = new Models.Person();

            int _id;
            if (search != null)
            {

                List<Models.Person> list = Models.Personlist.Persons;
                List<Models.Person> a = list.FindAll(x => x.Name.Contains(search));
                List<Models.Person> b = list.FindAll(x => Convert.ToString(x.CityName).Contains(search));
                List<Models.Person> c = list.FindAll(x => Convert.ToString(x.Phone).Contains(search));
                Viewlist viewlist = new Viewlist();
               
                
                viewlist.List = a.Union(b).Union(c).ToList();

              

                return View(viewlist);
            }
            else if (id != null)
            {
                _id = Convert.ToInt32(id);
                Models.Personlist.RemovePerson(_id);
                Viewlist viewlist = new Viewlist();
                viewlist.List = Models.Personlist.Persons;

                
                return View(viewlist);
            }
            else
            {
               
                Viewlist viewlist = new Viewlist();
                viewlist.List = Models.Personlist.Persons;


                return View(viewlist);
            }
        }

        [HttpPost]
        public IActionResult People_WithPartial(Models.Person person)
        {
            if (ModelState.IsValid)
            { Models.Personlist.AddPerson(person); }

            Viewlist viewlist = new Viewlist();

            viewlist.List = Models.Personlist.Persons;


            return View(viewlist);

        }
        [HttpGet]
        public IActionResult People_WithAJAX(string search, int? id)
        {
            //if (search != null)
            //{ search = Convert.ToString(JsonConvert.DeserializeObject(search)); }
            Models.Person person = new Models.Person();

            int _id;
            if (search != null)
            {

                List<Models.Person> list = Models.Personlist.Persons;
                List<Models.Person> a = list.FindAll(x => x.Name.Contains(search));
                List<Models.Person> b = list.FindAll(x => Convert.ToString(x.CityName).Contains(search));
                List<Models.Person> c = list.FindAll(x => Convert.ToString(x.Phone).Contains(search));
                Viewlist viewlist = new Viewlist();
                
                viewlist.List = a.Union(b).Union(c).ToList();

                
                //string jsonperson = JsonConvert.SerializeObject(person.OtherPersons, Formatting.Indented);
                
                return PartialView("Shared/PartialPerson");
            }
            else if (id != null)
            {
                _id = Convert.ToInt32(id);
                Models.Personlist.RemovePerson(_id);
                Viewlist viewlist = new Viewlist();
                viewlist.List = Models.Personlist.Persons;

                return Json(viewlist);

                
            }
            else
            {
                Viewlist viewlist = new Viewlist();
                viewlist.List = Models.Personlist.Persons;
               

                return View(viewlist);
            }
        }
        [HttpPost]
        public IActionResult People_WithAJAX(Models.Person person)
        {
            if (ModelState.IsValid)
            { Models.Personlist.AddPerson(person); }

            Viewlist viewlist = new Viewlist();
            viewlist.List = Models.Personlist.Persons;
            



            return PartialView(viewlist);
        }
    }
}

