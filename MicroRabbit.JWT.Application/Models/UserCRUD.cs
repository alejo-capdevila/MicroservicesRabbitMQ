namespace MicroRabbit.JWT.Domain.Models
{
    public class UserCreate
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserUpdate
    {
        public int UserId { get; set; }
        // Add properties to update as needed
    }

    public class UserDelete
    {
        public int UserId { get; set; }
    }
}