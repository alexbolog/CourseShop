using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.Web.Migrations
{
    public partial class AddedCourseDetailsColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contributors",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LengthHours",
                table: "Courses",
                type: "DECIMAL(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contributors",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LengthHours",
                table: "Courses");
        }
    }
}
