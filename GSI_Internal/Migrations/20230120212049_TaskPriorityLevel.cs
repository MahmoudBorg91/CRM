using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class TaskPriorityLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskPriorityLevel",
                columns: table => new
                {
                    PriorityLevel_ID = table.Column<int>(type: "int", nullable: false),
                    PriorityLevel_Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskPriorityLevel");
        }
    }
}
