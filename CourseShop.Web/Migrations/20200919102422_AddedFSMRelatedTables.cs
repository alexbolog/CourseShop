using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.Web.Migrations
{
    public partial class AddedFSMRelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FSMActions",
                columns: table => new
                {
                    FSMActionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FSMTransitionId = table.Column<int>(nullable: false),
                    ActionTypeId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FSMActions", x => x.FSMActionId);
                });

            migrationBuilder.CreateTable(
                name: "FSMConditions",
                columns: table => new
                {
                    FSMConditionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FSMTransitionId = table.Column<int>(nullable: false),
                    ConditionTypeId = table.Column<int>(nullable: false),
                    ConditionName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FSMConditions", x => x.FSMConditionId);
                });

            migrationBuilder.CreateTable(
                name: "FSMTransitions",
                columns: table => new
                {
                    FSMTransitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatusIdFrom = table.Column<int>(nullable: false),
                    OrderStatusIdTo = table.Column<int>(nullable: false),
                    ConditionSequence = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FSMTransitions", x => x.FSMTransitionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FSMActions");

            migrationBuilder.DropTable(
                name: "FSMConditions");

            migrationBuilder.DropTable(
                name: "FSMTransitions");
        }
    }
}
