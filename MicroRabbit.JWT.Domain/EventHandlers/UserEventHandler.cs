using System.Threading.Tasks;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.JWT.Domain.Events;
using MicroRabbit.JWT.Domain.Interfaces;

namespace MicroRabbit.JWT.Domain.EventHandlers
{
    public class UserEventHandler : IEventHandler<UserCreatedEvent>,
        IEventHandler<UserUpdatedEvent>,
        IEventHandler<UserDeletedEvent>
    {
        private readonly IUserRepository _userRepository;

        public UserEventHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task Handle(UserCreatedEvent @event)
        {
            // Logic to handle user creation event
            return Task.CompletedTask;
        }

        public Task Handle(UserUpdatedEvent @event)
        {
            // Logic to handle user update event
            return Task.CompletedTask;
        }

        public Task Handle(UserDeletedEvent @event)
        {
            // Logic to handle user deletion event
            return Task.CompletedTask;
        }
    }
}