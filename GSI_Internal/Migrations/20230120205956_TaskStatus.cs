using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class TaskStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskStatusName",
                columns: table => new
                {
                    StatusAction_Code = table.Column<int>(type: "int", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskStatusName");
        }
    }
}
