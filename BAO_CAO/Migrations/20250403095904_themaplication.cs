using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAO_CAO.Migrations
{
    /// <inheritdoc />
    public partial class themaplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PayCheck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Maphong = table.Column<int>(type: "int", nullable: false),
                    PhongMaphong = table.Column<int>(type: "int", nullable: false),
                    MaKH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhachHangMaKH = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayCheck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayCheck_KhachHang_KhachHangMaKH",
                        column: x => x.KhachHangMaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayCheck_Phong_PhongMaphong",
                        column: x => x.PhongMaphong,
                        principalTable: "Phong",
                        principalColumn: "Maphong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayCheck_KhachHangMaKH",
                table: "PayCheck",
                column: "KhachHangMaKH");

            migrationBuilder.CreateIndex(
                name: "IX_PayCheck_PhongMaphong",
                table: "PayCheck",
                column: "PhongMaphong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayCheck");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "AspNetUsers");
        }
    }
}
