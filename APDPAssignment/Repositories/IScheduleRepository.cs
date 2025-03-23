using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface IScheduleRepository
    {
        IEnumerable<Schedule> Schedules { get; }
        Schedule GetScheduleById(int scheduleId);
        bool AddSchedule(Schedule schedule);
        bool UpdateSchedule(Schedule schedule);
        bool DeleteSchedule(int scheduleId);
    }
}
