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
namespace BackendExercise.Controllers
{
    public class People : Controller
    {
        [HttpGet]
        public IActionResult People_main(string search, int? id)
        {
            Models.Person person = new Models.Person();

            int _id;
            if (search != null)
            {

                List<Models.Person> list = Models.Personlist.Persons;
                List<Models.Person> a = list.FindAll(x => x.Name.Contains(search));
                List<Models.Person> b = list.FindAll(x => x.City.Contains(search));
                List<Models.Person> c = list.FindAll(x => Convert.ToString(x.Phone).Contains(search));

                List<Models.Person> viewlist = a.Union(b).Union(c).ToList();

                person.OtherPersons = viewlist;

                return View(person);
            }
            else if (id != null)
            {
                _id = Convert.ToInt32(id);
                Models.Personlist.RemovePerson(_id);

                if (Models.Personlist.Persons != null)
                {

                    { person.OtherPersons = Models.Personlist.Persons; }
                }



                return View(person);
            }
            else
            {
                if (Models.Personlist.Persons != null)
                {

                    { person.OtherPersons = Models.Personlist.Persons; }
                }

                return View(person);
            }
        }

        [HttpPost]
        public IActionResult People_main(Models.Person person)
        {
            if (ModelState.IsValid)
            { Models.Personlist.AddPerson(person); }


            if (Models.Personlist.Persons != null)
            {

                { person.OtherPersons = Models.Personlist.Persons; }
            }



            return View( person);

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

                List<Models.Person> viewlist = a.Union(b).Union(c).ToList();

                person.OtherPersons = viewlist;

                return View(person);
            }
            else if (id != null)
            {
                _id = Convert.ToInt32(id);
                Models.Personlist.RemovePerson(_id);

                if (Models.Personlist.Persons != null)
                {

                    { person.OtherPersons = Models.Personlist.Persons; }
                }



                return View(person);
            }
            else
            {
                if (Models.Personlist.Persons != null)
                {

                    { person.OtherPersons = Models.Personlist.Persons; }
                }

                return View(person);
            }
        }
    
    [HttpPost]
    public IActionResult People_WithPartial(Models.Person person)
    {
        if (ModelState.IsValid)
        { Models.Personlist.AddPerson(person); }


        if (Models.Personlist.Persons != null)
        {

            { person.OtherPersons = Models.Personlist.Persons; }
        }



        return View( person);

    }
}
}

