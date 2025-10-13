using System.ComponentModel.DataAnnotations;

namespace Prexam.DTOs
{
    public class CollectionRequest : Request
    {
        public Guid UserId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int Duration { get; set; }
    }
}