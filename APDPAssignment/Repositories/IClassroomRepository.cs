using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface IClassroomRepository
    {
        IEnumerable<Classroom> Classroom { get; }
        Classroom GetClassroomById(int classroomId);
        bool AddClassroom(Classroom classroom);
        bool UpdateClassroom(Classroom classroom);
        bool DeleteClassroom(int classroomId);
    }
}
