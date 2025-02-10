using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flat",
                columns: table => new
                {
                    FlatCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatPrice = table.Column<int>(type: "int", nullable: false),
                    FlatBathrooms = table.Column<int>(type: "int", nullable: false),
                    FlatBedrooms = table.Column<int>(type: "int", nullable: false),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    FlatGovernorate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlatCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlatDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlatAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flat", x => x.FlatCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    National_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flat");

            migrationBuilder.DropTable(
                name: "Register");
        }
    }
}
