using APDPAssignment.Data;
using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationDbContext _context;

        public ScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Schedule> GetAllSchedules()
        {
            try
            {
                return _context.Schedules.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Schedule GetScheduleById(int scheduleId)
        {
            try
            {
                return _context.Schedules.Find(scheduleId);
            }
            catch
            {
                return null;
            }
        }

        public bool AddSchedule(Schedule schedule)
        {
            try
            {
                _context.Schedules.Add(schedule);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSchedule(Schedule schedule)
        {
            try
            {
                _context.Schedules.Update(schedule);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSchedule(int scheduleId)
        {
            try
            {
                var schedule = _context.Schedules.Find(scheduleId);
                _context.Schedules.Remove(schedule);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
