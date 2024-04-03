namespace MicroRabbit.JWT.Domain.Models
{
    public class UserRoleCreate
    {
        public string RoleName { get; set; }
        // Add other properties as needed
    }

    public class UserRoleUpdate
    {
        public int UserRoleId { get; set; }
        // Add properties to update as needed
    }

    public class UserRoleDelete
    {
        public int UserRoleId { get; set; }
    }
}