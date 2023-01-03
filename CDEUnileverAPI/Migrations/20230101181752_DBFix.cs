using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDEUnileverAPI.Migrations
{
    /// <inheritdoc />
    public partial class DBFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Distributors_Area_AreaId",
                table: "Areas_Distributors");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Distributors_Distributors_DistributorId",
                table: "Areas_Distributors");

            migrationBuilder.DropIndex(
                name: "IX_Areas_Distributors_DistributorId",
                table: "Areas_Distributors");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "Areas_Distributors");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Areas_Distributors",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Areas_Distributors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistributorsId",
                table: "Areas_Distributors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Distributors_DistributorsId",
                table: "Areas_Distributors",
                column: "DistributorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Distributors_Area_AreaId",
                table: "Areas_Distributors",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Distributors_Distributors_DistributorsId",
                table: "Areas_Distributors",
                column: "DistributorsId",
                principalTable: "Distributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Distributors_Area_AreaId",
                table: "Areas_Distributors");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Distributors_Distributors_DistributorsId",
                table: "Areas_Distributors");

            migrationBuilder.DropIndex(
                name: "IX_Areas_Distributors_DistributorsId",
                table: "Areas_Distributors");

            migrationBuilder.DropColumn(
                name: "DistributorsId",
                table: "Areas_Distributors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Areas_Distributors",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Areas_Distributors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "Areas_Distributors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Distributors_DistributorId",
                table: "Areas_Distributors",
                column: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Distributors_Area_AreaId",
                table: "Areas_Distributors",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Distributors_Distributors_DistributorId",
                table: "Areas_Distributors",
                column: "DistributorId",
                principalTable: "Distributors",
                principalColumn: "Id");
        }
    }
}
