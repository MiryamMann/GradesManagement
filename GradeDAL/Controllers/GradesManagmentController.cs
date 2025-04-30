using GradeDAL.Configurations;
using GradeDAL.Models;
using GradeDAL.Services;
using GradeDO;
using GradesProject.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace GradeDAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesManagmentController : ControllerBase
    {
        IStudents _students;
        IGradeManager _gradeManager;
        List<GradePercent> _exeNumbers;
        ILogger<GradesManagmentController> _logger;

        public GradesManagmentController(ILogger<GradesManagmentController> logger, IStudents students,IGradeManager gradeManager, IOptions<List<GradePercent>> exeNumbers)
        {
            _students = students;
            _gradeManager = gradeManager;
            _exeNumbers = exeNumbers.Value;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddMarkForAllStudents([FromQuery ]List<string> studentsID,[FromBody] List<M_Grade> m_grades) {
            _logger.LogInformation($"Adding mark number {m_grades[1].ExeNumber} to all students.");
            List<Grade> grades=new List<Grade>();
            m_grades.ForEach(grade => grades.Add(grade.GradeBuilder()));
            _students.AddGradeToAll(studentsID, grades );
           
            return Ok("Added the marks to all the students.");

        
        }
        [HttpPost("{id}")]
        public IActionResult UpdateMarkOfStudent([FromRoute]string id,[FromQuery]int mark, [FromQuery] int exNumber)
        {
            _logger.LogInformation($"Updating mark number {exNumber} to student {id}.");
            _students.updateGradeForStudent(id, mark, exNumber);
            return Ok($"Added the mark{mark} to Exercise number {exNumber} for student {id}.");

        }

        [HttpGet]
        public IActionResult DisplayMarksForExercise([FromQuery] int exeNum)
        {
            _logger.LogInformation($"Displaying all marks of exercise {exeNum} of all students.");
            List<string> marks=new List<string>();
            _students.DisplayAllList().ForEach(student => { marks.Add(_students.GetGradeForStudent(student.ID, exeNum)); });
            return Ok(marks);
        }
        [HttpGet("byId")]
        public IActionResult CalculateFinalGradePerStudent([FromQuery]string id)
        {
            _logger.LogInformation($"Calculating final grade fro student {id}.");
            return Ok(_gradeManager.CalculateFinalGradePerStudent(id));
        }
        [HttpGet("DisplayAllGrades")]
        public IActionResult DisplayAllGrades()
        {
            _logger.LogInformation($"Displaying all grades for all exercises.");
            return Ok(_gradeManager.DisplayAllGrades());
        }



    }
}
