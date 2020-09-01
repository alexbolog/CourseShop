using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.Web.Migrations
{
    public partial class AddedCourseImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseImages",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    ImageIndex = table.Column<int>(nullable: false),
                    Base64Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseImages", x => new { x.CourseId, x.ImageIndex });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseImages");
        }
    }
}
