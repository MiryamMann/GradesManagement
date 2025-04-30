using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO
{
    public interface IStudents
    {
        
        public void AddStudent(Student student);
        public void RemoveStudent(string studentID);
        public string DisplayStudent(string studentID);
        public string DisplayAll();
        public List<Student> DisplayAllList();
        public void AddGradeToStudent(string StudentId, Grade grade);
        public void AddGradeToAll(List<string> studentsID, List<Grade> grades);
        public void updateGradeForStudent(string StudentId, int mark, int exeNumber);
        public string GetGradeForStudent(string StudentId, int exeNumber);
        public void EditStudent(Student student);

    }
}
