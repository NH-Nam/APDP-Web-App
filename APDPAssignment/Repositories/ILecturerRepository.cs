using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface ILecturerRepository
    {
        IEnumerable<Lecturer> Lecturers { get; }
        Lecturer GetLecturerById(int lecturerId);
        bool AddLecturer(Lecturer lecturer);
        bool UpdateLecturer(Lecturer lecturer);
        bool DeleteLecturer(int lecturerId);
    }
}
