using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAO_CAO.Migrations
{
    /// <inheritdoc />
    public partial class themphong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    Maphong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sophong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    sogiuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dientich = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.Maphong);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phong");
        }
    }
}
