using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAO_CAO.Migrations
{
    /// <inheritdoc />
    public partial class suanv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "hesoluong",
                table: "Nhanvien",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "hesoluong",
                table: "Nhanvien",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
