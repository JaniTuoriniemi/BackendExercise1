using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackendExercise.Controllers
{
    public class CityController : Controller
    {
        private readonly Models.PersonContext _context;

        public CityController(Models.PersonContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult People_main(int IDnr)
        {
           
            Models.Citylist.RemoveCity(IDnr);
            Models.City toberemoved = _context.Cities.Find(IDnr);
            if (toberemoved != null)
            {
                _context.Cities.Remove(toberemoved);
                _context.SaveChanges();
            }
            Models.Viewlist viewlist = new Models.Viewlist();

            viewlist.List = Models.Personlist.Persons;

            viewlist.List = Models.Personlist.Persons;
            viewlist.Citylist = Models.Citylist.Cities;
            viewlist.Countrylist = Models.Countrylist.Countries;
            return View(viewlist);

        }


        [HttpPost]
        public IActionResult People_main(Models.Viewlist the_list)
        {
            Models.City city = new Models.City();
            city.CityName = the_list.Viewcity.CityName;
            city.Countryname= the_list.Viewcity.Countryname;

           Models.Country tobeadded = the_list.Countrylist.Find(x => x.Equals(the_list.Viewcity.Countryname));
            city.CountryID = tobeadded.CountryID;
            city = Models.Citylist.AddCity(city);
            Models.Countrylist.Countries.Find(x => x.Countryname.Equals(tobeadded.Countryname)).Cities.Add(city);
            Models.Viewlist viewlist = new Models.Viewlist();

            viewlist.List = Models.Personlist.Persons;
            viewlist.Citylist = Models.Citylist.Cities;
            viewlist.Countrylist = Models.Countrylist.Countries;

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
            return View(viewlist);

        }
    }
}
