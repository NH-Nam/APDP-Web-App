using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface IAcademicRecordsRepository
    {
        IEnumerable<AcademicRecords> GetAllAcademicRecords();
        AcademicRecords GetAcademicRecordsById(int id);
        bool AddAcademicRecords(AcademicRecords academicRecords);
        bool UpdateAcademicRecords(AcademicRecords academicRecords);
        bool DeleteAcademicRecords(int id);
    }
}
