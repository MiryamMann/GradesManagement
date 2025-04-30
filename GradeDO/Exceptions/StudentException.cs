using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO.Exceptions
{
    public class StudentNotExistException : Exception
    {
        public int StatusCode { get; }
        public StudentNotExistException(string StudentId):base($"The student with Id {StudentId} does not exist")
        {
            StatusCode = 790;
        }
        
    }
    public class StudentAlreadyExistException  : Exception
    {
        public int StatusCode { get; }
        public StudentAlreadyExistException(string StudentId) : base($"The student with Id {StudentId} already exist")
        {
            StatusCode = 800;
        }

    }
}
