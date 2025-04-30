using GradeDO.Exceptions;
using GradeDO;
using Microsoft.Extensions.Options;
using GradeDAL.Configurations;
using GradeDAL.HelpClasses;
using Microsoft.AspNetCore.Mvc;
using GradesProject.Configuration;

namespace GradeDAL.Services
{
    public class GradeManager:IGradeManager
    {
        public IStudents _students;
        public List<GradePercent> _percent; 
        public GradeManager(IStudents s, IOptions<List<GradePercent>> percent)
        {
            _students = s;
            _percent = percent.Value;
        }
        

        public double CalculateFinalGradePerStudent(string id)
        {
            double finalGrade = 0;
            Student student = _students.DisplayAllList().Find(s => s.ID == id);
            if (student != null)
            {
                foreach (Grade grade in student.ExeList)
                {
                    finalGrade += (grade.ExeNumber * _percent.Find(p => p.ExeNumber == grade.ExeNumber).Percent) / 100;
                }
                finalGrade += student.TestGrade.ExeNumber * _percent.Find(p => p.ExeNumber == 99).Percent / 100;
                return finalGrade;
            }
            throw new StudentNotExistException(id);
        }
        public List<Students_FinalMarks> CalculateFinalGradeForAll()
        {
            List<Students_FinalMarks> StudentsFinalMarks =new();
            foreach (var student in _students.DisplayAllList())
            {
                StudentsFinalMarks.Add(new Students_FinalMarks() { Student = student, FinalMark = CalculateFinalGradePerStudent(student.ID) });
            }
            return StudentsFinalMarks;
           
        }
        public double AverageForGivenExe(int num)
        {
            int sumMarks = 0;
            if (num == 99) {
                foreach (var student in _students.DisplayAllList())
                {
                    sumMarks += student.TestGrade.Mark;
                }
                
            }
            foreach (var student in _students.DisplayAllList())
            {
               
                sumMarks += student.ExeList.Where(e => e.ExeNumber == num).Sum(e => e.Mark);

            }
            return sumMarks / _students.DisplayAllList().Count;

        }
        public string DisplayAllGrades()
        {
            string s = string.Empty;

            _percent.ForEach(exercise => {
                s += exercise.ExeNumber.ToString() + ": \n";

                _students.DisplayAllList().ForEach(student => {
                    Grade g = student.ExeList.FirstOrDefault(g => g.ExeNumber == exercise.ExeNumber);
                    if (g != null)
                    {
                        s += student.Name + " : " + g.Mark.ToString() + "\n";
                    }
                });
            });

            return s;
        }

        
    }
}
