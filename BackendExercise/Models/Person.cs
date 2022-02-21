using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace BackendExercise.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Must enter valid city.")]
        public int PersonID { get; set; }
        [Required(ErrorMessage = "Must enter valid city.")]
        public string CityName { get; set; }
        public int CityID { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public int Phone { get; set; }
        //public   List<Models.Person> OtherPersons { get; set; }
        
        
        
    }
}
