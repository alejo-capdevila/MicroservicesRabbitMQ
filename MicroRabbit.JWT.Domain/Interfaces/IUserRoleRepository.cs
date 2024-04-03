using MicroRabbit.JWT.Domain.Models;
using System.Collections.Generic;

namespace MicroRabbit.JWT.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}