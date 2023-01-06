using TutorialStudentManagement.Models;

namespace TutorialStudentManagement.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudent(string id);
        Student CreateStudent(Student student);
        void UpdateStudent(string id, Student student);
        void DeleteStudent(string id);
    }
}
