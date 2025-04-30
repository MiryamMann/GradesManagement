using GradeDO.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO
{
    public class Students:IStudents
    {
        DataSource studentsList = new DataSource();
        public Students()
        {
            studentsList.Initialize();
        }
        public void AddStudent(Student student)
        {
            if (studentsList.Students.Any(stu => stu.ID == student.ID))
                throw new StudentAlreadyExistException(student.ID);
            student.Password = student.ID;
            studentsList.Students.Add(student);
            
        }
        public void RemoveStudent(string studentID)
        {
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == studentID);
            if (student == null)
                throw new StudentNotExistException(studentID);
            studentsList.Students.Remove(student);
        }
        public string DisplayStudent(string studentID)
        {
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == studentID);
            if (student == null)
                throw new StudentNotExistException(studentID);
            return student.ToString();
        }
        public string DisplayAll()
        {
            string s = "";
            foreach (Student student in studentsList.Students) { s += (student.ToString() + "\n"); }
            return s;
        }
        public List<Student> DisplayAllList()
        {
            return studentsList.Students;
        }
        public void AddGradeToStudent(string StudentId, Grade grade)
        {
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == StudentId);
            if(student == null) 
                throw new StudentNotExistException(StudentId);
            grade.Date = DateTime.Today;
            student.ExeList.Add(grade);
        }
        public void AddGradeToAll(List<string> studentsID, List<Grade> grades)
        {
            for (int i = 0; i < studentsID.Count; i++) {
                AddGradeToStudent(studentsID[i], grades[i]);
            }
  
        }
        public void updateGradeForStudent(string StudentId, int mark, int exeNumber) {
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == StudentId);
            if (student == null)
                throw new StudentNotExistException(StudentId);
            Grade grade = student.ExeList.FirstOrDefault(grade => grade.ExeNumber == exeNumber);
            if (grade == null)
                throw new Exception($"No Such grade {exeNumber} for student {StudentId}.");
            grade.Mark = mark;

        }
        public string GetGradeForStudent(string StudentId, int exeNumber) {
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == StudentId);
            if (student == null)
                throw new StudentNotExistException(StudentId);
            Grade grade = student.ExeList.FirstOrDefault(grade => grade.ExeNumber == exeNumber);
            if (grade == null)
                throw new Exception($"No Such grade {exeNumber} for student {StudentId}.");
            return grade.ToString();
        }
        public void EditStudent(Student student) {
            Student s = studentsList.Students.FirstOrDefault(stu => stu.ID == student.ID);
            if (s == null)
                throw new StudentNotExistException(student.ID);
            studentsList.Students.FirstOrDefault(stu => stu.ID == student.ID).Name = student.Name;

        }


    }

    
}
