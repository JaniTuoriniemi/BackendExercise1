using System;
using System.Collections.Generic;
namespace BackendExercise.Models
{
    public class Citylist
    {
        public static int IDcount { get; set; }
        public static List<City> Cities { get; set; }

        static Citylist()
        {
            Cities = new List<City>();
            IDcount = 1;
        }
        public static City AddCity(City city)
        {


            if (city.CityID > IDcount)
            { IDcount = city.CityID; }
            if (city.CityID == 0)
            {
                city.CityID = IDcount;
               IDcount = IDcount + 1;
            }
            Cities.Add(city);
            return city;
        }

        public static void RemoveCity(int id)
        {


            int a = Cities.FindIndex(x => Convert.ToInt32(x.CityID) == id);

            if (a > -1)
            { Cities.RemoveAt(a); }

        }
    }
}

