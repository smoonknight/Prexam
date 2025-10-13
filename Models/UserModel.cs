using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Prexam.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}