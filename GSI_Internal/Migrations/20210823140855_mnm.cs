using Microsoft.EntityFrameworkCore.Migrations;

namespace GSI_Internal.Migrations
{
    public partial class mnm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDOFSolution",
                table: "DemoRequestSub",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDOFSolution",
                table: "DemoRequestSub");
        }
    }
}
