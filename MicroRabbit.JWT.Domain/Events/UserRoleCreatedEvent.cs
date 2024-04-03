using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.JWT.Domain.Models
{
    public class UserRoleCreatedEvent : Event
    {
        public int UserRoleId { get; private set; }
        public string RoleName { get; private set; }

        public UserRoleCreatedEvent(int userRoleId, string roleName)
        {
            UserRoleId = userRoleId;
            RoleName = roleName;
        }
    }

    public class UserRoleDeletedEvent : Event
    {
        public int UserRoleId { get; private set; }

        public UserRoleDeletedEvent(int userRoleId)
        {
            UserRoleId = userRoleId;
        }
    }
}