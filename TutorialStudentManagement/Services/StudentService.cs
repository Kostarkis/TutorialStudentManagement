using MongoDB.Driver;
using TutorialStudentManagement.Models;

namespace TutorialStudentManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IStudentStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            _students = mongoClient.GetDatabase(settings.DatabaseName).GetCollection<Student>(settings.StudentsCoursesCollectionName);
        }
        public Student CreateStudent(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public void DeleteStudent(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public Student GetStudent(string id)
        {
            return _students.Find(student => student.Id == id).FirstOrDefault();
        }

        public List<Student> GetStudents()
        {
            return _students.Find(student => true).ToList();
        }

        public void UpdateStudent(string id, Student student)
        {
            _students.ReplaceOneAsync(student => student.Id == id, student);
        }
    }
}
