using System.ComponentModel.DataAnnotations;

namespace Prexam.DTOs
{
    public class UserResponse
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}