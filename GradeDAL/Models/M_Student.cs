using GradeDO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace GradeDAL.Models
{
    public class M_Student
    {
        [BindRequired, MaxLength(10)]        
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<M_Grade> M_ExeList { get; set; }
        public M_Grade M_TestGrade { get; set; }

        public Student StudentBuilder()
        {
            List<Grade> exeList = new List<Grade>();
            M_ExeList.ForEach(grade => exeList.Add(grade.GradeBuilder()));
            return new Student { ID =this.ID, Name = this.Name, Password = this.ID, ExeList = exeList, TestGrade = this.M_TestGrade.GradeBuilder() };
        }
    }
}
