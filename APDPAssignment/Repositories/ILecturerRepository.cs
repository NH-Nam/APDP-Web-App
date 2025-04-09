using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface ILecturerRepository
    {
        IEnumerable<Lecturer> GetAllLecturers();
        Lecturer GetLecturerById(int lecturerId);
        bool AddLecturer(Lecturer lecturer);
        bool UpdateLecturer(Lecturer lecturer);
        bool DeleteLecturer(int lecturerId);
    }
}
