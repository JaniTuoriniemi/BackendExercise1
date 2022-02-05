using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BackendExercise.Models
{
    public class Person
    { 
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public int Phone { get; set; }
        public   List<Models.Person> OtherPersons { get; set; }
        public int ID { get; set; }
    }
}
