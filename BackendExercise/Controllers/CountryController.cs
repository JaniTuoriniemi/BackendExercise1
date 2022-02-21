using Microsoft.AspNetCore.Mvc;

namespace BackendExercise.Controllers
{
    public class CountryController : Controller
    {
        private readonly Models.PersonContext _context;

        public CountryController(Models.PersonContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult People_main(int IDnr)
        {

            Models.Countrylist.RemoveCountry(IDnr);
            Models.Country toberemoved = _context.Countries.Find(IDnr);
            if (toberemoved != null)
            {
                _context.Countries.Remove(toberemoved);
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
            Models.Country country = new Models.Country();
            country.Countryname = the_list.Viewcountry.Countryname;
            


            Models.Viewlist viewlist = new Models.Viewlist();

            country = Models.Countrylist.AddCountry(country);

            viewlist.List = Models.Personlist.Persons;
            viewlist.Citylist = Models.Citylist.Cities;
            viewlist.Countrylist = Models.Countrylist.Countries;



            using (var transaction = _context.Database.BeginTransaction())

            {
                //_context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Person] ON");
                _context.Countries.Add(country);

                _context.SaveChanges();
                //_context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [Person] OFF");
            }
            return View(viewlist);

        }
    }
   
}
