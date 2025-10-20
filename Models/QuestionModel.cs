using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Prexam.Models
{
    public class Question : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; } = "";
        public string[] Options { get; set; } = [];
        public int Answer { get; set; }
        public string Explanation = "";
        public string? Subject { get; set; }
        public LevelType? LevelType { get; set; }

        [ForeignKey("Collection")]
        public Guid CollectionCode { get; set; }

        [JsonIgnore]
        public virtual Collection Collection { get; set; } = null!;
    }

    public enum LevelType
    {
        Easy,
        Medium,
        Hard
    }
}

