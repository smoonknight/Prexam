using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prexam.Migrations
{
    /// <inheritdoc />
    public partial class FixForeign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Exams_CollectionCode",
                table: "Exams",
                column: "CollectionCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Collections_CollectionCode",
                table: "Exams",
                column: "CollectionCode",
                principalTable: "Collections",
                principalColumn: "CollectionCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Collections_CollectionCode",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_CollectionCode",
                table: "Exams");
        }
    }
}
