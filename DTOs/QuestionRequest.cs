using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Prexam.Models;

namespace Prexam.DTOs
{
    public class QuestionRequest : Request
    {
        public Guid CollectionCode { get; set; }
        [Required]
        public string Description { get; set; } = "";
        [Required]
        public string[] Options { get; set; } = [];
        [Required]
        public int Answer { get; set; }
        public string Explanation = "";
        public string? Subject { get; set; }
        public LevelType? LevelType { get; set; }
    }
}