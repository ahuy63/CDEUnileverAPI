using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDEUnileverAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixloichinhtaQuestionaire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionaireDetails_Questionares_QuestionareId",
                table: "QuestionaireDetails");

            migrationBuilder.DropTable(
                name: "Questionares");

            migrationBuilder.DropIndex(
                name: "IX_QuestionaireDetails_QuestionareId",
                table: "QuestionaireDetails");

            migrationBuilder.AddColumn<int>(
                name: "QuestionaireId",
                table: "QuestionaireDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Questionaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfQuestions = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionaires", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionaireDetails_QuestionaireId",
                table: "QuestionaireDetails",
                column: "QuestionaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionaireDetails_Questionaires_QuestionaireId",
                table: "QuestionaireDetails",
                column: "QuestionaireId",
                principalTable: "Questionaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionaireDetails_Questionaires_QuestionaireId",
                table: "QuestionaireDetails");

            migrationBuilder.DropTable(
                name: "Questionaires");

            migrationBuilder.DropIndex(
                name: "IX_QuestionaireDetails_QuestionaireId",
                table: "QuestionaireDetails");

            migrationBuilder.DropColumn(
                name: "QuestionaireId",
                table: "QuestionaireDetails");

            migrationBuilder.CreateTable(
                name: "Questionares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfQuestions = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionares", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionaireDetails_QuestionareId",
                table: "QuestionaireDetails",
                column: "QuestionareId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionaireDetails_Questionares_QuestionareId",
                table: "QuestionaireDetails",
                column: "QuestionareId",
                principalTable: "Questionares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
