namespace GradeDAL.Services
{
    public interface IPasswordManager
    {
        public bool ChackPassword(string name, string password);
    }
}
