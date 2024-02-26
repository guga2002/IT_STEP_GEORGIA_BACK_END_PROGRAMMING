using OOP.StudentManagementSystemApp.DbContent;
using OOP.StudentManagementSystemApp.Entities;
using OOP.StudentManagementSystemApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.StudentManagementSystemApp.StudentManagmentServices
{
    public class StudentManagmentSystem: AbstractService,IStudentManagment
    {
        private readonly List<Student> studentsEntity;
        public StudentManagmentSystem(StudentManagmentDB db):base(db)
        {
            studentsEntity = db.GetStudents();

        }

        public void AddStudent(Student student)
        {
            studentsEntity.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return studentsEntity.ToList();
        }

        public Student searchStudentById(int id)
        {
            var res = from student in studentsEntity
                      where student.RollNumber.Equals(id)
                      select student;
            if(res != null)
            {
                return res.First();
            }
            else
            {
                Console.WriteLine("Student not found");
            }
            return new Student();
        }

        public void updateGrade(int id, char grade)
        {
            var res = from student in studentsEntity
                      where student.RollNumber.Equals(id)
                      select student;

            if (res != null)
            {
                Student foundStudent = res.First();
                foundStudent.RollNumber = grade;
                Console.WriteLine("updated");
            } else
            {
                Console.WriteLine("Student not found");
        }
            }
    }
}
