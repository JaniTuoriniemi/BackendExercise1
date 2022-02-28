using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;
namespace BackendExercise.Models
{
    public class Country

    {public string Countryname { get; set; }
        public List<City> Cities { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryID { get; set; }
    }
}
