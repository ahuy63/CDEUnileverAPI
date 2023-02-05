using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDEUnileverAPI.Migrations
{
    /// <inheritdoc />
    public partial class _2302051520 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Questionaires_QuestionareId",
                table: "Surveys");

            migrationBuilder.RenameColumn(
                name: "QuestionareId",
                table: "Surveys",
                newName: "QuestionnaireId");

            migrationBuilder.RenameIndex(
                name: "IX_Surveys_QuestionareId",
                table: "Surveys",
                newName: "IX_Surveys_QuestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Questionaires_QuestionnaireId",
                table: "Surveys",
                column: "QuestionnaireId",
                principalTable: "Questionaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Questionaires_QuestionnaireId",
                table: "Surveys");

            migrationBuilder.RenameColumn(
                name: "QuestionnaireId",
                table: "Surveys",
                newName: "QuestionareId");

            migrationBuilder.RenameIndex(
                name: "IX_Surveys_QuestionnaireId",
                table: "Surveys",
                newName: "IX_Surveys_QuestionareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Questionaires_QuestionareId",
                table: "Surveys",
                column: "QuestionareId",
                principalTable: "Questionaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
