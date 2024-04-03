using System.Threading.Tasks;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.JWT.Domain.Events;
using MicroRabbit.JWT.Domain.Interfaces;
using MicroRabbit.JWT.Domain.Models;

namespace MicroRabbit.JWT.Domain.EventHandlers
{
    public class UserRoleEventHandler : IEventHandler<UserRoleCreatedEvent>,
        IEventHandler<UserRoleDeletedEvent>
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleEventHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public Task Handle(UserRoleCreatedEvent @event)
        {
            // Logic to handle user role creation event
            return Task.CompletedTask;
        }

        public Task Handle(UserRoleDeletedEvent @event)
        {
            // Logic to handle user role deletion event
            return Task.CompletedTask;
        }
    }
}