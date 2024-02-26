using OOP.StudentManagementSystemApp.DbContent;
using OOP.StudentManagementSystemApp.Entities;
using OOP.StudentManagementSystemApp.Input;
using OOP.StudentManagementSystemApp.Interfaces;
using OOP.StudentManagementSystemApp.StudentManagmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OOP.StudentManagementSystemApp.Controller
{
    public class StudentManagmentController
    {
        private readonly IStudentManagment managment;

        public StudentManagmentController()
        {
            StudentManagmentDB Db = new StudentManagmentDB();
            managment = new StudentManagmentSystem(Db);
        }

        public void AddStudent()
        {
            Console.WriteLine("Adding student");

            Student newStudent = new Student();
            Labe:
            Console.WriteLine("Enter student full name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter student roll number: ");
            int rollNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter student grade: ");
            string gradeString = Console.ReadLine();

            char grade = gradeString[0];

            if(!InputValidation.gradeValidation(grade) || !InputValidation.NameValidation(name) || !InputValidation.rollNumberValidation(rollNumber))
            {
                Console.WriteLine("Incorrect information. Try again");
                goto Labe;
            }

            newStudent.Name = name;
            newStudent.Grade = grade;
            newStudent.RollNumber = rollNumber;

            managment.AddStudent(newStudent);
        }

        public void GetAllStudents() {
            var res = managment.GetAllStudents();
            res.ForEach(io => { Console.WriteLine(io); });
        }

        public void searchStudentById()
        {
            Start:
            Console.WriteLine("Enter student roll number: ");
            int rollNumber = int.Parse(Console.ReadLine());

            if (!InputValidation.rollNumberValidation(rollNumber))
            {
                Console.WriteLine("Incorrect input. Try again");
                goto Start;
            }

            Student student = new Student();

            student = managment.searchStudentById(rollNumber);

            Console.WriteLine(student.ToString());

        }

        public void updateGrade()
        {
            Console.WriteLine("Updaing grade");
            Alt:
            Console.WriteLine("Enter student roll number: ");
            int rollNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new grade: ");
            string gradeString = Console.ReadLine();

            char grade = gradeString[0];

            if (!InputValidation.gradeValidation(grade) || !InputValidation.rollNumberValidation(rollNumber))
            {
                Console.WriteLine("Incorrect information. Try again");
                goto Alt;
            }

            managment.updateGrade(rollNumber, grade);

            GetAllStudents();
        }

        public void Exit()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string Choice = "";
            Console.WriteLine("Hope  You Liked, Our APP, if you wonder, please Give US feadback.");
            Console.WriteLine("Y/N?");
            Choice = Console.ReadLine() ?? "N";
            if (Choice == "Y")
            {
                string response = "";
                Console.WriteLine("Please Give us feadback, tell what would you like to change (develop) in APP");
                response = Console.ReadLine() ?? "User do not give  feadback!!!";
                Console.WriteLine("thanks,for your  opinion! See you soon <3");
                Console.ResetColor();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Goodbye, see you around!");
                Console.ResetColor();
                Environment.Exit(0);
            }
        }
    }
}
