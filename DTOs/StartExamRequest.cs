using Prexam.Models;

namespace Prexam.DTOs
{
    public class StartExamRequest
    {
        public string Name { get; set; } = string.Empty;
        public LevelType MaximumLevelType { get; set; }
    }
}