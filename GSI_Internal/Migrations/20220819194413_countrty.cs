using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class countrty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country_ID",
                table: "tbl_ApplicationTransaction_Request");

            migrationBuilder.AddColumn<string>(
                name: "Country_Name",
                table: "tbl_ApplicationTransaction_Request",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country_Name",
                table: "tbl_ApplicationTransaction_Request");

            migrationBuilder.AddColumn<int>(
                name: "Country_ID",
                table: "tbl_ApplicationTransaction_Request",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
