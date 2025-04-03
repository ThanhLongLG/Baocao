using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAO_CAO.Migrations
{
    /// <inheritdoc />
    public partial class themhopdongthue1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDongThue_Phong_PhongMaphong",
                table: "HopDongThue");

            migrationBuilder.DropIndex(
                name: "IX_HopDongThue_PhongMaphong",
                table: "HopDongThue");

            migrationBuilder.DropColumn(
                name: "PhongMaphong",
                table: "HopDongThue");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThue_Maphong",
                table: "HopDongThue",
                column: "Maphong");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongThue_Phong_Maphong",
                table: "HopDongThue",
                column: "Maphong",
                principalTable: "Phong",
                principalColumn: "Maphong",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDongThue_Phong_Maphong",
                table: "HopDongThue");

            migrationBuilder.DropIndex(
                name: "IX_HopDongThue_Maphong",
                table: "HopDongThue");

            migrationBuilder.AddColumn<int>(
                name: "PhongMaphong",
                table: "HopDongThue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThue_PhongMaphong",
                table: "HopDongThue",
                column: "PhongMaphong");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongThue_Phong_PhongMaphong",
                table: "HopDongThue",
                column: "PhongMaphong",
                principalTable: "Phong",
                principalColumn: "Maphong",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
