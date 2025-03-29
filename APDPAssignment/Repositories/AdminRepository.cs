using APDPAssignment.Data;
using APDPAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace APDPAssignment.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Admin GetAdmin(int id)
        {
            try
            {
                return _context.Admin.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            try
            {
                return _context.Admin.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Admin>();
            }
        }

        public bool AddAdmin(Admin admin)
        {
            try
            {
                _context.Admin.Add(admin);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateAdmin(Admin adminChanges)
        {
            try
            {
                _context.Admin.Update(adminChanges);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteAdmin(int id)
        {
            try
            {
                var admin = _context.Admin.Find(id);
                if (admin != null)
                {
                    _context.Admin.Remove(admin);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
