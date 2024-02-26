using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP.StudentManagementSystemApp.Input
{
    public static class InputValidation
    {
        public static bool NameValidation(string name)
        {
            if (name == null) throw new ArgumentException(" argument is null");
            string pattern = @"^[a-zA-Z]{1,}(?: [a-zA-Z]+){0,2}$";
            return Regex.IsMatch(name, pattern);
        }

        public static bool rollNumberValidation(int rollNumber)
        {
            if (rollNumber == null) throw new ArgumentException(" argument is null");
            if(rollNumber.GetType() != typeof(int))
            {
                throw new FormatException(" argument should be a number");
            }
            return rollNumber > 0;
            
        }

        public static bool gradeValidation(char grade)
        {
            if (grade == null) throw new ArgumentException(" argument is null");
            if (grade.GetType() != typeof(char))
            {
                throw new FormatException(" argument should be a char");
            }
            return (int)grade >= 65 || (int)grade <= 70;

        }
    }
}
