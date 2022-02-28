using System;
using System.Collections.Generic;
namespace BackendExercise.Models
{
    public class Countrylist
    {

        public static int IDcount { get; set; }
        public static List<Country> Countries { get; set; }

        static Countrylist()
        {
            Countries = new List<Country>();
            IDcount = 1;
        }
        public static Country AddCountry(Country country)
        {


            if (country.CountryID > IDcount)
            { IDcount = country.CountryID; }
            if (country.CountryID == 0)
            {
                country.CountryID = IDcount;
                IDcount = IDcount + 1;
            }
            Countries.Add(country);
            return country;
        }

        public static void RemoveCountry(int id)
        {


            int a = Countries.FindIndex(x => Convert.ToInt32(x.CountryID) == id);

            if (a > -1)
            { Countries.RemoveAt(a); }

        }
    }
}

