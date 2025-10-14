using System.ComponentModel.DataAnnotations;
using Prexam.Models;

namespace Prexam.DTOs
{
    public class ExamSessionRequest : Request
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public LevelType MaximumLevelType { get; set; } = LevelType.Hard;
    }
}