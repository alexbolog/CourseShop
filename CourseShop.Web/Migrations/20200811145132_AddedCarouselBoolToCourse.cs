using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.Web.Migrations
{
    public partial class AddedCarouselBoolToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelectedForCarousel",
                table: "Courses",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelectedForCarousel",
                table: "Courses");
        }
    }
}
