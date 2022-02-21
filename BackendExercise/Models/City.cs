using System;
using System.Collections.Generic;
namespace BackendExercise.Models
{
    public class City
    {
        public List<Person> Inhabitants { get; set; }
        public string CityName { get; set; }
        public int CityID { get; set; }
        public int CountryID { get; set; }
        public string Countryname { get; set; }
    }
}
