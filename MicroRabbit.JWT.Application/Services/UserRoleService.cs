using MicroRabbit.JWT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using MicroRabbit.JWT.Data.Context;
using MicroRabbit.JWT.Domain.Models;

namespace MicroRabbit.JWT.Data.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly UserDbContext _context;

        public UserRoleRepository(UserDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<UserRole> GetUserRoles()
        {
            return _context.UserRoles;
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

        public void DeleteUserRole(int id)
        {
            var userRole = _context.UserRoles.Find(id);
            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                _context.SaveChanges();
            }
        }

        public void UpdateUserRole(UserRole userRole)
        {
            throw new NotImplementedException();
        }
    }
}