using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDEUnileverAPI.Migrations
{
    /// <inheritdoc />
    public partial class _2302061533AddParticipantRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Survey_Participants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Survey_Participants");
        }
    }
}
