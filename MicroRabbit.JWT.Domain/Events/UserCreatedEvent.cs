using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.JWT.Domain.Events
{
    public class UserCreatedEvent : Event
    {
        public int UserId { get; private set; }
        public string Password { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }

        public UserCreatedEvent(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    public class UserUpdatedEvent : Event
    {
        public int UserId { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }

        public UserUpdatedEvent(int userId, string userName, string email)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
        }
    }

    public class UserDeletedEvent : Event
    {
        public int UserId { get; private set; }

        public UserDeletedEvent(int userId)
        {
            UserId = userId;
        }
    }
}