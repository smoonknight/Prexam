using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prexam.Migrations
{
    /// <inheritdoc />
    public partial class _20251016155921 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalExam",
                table: "ExamSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalExam",
                table: "ExamSessions");
        }
    }
}
