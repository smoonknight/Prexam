using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prexam.Models
{
    public class Collection
    {
        [Key]
        public Guid CollectionCode { get; set; }
        // [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
    }
}