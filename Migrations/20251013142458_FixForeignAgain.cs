using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prexam.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Collections_CollectionCode",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_CollectionCode",
                table: "Exams");

            migrationBuilder.AddColumn<Guid>(
                name: "CollectionCode1",
                table: "Exams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CollectionCode1",
                table: "Exams",
                column: "CollectionCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Collections_CollectionCode1",
                table: "Exams",
                column: "CollectionCode1",
                principalTable: "Collections",
                principalColumn: "CollectionCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Collections_CollectionCode1",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_CollectionCode1",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "CollectionCode1",
                table: "Exams");

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
    }
}
