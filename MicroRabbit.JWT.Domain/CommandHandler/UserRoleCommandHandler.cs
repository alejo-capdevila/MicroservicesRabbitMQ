using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.JWT.Domain.Commands;

namespace MicroRabbit.JWT.Domain.CommandHandlers
{
    public class UserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, bool>,
        IRequestHandler<DeleteUserRoleCommand, bool>
    {
        private readonly IEventBus _bus;

        public UserRoleCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public async Task<bool> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            //_userRoleService.CreateUserRole(request.RoleName);
            //// Publicar un evento de rol de usuario creado si es necesario
            ////_bus.Publish(new UserRoleCreatedEvent(request.RoleName)); // Ejemplo de evento
            return true;
        }

        public async Task<bool> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            //_userRoleService.DeleteUserRole(request.UserRoleId);
            //// Publicar un evento de rol de usuario eliminado si es necesario
            //_bus.Publish(new UserRoleDeletedEvent(request.UserRoleId)); // Ejemplo de evento
            return true;
        }
    }
}