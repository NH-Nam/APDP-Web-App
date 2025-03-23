using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface IRolesRepository
    {
        IEnumerable<Roles> GetRoles();
        Roles GetRole(int id);
        bool AddRole(Roles roles);
        bool UpdateRole(Roles roles);
        bool DeleteRole(int id);
    }
}
