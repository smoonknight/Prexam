using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prexam.Models
{
    public class Exam
    {
        [Key]
        public Guid Id { get; set; }
        // [ForeignKey("Collection")]
        public Guid CollectionCode { get; set; }
        public virtual Collection Collection { get; set; } = null!;
        public string Question { get; set; } = "";
        public required string[] Options { get; set; }
        public required int Answer { get; set; }
        public string Explanation = "";
        public string? Subject { get; set; }
        public LevelType? LevelType { get; set; }
    }

    public enum LevelType
    {
        Easy,
        Medium,
        Hard
    }
}

