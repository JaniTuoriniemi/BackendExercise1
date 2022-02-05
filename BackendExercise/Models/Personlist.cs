using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BackendExercise.Models
{
    public  static class Personlist
    {
        public static int IDcount { get; set; }
        public  static List<Person> Persons { get; set; }
         static Personlist()
        {
            Persons = new List<Person>();
            IDcount = 1;
        }
        public static void AddPerson(Person person)
        {
            person.ID = IDcount;
            IDcount++;
            Persons.Add(person); }

        public static void RemovePerson(int id)
        {
           

            int a = Persons.FindIndex(x => Convert.ToInt32(x.ID)==id);

            if (a > -1)
            { Persons.RemoveAt(a); }
           
        }
    }
}
