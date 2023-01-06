using Microsoft.AspNetCore.Mvc;
using TutorialStudentManagement.Models;
using TutorialStudentManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TutorialStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentService.GetStudents();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student =  _studentService.GetStudent(id);
            if(student is null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            _studentService.CreateStudent(student);

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Student> Put(string id, [FromBody] Student student)
        {
            var existingStudent = _studentService.GetStudent(id);
            if(existingStudent is null)
                return NotFound($"Student with Id = {id} not found");

            _studentService.UpdateStudent(id, student);
            return student;
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingStudent = _studentService.GetStudent(id);
            if (existingStudent is null)
                return NotFound($"Student with Id = {id} not found");

            _studentService.DeleteStudent(id);
            return Ok($"Student with Id = {id} deletd");
        }
    }
}
