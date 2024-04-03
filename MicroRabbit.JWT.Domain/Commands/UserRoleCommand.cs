using MicroRabbit.Domain.Core.Commands;

namespace MicroRabbit.JWT.Domain.Commands
{
    public class CreateUserRoleCommand : Command
    {
        public string RoleName { get; protected set; }
        // Otros campos necesarios para la creación de un rol de usuario

        public CreateUserRoleCommand(string roleName)
        {
            RoleName = roleName;
        }
    }

    public class DeleteUserRoleCommand : Command
    {
        public int UserRoleId { get; protected set; }

        public DeleteUserRoleCommand(int userRoleId)
        {
            UserRoleId = userRoleId;
        }
    }
}