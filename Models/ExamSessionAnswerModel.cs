using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Prexam.Models
{
    public class ExamSessionAnswer
    {
        [Key]
        public Guid Id { get; set; }

        public string Question { get; set; } = "";
        public string[] Options { get; set; } = [];
        public int Answer { get; set; }
        public string Explanation = "";
        public int SelectedOptionIndex { get; set; } = -1;

        [ForeignKey("ExamSession")]
        public Guid ExamSessionId { get; set; }
        [JsonIgnore]
        public virtual ExamSession ExamSession { get; set; } = null!;
    }
}
