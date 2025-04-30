using GradeDAL.Configurations;
using GradeDO;
using Microsoft.Extensions.Options;

namespace GradeDAL.Services
{
    public class PasswordManager:IPasswordManager
    {
        public IStudents students;
        public Teacher _teacher;
        string teacherName;
        string teacherPassword;
        
        public PasswordManager(IStudents s, IOptions<Teacher> teacher)
        {
            students = s;
            _teacher = teacher.Value;
            teacherName = _teacher.Name;
            teacherPassword = _teacher.Password;
        }
        public bool ChackPassword(string name, string password)
        {
            if (name.Equals(teacherName))
            {
                if (password.Equals(teacherPassword))
                    return true;
                return false;
            }
            Student student = students.DisplayAllList().FirstOrDefault(stu => stu.Name == name);
            if (student.Password.Equals(password))
                return true;
            return false;

        }

    }
}
