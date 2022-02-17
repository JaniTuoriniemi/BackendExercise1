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
            if (search == null & id == null)
            {
                foreach (Person x in _context.Persons.ToList())
                { Personlist.AddPerson(x); }
            }
          

            int _id;
            if (search != null)
            {

                List<Models.Person> list = Models.Personlist.Persons;
                List<Models.Person> a = list.FindAll(x => x.Name.Contains(search));
                List<Models.Person> b = list.FindAll(x => x.City.Contains(search));
                List<Models.Person> c = list.FindAll(x => Convert.ToString(x.Phone).Contains(search));
                Viewlist viewlist = new Viewlist();
                viewlist.list = a.Union(b).Union(c).ToList();

                

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

                viewlist.list = Models.Personlist.Persons; 
                



                return View(viewlist);
            }
            else
            {
                
                Viewlist viewlist = new Viewlist();

                viewlist.list = Models.Personlist.Persons;


                return View(viewlist);
            }
        }

        [HttpPost]
        public IActionResult People_main(Models.Viewlist the_list)
        { Person person = new Person() ;
            person.Name = the_list.Viewperson.Name;
            person.City = the_list.Viewperson.City;
            person.Phone = the_list.Viewperson.Phone;
            if (ModelState.IsValid)
            {person= Models.Personlist.AddPerson(person); }
           

            Viewlist viewlist = new Viewlist();

            viewlist.list = Models.Personlist.Persons;


           
            

            using (var transaction = _context.Database.BeginTransaction())

            {
                _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Person] ON");
                _context.Persons.Add(person);
              
                _context.SaveChanges();
                _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Person] OFF");
            }
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
                List<Models.Person> b = list.FindAll(x => x.City.Contains(search));
                List<Models.Person> c = list.FindAll(x => Convert.ToString(x.Phone).Contains(search));
                Viewlist viewlist = new Viewlist();
               
                
                viewlist.list = a.Union(b).Union(c).ToList();

              

                return View(viewlist);
            }
            else if (id != null)
            {
                _id = Convert.ToInt32(id);
                Models.Personlist.RemovePerson(_id);
                Viewlist viewlist = new Viewlist();
                viewlist.list = Models.Personlist.Persons;

                
                return View(viewlist);
            }
            else
            {
               
                Viewlist viewlist = new Viewlist();
                viewlist.list = Models.Personlist.Persons;


                return View(viewlist);
            }
        }

        [HttpPost]
        public IActionResult People_WithPartial(Models.Person person)
        {
            if (ModelState.IsValid)
            { Models.Personlist.AddPerson(person); }

            Viewlist viewlist = new Viewlist();

            viewlist.list = Models.Personlist.Persons;


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
                List<Models.Person> b = list.FindAll(x => x.City.Contains(search));
                List<Models.Person> c = list.FindAll(x => Convert.ToString(x.Phone).Contains(search));
                Viewlist viewlist = new Viewlist();
                
                viewlist.list = a.Union(b).Union(c).ToList();

                
                //string jsonperson = JsonConvert.SerializeObject(person.OtherPersons, Formatting.Indented);
                
                return PartialView("Shared/PartialPerson");
            }
            else if (id != null)
            {
                _id = Convert.ToInt32(id);
                Models.Personlist.RemovePerson(_id);
                Viewlist viewlist = new Viewlist();
                viewlist.list = Models.Personlist.Persons;

                return Json(viewlist);

                
            }
            else
            {
                Viewlist viewlist = new Viewlist();
                viewlist.list = Models.Personlist.Persons;
               

                return View(viewlist);
            }
        }
        [HttpPost]
        public IActionResult People_WithAJAX(Models.Person person)
        {
            if (ModelState.IsValid)
            { Models.Personlist.AddPerson(person); }

            Viewlist viewlist = new Viewlist();
            viewlist.list = Models.Personlist.Persons;
            



            return PartialView(viewlist);
        }
    }
}

