
using GradeDO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
namespace GradeDAL.Models
{
    public class M_Grade
    {
        
        [BindRequired]
        public int ExeNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, 110)]
        public int Mark { get; set; }
        public string Comment { get; set; }

        public Grade GradeBuilder()
        {
            return new Grade { ExeNumber = this.ExeNumber, Name = this.Name, Date = DateTime.Now, Mark = this.Mark, Comment = this.Comment };
        }
    }
}
