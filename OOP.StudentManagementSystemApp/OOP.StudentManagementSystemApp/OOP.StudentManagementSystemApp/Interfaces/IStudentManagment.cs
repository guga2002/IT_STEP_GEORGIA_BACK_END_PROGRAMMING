using OOP.StudentManagementSystemApp.Entities;

namespace OOP.StudentManagementSystemApp.Interfaces
{
    public interface IStudentManagment
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student searchStudentById(int id);
        void updateGrade(int id, char grade);
    }
}
