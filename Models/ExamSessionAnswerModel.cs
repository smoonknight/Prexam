using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prexam.Models
{
    public class ExamSessionAnswer
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("ExamSession")]
        public Guid ExamSessionId { get; set; }
        public virtual ExamSession ExamSession { get; set; } = null!;

        public string Question { get; set; } = "";
        public string[] Options { get; set; } = [];
        public int Answer { get; set; }
        public string Explanation = "";

        public int SelectedOptionIndex { get; set; } = -1;
    }
}
