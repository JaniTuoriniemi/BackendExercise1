using Microsoft.AspNetCore.Mvc;
using BackendExercise.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace BackendExercise.Controllers
{
    public class Controller3 : Controller
    {
        private readonly Models.PersonContext _context;

        public Controller3(Models.PersonContext context)
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
            Viewlist.Languagelist= Models.Languagelist.Languages;

            return View(Viewlist);
        }
         [HttpGet]
        public IActionResult Language(int nr)
        {  
            Languagelist.RemoveLanguage(nr);

            Models.Language toberemoved = _context.Languages.Find(nr);
            if (toberemoved != null)
            {
                _context.Languages.Remove(toberemoved);
                _context.SaveChanges();
            }

            Models.Viewlist Viewlist = new Models.Viewlist();
            Viewlist.List = Models.Personlist.Persons;
            Viewlist.Citylist = Models.Citylist.Cities;
            Viewlist.Countrylist = Models.Countrylist.Countries;
            Viewlist.Languagelist = Models.Languagelist.Languages;

            return View(Viewlist);
        }

        [HttpPost]
        public IActionResult Language(Models.Viewlist the_list)
        {
                Models.Language language = new Models.Language();
                language.Languagename = the_list.Viewlanguage.Languagename;
                language = Models.Languagelist.AddLanguage(language);
               // using (var transaction = _context.Database.BeginTransaction())
                //{
                  //  _context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Language] ON");
                    _context.Languages.Add(language);
                    _context.SaveChanges();
                    //_context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Language] OFF");
                //}
           
            Models.Viewlist Viewlist = new Models.Viewlist();

            Viewlist.List = Models.Personlist.Persons;
            Viewlist.Citylist = Models.Citylist.Cities;
            Viewlist.Countrylist = Models.Countrylist.Countries;
            Viewlist.Languagelist = Models.Languagelist.Languages;  

            return View(Viewlist);
        }
    }
}

