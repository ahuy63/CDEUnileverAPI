using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDEUnileverAPI.Migrations
{
    /// <inheritdoc />
    public partial class _2301261615 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionaireDetails_Questionaires_QuestionaireId",
                table: "QuestionaireDetails");

            migrationBuilder.DropIndex(
                name: "IX_QuestionaireDetails_QuestionaireId",
                table: "QuestionaireDetails");

            migrationBuilder.DropColumn(
                name: "QuestionaireId",
                table: "QuestionaireDetails");

            migrationBuilder.RenameColumn(
                name: "QuestionarePart",
                table: "QuestionaireDetails",
                newName: "QuestionnairePart");

            migrationBuilder.RenameColumn(
                name: "QuestionareId",
                table: "QuestionaireDetails",
                newName: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionaireDetails_QuestionnaireId",
                table: "QuestionaireDetails",
                column: "QuestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionaireDetails_Questionaires_QuestionnaireId",
                table: "QuestionaireDetails",
                column: "QuestionnaireId",
                principalTable: "Questionaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionaireDetails_Questionaires_QuestionnaireId",
                table: "QuestionaireDetails");

            migrationBuilder.DropIndex(
                name: "IX_QuestionaireDetails_QuestionnaireId",
                table: "QuestionaireDetails");

            migrationBuilder.RenameColumn(
                name: "QuestionnairePart",
                table: "QuestionaireDetails",
                newName: "QuestionarePart");

            migrationBuilder.RenameColumn(
                name: "QuestionnaireId",
                table: "QuestionaireDetails",
                newName: "QuestionareId");

            migrationBuilder.AddColumn<int>(
                name: "QuestionaireId",
                table: "QuestionaireDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
