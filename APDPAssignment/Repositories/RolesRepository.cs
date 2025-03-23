using APDPAssignment.Data;
using APDPAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace APDPAssignment.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly ApplicationDbContext _context;

        public RolesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Roles> GetRoles()
        {
            try
            {
                return _context.Roles.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Roles GetRole(int id)
        {
            try
            {
                return _context.Roles.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddRole(Roles role)
        {
            try
            {
                _context.Roles.Add(role);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateRole(Roles role)
        {
            try
            {
                _context.Entry(role).State = EntityState.Modified;
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteRole(int id)
        {
            try
            {
                var role = _context.Roles.Find(id);
                _context.Roles.Remove(role);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
