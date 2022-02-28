using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace BackendExercise.Models
{
    public class City
    {
        public  List<Person> Inhabitants { get; set; }
        public string CityName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryID { get; set; }
        public string Countryname { get; set; }

        public void AddInhabitant(Person person)
        {Inhabitants.Add(person); }
    }
}
