using System;
using System.Collections.Generic;
namespace BackendExercise.Models
{
    public class Country

    {public string Countryname { get; set; }
        public List<City> Cities { get; set; }
        public int CountryID { get; set; }
    }
}
