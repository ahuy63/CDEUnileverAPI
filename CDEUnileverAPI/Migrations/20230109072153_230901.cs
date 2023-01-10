using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDEUnileverAPI.Migrations
{
    /// <inheritdoc />
    public partial class _230901 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_Area_AreaId",
                table: "Distributors");

            migrationBuilder.DropTable(
                name: "Areas_Distributors");

            migrationBuilder.DropTable(
                name: "Areas_Users");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Distributors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_Area_AreaId",
                table: "Distributors",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_Area_AreaId",
                table: "Distributors");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Distributors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Areas_Distributors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    DistributorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas_Distributors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Distributors_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Areas_Distributors_Distributors_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Distributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Users_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Areas_Users_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Distributors_AreaId",
                table: "Areas_Distributors",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Distributors_DistributorId",
                table: "Areas_Distributors",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Users_AreaId",
                table: "Areas_Users",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Users_UserId",
                table: "Areas_Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_Area_AreaId",
                table: "Distributors",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id");
        }
    }
}
