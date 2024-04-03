using System.ComponentModel.DataAnnotations;

namespace MicroRabbit.JWT.Domain.Models
{
    public class User
    {
        [Key] public int Id { get; set; }

        [Required] [MaxLength(50)] public string UserName { get; set; }

        [Required]
        [MaxLength(100)] // Adjust the length as needed
        public string PasswordHash { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }

        [MaxLength(100)] public string FullName { get; set; }

        [Required] public bool IsActive { get; set; }

        [Required] public DateTime CreatedAt { get; set; }

        [Required] public DateTime UpdatedAt { get; set; }

        public DateTime LastLogin { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}