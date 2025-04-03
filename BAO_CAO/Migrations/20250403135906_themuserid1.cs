using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAO_CAO.Migrations
{
    /// <inheritdoc />
    public partial class themuserid1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayCheck_Phong_PhongMaphong",
                table: "PayCheck");

            migrationBuilder.AlterColumn<int>(
                name: "PhongMaphong",
                table: "PayCheck",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInDate",
                table: "PayCheck",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOutDate",
                table: "PayCheck",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_PayCheck_Phong_PhongMaphong",
                table: "PayCheck",
                column: "PhongMaphong",
                principalTable: "Phong",
                principalColumn: "Maphong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayCheck_Phong_PhongMaphong",
                table: "PayCheck");

            migrationBuilder.DropColumn(
                name: "CheckInDate",
                table: "PayCheck");

            migrationBuilder.DropColumn(
                name: "CheckOutDate",
                table: "PayCheck");

            migrationBuilder.AlterColumn<int>(
                name: "PhongMaphong",
                table: "PayCheck",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PayCheck_Phong_PhongMaphong",
                table: "PayCheck",
                column: "PhongMaphong",
                principalTable: "Phong",
                principalColumn: "Maphong",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
