using System.ComponentModel.DataAnnotations;

namespace MicroRabbit.JWT.Domain.Models
{
    public class UserRole
    {
        [Key] public int Id { get; set; }

        [Required] [MaxLength(50)] public string RoleName { get; set; }

        // Navigation property
        public List<User> Users { get; set; }
    }
}