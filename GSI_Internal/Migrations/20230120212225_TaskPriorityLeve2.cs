using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class TaskPriorityLeve2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PriorityLevel_Name",
                table: "TaskPriorityLevel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PriorityLevel_Name",
                table: "TaskPriorityLevel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
