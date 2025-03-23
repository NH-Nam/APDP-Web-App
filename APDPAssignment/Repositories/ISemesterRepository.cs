using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface ISemesterRepository
    {
        IEnumerable<Semester> GetAllSemesters();
        Semester GetSemesterById(int id);
        bool AddSemester(Semester semester);
        bool UpdateSemester(Semester semester);
        bool DeleteSemester(int id);
    }
}
