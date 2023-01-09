using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDEUnileverAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixareauserdistributor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Distributors_Distributors_DistributorsId",
                table: "Areas_Distributors");

            migrationBuilder.DropIndex(
                name: "IX_Areas_Distributors_DistributorsId",
                table: "Areas_Distributors");

            migrationBuilder.DropColumn(
                name: "Id_Area",
                table: "Areas_Users");

            migrationBuilder.DropColumn(
                name: "Id_User",
                table: "Areas_Users");

            migrationBuilder.DropColumn(
                name: "DistributorsId",
                table: "Areas_Distributors");

            migrationBuilder.DropColumn(
                name: "Id_Area",
                table: "Areas_Distributors");

            migrationBuilder.RenameColumn(
                name: "Id_Distributor",
                table: "Areas_Distributors",
                newName: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Distributors_DistributorId",
                table: "Areas_Distributors",
                column: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Distributors_Distributors_DistributorId",
                table: "Areas_Distributors",
                column: "DistributorId",
                principalTable: "Distributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Distributors_Distributors_DistributorId",
                table: "Areas_Distributors");

            migrationBuilder.DropIndex(
                name: "IX_Areas_Distributors_DistributorId",
                table: "Areas_Distributors");

            migrationBuilder.RenameColumn(
                name: "DistributorId",
                table: "Areas_Distributors",
                newName: "Id_Distributor");

            migrationBuilder.AddColumn<int>(
                name: "Id_Area",
                table: "Areas_Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_User",
                table: "Areas_Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistributorsId",
                table: "Areas_Distributors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Area",
                table: "Areas_Distributors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Distributors_DistributorsId",
                table: "Areas_Distributors",
                column: "DistributorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Distributors_Distributors_DistributorsId",
                table: "Areas_Distributors",
                column: "DistributorsId",
                principalTable: "Distributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
