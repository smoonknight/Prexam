namespace Prexam.Models
{
    public class Exam
    {
        public int Id { get; set; }
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

