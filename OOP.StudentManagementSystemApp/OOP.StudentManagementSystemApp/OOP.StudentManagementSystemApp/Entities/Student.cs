using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.StudentManagementSystemApp.Entities
{
    public class Student: AbstractEntity
    {
        public string? Name { get; set; }

        public int RollNumber { get; set; }

        public char Grade { get; set; }

        public Student() : base()
        {

        }

        public Student(string name, int rollNumber, char grade)
        {
            this.Name = name;
            this.RollNumber = rollNumber;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Student Name:{Name}, RollNumber:{RollNumber}, Grade:{Grade} \n";
        }
    }
}
