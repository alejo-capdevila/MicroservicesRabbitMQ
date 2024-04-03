using MicroRabbit.JWT.Domain.Models;
using System.Collections.Generic;

namespace MicroRabbit.JWT.Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void CreateUser(string userName, string password);
        void UpdateUser(int userId);
        void DeleteUser(int userId);
    }
}