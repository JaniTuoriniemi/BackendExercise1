using System;
using System.Collections.Generic;
namespace BackendExercise.Models
{
    public class Languagelist
    {
        public static int IDcount { get; set; }
        public static List<Language> Languages { get; set; }

        static Languagelist()
        {
            Languages = new List<Language>();
            IDcount = 1;
        }
        public static Language AddLanguage(Language language)
        {


            if (language.LanguageID > IDcount)
            { IDcount = language.LanguageID; }
            if (language.LanguageID == 0)
            {
                language.LanguageID = IDcount;
                IDcount = IDcount + 1;
            }
            Languages.Add(language);
            return language;
        }

        public static void RemoveLanguage(int id)
        {


            int a = Languages.FindIndex(x => Convert.ToInt32(x.LanguageID) == id);

            if (a > -1)
            { Languages.RemoveAt(a); }

        }
    }
}


