using MicroRabbit.JWT.Domain.Models;

namespace MicroRabbit.JWT.Domain.Interfaces
{
    public interface IUserRoleRepository
    {
        IEnumerable<UserRole> GetUserRoles();
        UserRole GetUserRoleById(int id);
        void AddUserRole(UserRole userRole);
        void UpdateUserRole(UserRole userRole);
        void DeleteUserRole(int id);
    }
}