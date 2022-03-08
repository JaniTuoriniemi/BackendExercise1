
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace BackendExercise.Models
{
    public class Language
    {
        public string Languagename { get; set; }
        public List<Person> Persons { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LanguageID { get; set; }

    }
}
