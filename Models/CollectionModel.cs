using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Prexam.Models
{
    public class Collection : BaseEntity
    {
        [Key]
        public Guid CollectionCode { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;

        [JsonIgnore]
        public ICollection<Exam> Exams { get; set; } = [];
        [JsonIgnore]
        public ICollection<ExamSession> ExamSessions { get; set; } = [];
    }
}