using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BackendExercise.Models
{

    public class Viewlist
    {
        public List<Models.Person> List { get; set; }
        public List<Models.City> Citylist { get; set; }
        public List<Models.Country> Countrylist { get; set; }
        public Person Viewperson { get; set; }

        public City Viewcity { get; set; }

        public Country Viewcountry { get; set; }
        //public Viewlist()
        //{

        //  list=Personlist.Persons;
        //}
    }
}


