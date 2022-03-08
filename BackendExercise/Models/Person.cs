using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace BackendExercise.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Must enter valid city.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }
        [Required(ErrorMessage = "Must enter valid city.")]
        public string CityName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityID { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public int Phone { get; set; }
        public List<Language> Languages { get; set; }
        public void AddLanguage(Language language)
        { this.Languages.Add(language); }
        
    }
}
