using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Prexam.Models
{
    public class ExamSession
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public LevelType MaximumLevelType { get; set; } = LevelType.Hard;


        [ForeignKey("Collection")]
        public Guid CollectionCode { get; set; }
        public virtual Collection Collection { get; set; } = null!;

        public int Duration { get; set; }
        public int TotalExam { get; set; }

        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime? EndTime { get; set; }

        public ExamSessionStatus Status { get; set; }

        public ICollection<ExamSessionAnswer> ExamSessionAnswers { get; set; } = [];
    }

    public enum ExamSessionStatus
    {
        Active,
        Completed,
        Expired
    }
}