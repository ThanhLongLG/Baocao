using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAO_CAO.Migrations
{
    /// <inheritdoc />
    public partial class themhodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    danhgia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "Nhanvien",
                columns: table => new
                {
                    MaNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hesoluong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanvien", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "HopDongThue",
                columns: table => new
                {
                    MaHopDong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tongtien = table.Column<float>(type: "real", nullable: false),
                    ngaythanhtoan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    MaKH = table.Column<int>(type: "int", nullable: false),
                    Maphong = table.Column<int>(type: "int", nullable: false),
                    PhongMaphong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongThue", x => x.MaHopDong);
                    table.ForeignKey(
                        name: "FK_HopDongThue_KhachHang_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDongThue_Nhanvien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "Nhanvien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDongThue_Phong_PhongMaphong",
                        column: x => x.PhongMaphong,
                        principalTable: "Phong",
                        principalColumn: "Maphong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThue_MaKH",
                table: "HopDongThue",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThue_MaNV",
                table: "HopDongThue",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThue_PhongMaphong",
                table: "HopDongThue",
                column: "PhongMaphong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HopDongThue");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "Nhanvien");
        }
    }
}
