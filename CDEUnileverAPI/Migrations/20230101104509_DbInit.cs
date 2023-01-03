using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDEUnileverAPI.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistributorQty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ReporterId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Areas_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArea = table.Column<int>(name: "Id_Area", type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(name: "Id_User", type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Distributors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaleSupId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distributors_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Distributors_Users_SaleSupId",
                        column: x => x.SaleSupId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas_Distributors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArea = table.Column<int>(name: "Id_Area", type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    IdDistributor = table.Column<int>(name: "Id_Distributor", type: "int", nullable: false),
                    DistributorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas_Distributors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Areas_Distributors_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Areas_Distributors_Distributors_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Distributors",
                        principalColumn: "Id");
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

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_AreaId",
                table: "Distributors",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_SaleSupId",
                table: "Distributors",
                column: "SaleSupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AreaId",
                table: "Users",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ReporterId",
                table: "Users",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TitleId",
                table: "Users",
                column: "TitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas_Distributors");

            migrationBuilder.DropTable(
                name: "Areas_Users");

            migrationBuilder.DropTable(
                name: "Distributors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
