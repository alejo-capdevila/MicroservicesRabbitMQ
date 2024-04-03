
using MicroRabbit.JWT.Domain.Models;

namespace MicroRabbit.JWT.Application.Interfaces{
public interface IUserRoleService

{
    IEnumerable<UserRole> GetUserRoles();
    UserRole GetUserRoleById(int id);
    void CreateUserRole(string roleName);
    void DeleteUserRole(int userRoleId);
}
}