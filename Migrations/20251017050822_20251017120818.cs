using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prexam.Migrations
{
    /// <inheritdoc />
    public partial class _20251017120818 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Exams",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Exams",
                newName: "Question");
        }
    }
}
