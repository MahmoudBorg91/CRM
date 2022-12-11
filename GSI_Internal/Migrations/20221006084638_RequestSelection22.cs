using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class RequestSelection22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectionName",
                table: "RequestSelection");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "RequestSelection",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "RequestSelection");

            migrationBuilder.AddColumn<string>(
                name: "SelectionName",
                table: "RequestSelection",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
