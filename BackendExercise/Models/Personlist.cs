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
        public static Person AddPerson(Person person)
        {


            if (person.IDnr > IDcount)
            { IDcount = person.IDnr; }
            if (person.IDnr==0)
            {    
                person.IDnr = IDcount;
                IDcount = IDcount + 1;
            }
            Persons.Add(person);
            return person;
        }

        public static void RemovePerson(int id)
        {
           

            int a = Persons.FindIndex(x => Convert.ToInt32(x.IDnr)==id);

            if (a > -1)
            { Persons.RemoveAt(a); }
            
        }
    }
}
