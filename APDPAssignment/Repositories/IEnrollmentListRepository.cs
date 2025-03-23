using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface IEnrollmentListRepository
    {
        IEnumerable<EnrollmentList> EnrollmentLists { get; }
        EnrollmentList GetEnrollmentListById(int enrollmentId);
        bool AddEnrollmentList(EnrollmentList enrollmentList);
        bool UpdateEnrollmentList(EnrollmentList enrollmentList);
        bool DeleteEnrollmentList(int enrollmentId);
    }
}
