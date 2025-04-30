using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO
{
    internal class DataSource
    {
        public List<Student> Students;
        public void Initialize()
        {
            Students = new List<Student>();
            Students.Add(new Student() { ID = "11111111", Name = "Sara", Password = "11111111" });
            Students.Add(new Student() { ID = "22222222", Name = "Rivka", Password = "22222222" });
            Students.Add(new Student() { ID = "33333333", Name = "Rachel", Password = "33333333" });

            Students[0].ExeList.Add(new Grade() { Name = "Controller", ExeNumber = 1, Mark = 100, Comment = "Grate" });
            Students[1].ExeList.Add(new Grade() { Name = "Controller", ExeNumber = 1, Mark = 90, Comment = "Grate" });
            Students[2].ExeList.Add(new Grade() { Name = "Controller", ExeNumber = 1, Mark = 80, Comment = "You can do better" });

            Students[0].ExeList.Add(new Grade() { Name = "ModelBigning", ExeNumber = 2, Mark = 99, Comment = "Grate" });
            Students[1].ExeList.Add(new Grade() { Name = "ModelBigning", ExeNumber = 2, Mark = 76, Comment = ":(" });
            Students[2].ExeList.Add(new Grade() { Name = "ModelBigning", ExeNumber = 2, Mark = 90, Comment = "Good" });

            Students[0].ExeList.Add(new Grade() { Name = "ModelVlidation", ExeNumber = 3, Mark = 92, Comment = "Nice" });
            Students[1].ExeList.Add(new Grade() { Name = "ModelVlidation", ExeNumber = 3, Mark = 80, Comment = ":(" });
            Students[2].ExeList.Add(new Grade() { Name = "ModelVlidation", ExeNumber = 3, Mark = 100, Comment = "!!!" });

            Students[0].TestGrade= new Grade() { Name = "Tets", ExeNumber = 99, Mark = 99, Comment = "Good" };
            Students[1].TestGrade= new Grade() { Name = "Tets", ExeNumber = 99, Mark = 99, Comment = "Good" };
            Students[2].TestGrade= new Grade() { Name = "Tets", ExeNumber = 99, Mark = 99, Comment = "Good" };
        }
    }
}
