using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO
{
    public class Grade
    {
        public int ExeNumber { get; set; }//1 ,2 99= for the test
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }
        public string Comment { get; set; }

        public override string ToString()
        {
            return $" Exercise number: {ExeNumber}, Exercise name: {Name} , Date: {Date}, Grade: {Mark}, Comment: {Comment}";
        }
    }
}
