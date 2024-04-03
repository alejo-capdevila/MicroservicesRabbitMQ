using MicroRabbit.JWT.Domain.Interfaces;
using MicroRabbit.JWT.Data.Context;
using MicroRabbit.JWT.Domain.Models;

namespace MicroRabbit.JWT.Data.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly UserDbContext _context;

        public UserRoleRepository(UserDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserRole> GetUserRoles()
        {
            return _context.UserRoles.ToList();
        }

        public UserRole GetUserRoleById(int id)
        {
            return _context.UserRoles.Find(id);
        }

        public void AddUserRole(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
        }

        public void UpdateUserRole(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            _context.SaveChanges();
        }

        public void DeleteUserRole(int id)
        {
            var UserRole = _context.UserRoles.Find(id);
            if (UserRole != null)
            {
                _context.UserRoles.Remove(UserRole);
                _context.SaveChanges();
            }
        }
    }
}