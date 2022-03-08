using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace BackendExercise.Models
{
    public class PersonLanguage
    {


        public int LanguageID { get; set; }
        public Language language{ get; set; }
    public int PersonID { get; set; }
    public Person person { get; set; }
public int ID { get; set; }

    }
}