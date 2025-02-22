using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Studio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPic",
                table: "Studios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PicExtension",
                table: "Studios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPic",
                table: "Studios");

            migrationBuilder.DropColumn(
                name: "PicExtension",
                table: "Studios");
        }
    }
}
