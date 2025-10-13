using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prexam.Migrations
{
    /// <inheritdoc />
    public partial class addUniqueOnExamCollectionCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Exams_CollectionCode",
                table: "Exams",
                column: "CollectionCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Exams_CollectionCode",
                table: "Exams");
        }
    }
}
