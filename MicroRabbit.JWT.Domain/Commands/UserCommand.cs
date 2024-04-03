using MicroRabbit.Domain.Core.Commands;

namespace MicroRabbit.JWT.Domain.Commands
{
    public class CreateUserCommand : Command
    {
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        // Otros campos necesarios para la creación de un usuario

        public CreateUserCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    public class UpdateUserCommand : Command
    {
        public int UserId { get; protected set; }
        // Otros campos necesarios para la actualización de un usuario

        public UpdateUserCommand(int userId)
        {
            UserId = userId;
        }
    }

    public class DeleteUserCommand : Command
    {
        public int UserId { get; protected set; }

        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }
    }
}