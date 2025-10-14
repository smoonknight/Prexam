using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prexam.Migrations
{
    /// <inheritdoc />
    public partial class _20251014201333 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamSession_Collections_CollectionCode",
                table: "ExamSession");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSessionAnswer_ExamSession_ExamSessionId",
                table: "ExamSessionAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamSessionAnswer",
                table: "ExamSessionAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamSession",
                table: "ExamSession");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "ExamSessionAnswer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExamSession");

            migrationBuilder.RenameTable(
                name: "ExamSessionAnswer",
                newName: "ExamSessionAnswers");

            migrationBuilder.RenameTable(
                name: "ExamSession",
                newName: "ExamSessions");

            migrationBuilder.RenameIndex(
                name: "IX_ExamSessionAnswer_ExamSessionId",
                table: "ExamSessionAnswers",
                newName: "IX_ExamSessionAnswers_ExamSessionId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamSession_CollectionCode",
                table: "ExamSessions",
                newName: "IX_ExamSessions_CollectionCode");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "ExamSessions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamSessionAnswers",
                table: "ExamSessionAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamSessions",
                table: "ExamSessions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSessionAnswers_ExamSessions_ExamSessionId",
                table: "ExamSessionAnswers",
                column: "ExamSessionId",
                principalTable: "ExamSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSessions_Collections_CollectionCode",
                table: "ExamSessions",
                column: "CollectionCode",
                principalTable: "Collections",
                principalColumn: "CollectionCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamSessionAnswers_ExamSessions_ExamSessionId",
                table: "ExamSessionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSessions_Collections_CollectionCode",
                table: "ExamSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamSessions",
                table: "ExamSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamSessionAnswers",
                table: "ExamSessionAnswers");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "ExamSessions");

            migrationBuilder.RenameTable(
                name: "ExamSessions",
                newName: "ExamSession");

            migrationBuilder.RenameTable(
                name: "ExamSessionAnswers",
                newName: "ExamSessionAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_ExamSessions_CollectionCode",
                table: "ExamSession",
                newName: "IX_ExamSession_CollectionCode");

            migrationBuilder.RenameIndex(
                name: "IX_ExamSessionAnswers_ExamSessionId",
                table: "ExamSessionAnswer",
                newName: "IX_ExamSessionAnswer_ExamSessionId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ExamSession",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "ExamSessionAnswer",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamSession",
                table: "ExamSession",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamSessionAnswer",
                table: "ExamSessionAnswer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSession_Collections_CollectionCode",
                table: "ExamSession",
                column: "CollectionCode",
                principalTable: "Collections",
                principalColumn: "CollectionCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSessionAnswer_ExamSession_ExamSessionId",
                table: "ExamSessionAnswer",
                column: "ExamSessionId",
                principalTable: "ExamSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
