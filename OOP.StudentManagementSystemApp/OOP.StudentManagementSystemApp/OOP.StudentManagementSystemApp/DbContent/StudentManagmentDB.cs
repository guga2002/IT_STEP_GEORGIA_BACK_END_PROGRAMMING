using OOP.StudentManagementSystemApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.StudentManagementSystemApp.DbContent
{
    public class StudentManagmentDB
    {
        private List<Student> students = new List<Student>();
        public StudentManagmentDB() {
            GenerateRandomData();
        }

        private void GenerateRandomData()
        {
            Random random = new Random();
            string name = Faker.Name.FullName();
            char grade = (char)random.Next(65, 71);
            int rollNumber = random.Next(1, 100);

            for(int i = 0; i < students.Count(); i++) {
                Student student = new Student()
                {
                    Name = name,
                    Grade = grade,
                    RollNumber = rollNumber,
                };
                students.Add(student);
            }
        }

        public List<Student> GetStudents() {
            return students;
        }
    }
}
