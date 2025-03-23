using APDPAssignment.Data;
using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public class AcademicRecordsRepository : IAcademicRecordsRepository
    {
        private readonly ApplicationDbContext _context;

        public AcademicRecordsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AcademicRecords> GetAllAcademicRecords()
        {
            try
            {
                return _context.AcademicRecords.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AcademicRecords GetAcademicRecordsById(int id)
        {
            try
            {
                return _context.AcademicRecords.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddAcademicRecords(AcademicRecords academicRecords)
        {
            try
            {
                _context.AcademicRecords.Add(academicRecords);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateAcademicRecords(AcademicRecords academicRecords)
        {
            try
            {
                _context.AcademicRecords.Update(academicRecords);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteAcademicRecords(int id)
        {
            try
            {
                var academicRecords = _context.AcademicRecords.Find(id);
                _context.AcademicRecords.Remove(academicRecords);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
