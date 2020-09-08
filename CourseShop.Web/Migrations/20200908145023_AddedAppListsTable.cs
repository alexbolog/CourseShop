using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.Web.Migrations
{
    public partial class AddedAppListsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppLists",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: false),
                    CourseListTypeId = table.Column<int>(nullable: false),
                    InsertedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLists", x => new { x.CourseId, x.ApplicationUserId, x.CourseListTypeId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppLists");
        }
    }
}
