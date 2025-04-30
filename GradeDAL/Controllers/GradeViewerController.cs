using GradeDAL.Configurations;
using GradeDAL.Services;
using GradeDO;
using GradeDO.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeDAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeViewerController : ControllerBase
    {
        ILogger<GradeViewerController> _logger;
        IStudents _students;
        IPasswordManager _passwordManager;
        IGradeManager _gradeManager;
        public GradeViewerController(ILogger<GradeViewerController> logger,IStudents students, IPasswordManager passwordManager, IGradeManager gradeManager)
        {
            _students = students; 
            _passwordManager = passwordManager;
            _gradeManager = gradeManager;
            _logger= logger;
        }
        [HttpGet]
        public IActionResult ViewLastExeAndAverageOfStudent([FromQuery]string name,[FromQuery]string password)
        {
            _logger.LogInformation($"Viewing the last mark for student {name} and the average of that exercise.");
            Student student = _students.DisplayAllList().FirstOrDefault(stu => stu.Name == name);
            if (student == null)
                throw new StudentNotExistException(name);
            if (!_passwordManager.ChackPassword(name,password)) return BadRequest("Password Incorrect.");
           
            return Ok($"Last mark for {name} is: {student.ExeList.Last().ToString()} and the average of that exercise is: {_gradeManager.AverageForGivenExe(student.ExeList.Last().ExeNumber)} ");

        }
        [HttpGet("specificExe")]
        public IActionResult ViewSpecificExeAndAverage([FromQuery] string name, [FromQuery] string password, [FromQuery] int exeNum)
        {
            _logger.LogInformation($"Viewing specific mark for student {name} and the average of that exercise.");

            Student student = _students.DisplayAllList().FirstOrDefault(stu => stu.Name == name);
            if (student == null)
                throw new StudentNotExistException(name);
            if (!_passwordManager.ChackPassword(name, password)) return BadRequest("Password Incorrect.");
            int mark = student.ExeList.Find(e => e.ExeNumber == exeNum).Mark;
            if (mark == -1)
            {
                return BadRequest("Exercise number is Incorrect.");
            }
            return Ok($"Mark of exercise:{exeNum} for {name} is: {mark} and the average of that exercise is: {_gradeManager.AverageForGivenExe(exeNum)} ");
        }
        [HttpGet("{name}")]
        public IActionResult ViewFinalMark([FromRoute]string name, [FromQuery]string password)
        {
            _logger.LogInformation($"Viewing the final mark for student {name}.");

            Student student = _students.DisplayAllList().FirstOrDefault(stu => stu.Name == name);
            if (student == null)
                throw new StudentNotExistException(name);
            if (!_passwordManager.ChackPassword(name, password)) return BadRequest("Password Incorrect.");
           
            return Ok($"Final mark of {name} is: {_gradeManager.CalculateFinalGradePerStudent(student.ID)}. ");
        }
    }
}
