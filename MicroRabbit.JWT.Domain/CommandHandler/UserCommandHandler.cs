using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.JWT.Domain.Commands;


namespace MicroRabbit.JWT.Domain.CommandHandlers
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, bool>,
        IRequestHandler<UpdateUserCommand, bool>,
        IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IEventBus _bus;

        public UserCommandHandler( IEventBus bus)
        {
            _bus = bus;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //_userService.CreateUser(request.UserName, request.Password);
            //// Publish a user created event
            //_bus.Publish(new UserCreatedEvent(userName: request.UserName,  password: request.Password)); // Example values, replace with actual data
            return true;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //_userService.UpdateUser(request.UserId);
            //// Publicar un evento de usuario actualizado si es necesario
            ////_bus.Publish(new UserUpdatedEvent(request.UserId)); // Ejemplo de evento
            return true;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //_userService.DeleteUser(request.UserId);
            //// Publicar un evento de usuario eliminado si es necesario
            //_bus.Publish(new UserDeletedEvent(request.UserId)); // Ejemplo de evento
            return true;
        }
    }
}