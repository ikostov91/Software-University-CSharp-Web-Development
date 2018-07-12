using Microsoft.EntityFrameworkCore.Migrations;

namespace NewAwesomeHotelD.Migrations
{
    public partial class RoomUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoomType",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoomType",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
