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

        // New method to update academic record for a student in a course
        bool UpdateStudentScore(int studentId, int courseId, string grade, string status);
    }
}
