using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlatImagesDocs",
                columns: table => new
                {
                    FlatImagesDocsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatCodeId = table.Column<int>(type: "int", nullable: false),
                    Flatimage = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatImagesDocs", x => x.FlatImagesDocsId);
                    table.ForeignKey(
                        name: "FK_FlatImagesDocs_Flat_FlatCodeId",
                        column: x => x.FlatCodeId,
                        principalTable: "Flat",
                        principalColumn: "FlatCodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlatImagesDocs_FlatCodeId",
                table: "FlatImagesDocs",
                column: "FlatCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlatImagesDocs");
        }
    }
}
