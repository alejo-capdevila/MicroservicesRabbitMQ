using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.JWT.Application.Interfaces;
using MicroRabbit.JWT.Domain.Commands;
using MicroRabbit.JWT.Domain.Interfaces;
using MicroRabbit.JWT.Domain.Models;

namespace MicroRabbit.BakingApplication.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _UserRepository;
        private readonly IEventBus _bus;

        public UserService(IUserRepository UserRepository, IEventBus bus)
        {
            _UserRepository = UserRepository;
            _bus = bus;

        }

        public void CreateUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _UserRepository.GetUsers();
        }

        public void Transfer(UserCreate userCreate)
        {
            var createTransferCommand = new CreateUserCommand(
                userCreate.UserName,
                userCreate.Password);

            _bus.SendCommand(createTransferCommand);
        }

        public void UpdateUser(int userId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUserService.GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}