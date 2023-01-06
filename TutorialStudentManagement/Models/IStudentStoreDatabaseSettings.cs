namespace TutorialStudentManagement.Models
{
    public interface IStudentStoreDatabaseSettings
    {
        string StudentsCoursesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
