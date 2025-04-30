using GradeDAL.Models;
using GradeDO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeDAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsManagmentController : ControllerBase
    {
        
        IStudents _students;
        ILogger<StudentsManagmentController> _logger;
        public StudentsManagmentController(IStudents students, ILogger<StudentsManagmentController> logger)
        {
            _students = students;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult AddStudent([FromBody]M_Student m_student)
        {
            _logger.LogInformation($"Adding student{m_student.ID}.");
            _students.AddStudent(m_student.StudentBuilder());
            return Ok($"Student {m_student} was added successfully!");
        }

        [HttpPut]
        public IActionResult EditStudent([FromBody] M_Student m_student) {
            _logger.LogInformation($"Editing student{m_student.ID}.");
            _students.EditStudent(m_student.StudentBuilder());
            return Ok($"Student edited succefully.");
        
        }
        [HttpDelete]
        public IActionResult DeleteStudent([FromBody]M_Student m_student)
        {
            _logger.LogInformation($"Deleting student{m_student.ID}.");
            Student student = m_student.StudentBuilder();
            _students.RemoveStudent(student.ID);
            return Ok($"Student {m_student} was removed successfully!");
        }
        [HttpGet]
        public IActionResult DisplayAllStudents()
        {
            _logger.LogInformation($"Displaying all students.");
            return Ok(_students.DisplayAll());
        }
        [HttpGet("{id}")]
        public IActionResult DisplayStudentByID([FromRoute]string id)
        {
            _logger.LogInformation($"Displaying student{id}.");
            return Ok(_students.DisplayStudent(id));
        }
        



    }
}
