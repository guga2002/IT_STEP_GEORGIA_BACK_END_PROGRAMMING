using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleAPP.AtmConsoleApp.Validation
{
    public static class CalidateVariables
    {
        public static bool NameValidate(string? name)
        {
            if (name == null) throw new ArgumentException(" argument is null");
            string pattern = @"^[a-zA-Z]{2,15}$";
            return Regex.IsMatch(name, pattern);
        }

        public static bool SurnameValidate(string? Surname)
        {
            if (Surname == null) throw new ArgumentException(" argument is null");
            string pattern = @"^[a-zA-Z]{2,35}$";
            return Regex.IsMatch(Surname, pattern);
        }

        public static bool AgeISvalidate(int? age)//cota cudi logikaa:D 
        {
            if (age == -1) throw new ArgumentException(" argument is null");
            return age > 10 && age <= 120;
        }
           public static bool ValidateUserName(string? Surname)
        {
       if (Surname == null) throw new ArgumentException(" argument is null");
       string pattern = @"^[a-zA-Z0-9]{2,35}$";
       return Regex.IsMatch(Surname, pattern);
        }

        public static bool CaptionIsValid(string? caption)
        {
            if (caption == null) throw new ArgumentException(" argument is null");
            string pattern = @"^[a-zA-Z\s]{2,400}$";
            return Regex.IsMatch(caption, pattern);
        }
    }
}
