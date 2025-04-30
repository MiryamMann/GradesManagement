using GradeDAL.HelpClasses;

namespace GradeDAL.Services
{
    public interface IGradeManager
    {

        public double CalculateFinalGradePerStudent(string id);
        public List<Students_FinalMarks> CalculateFinalGradeForAll();
        public double AverageForGivenExe(int num);
        public string DisplayAllGrades();
    }
}
