using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.Web.Migrations
{
    public partial class AddedUrlColumnsToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WatchUrl",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "WatchUrl",
                table: "Courses");
        }
    }
}
