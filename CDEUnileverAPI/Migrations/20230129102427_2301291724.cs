using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDEUnileverAPI.Migrations
{
    /// <inheritdoc />
    public partial class _2301291724 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "JobTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_CreatedById",
                table: "JobTasks",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Users_CreatedById",
                table: "JobTasks",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Users_CreatedById",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_CreatedById",
                table: "JobTasks");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "JobTasks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "JobTasks");
        }
    }
}
