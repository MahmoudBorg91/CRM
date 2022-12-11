using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class updteApplicationRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientLastName",
                table: "tbl_ApplicationTransaction_Request",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Country_ID",
                table: "tbl_ApplicationTransaction_Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Move_Type",
                table: "tbl_ApplicationTransaction_Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "tbl_ApplicationTransaction_Request",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientLastName",
                table: "tbl_ApplicationTransaction_Request");

            migrationBuilder.DropColumn(
                name: "Country_ID",
                table: "tbl_ApplicationTransaction_Request");

            migrationBuilder.DropColumn(
                name: "Move_Type",
                table: "tbl_ApplicationTransaction_Request");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "tbl_ApplicationTransaction_Request");
        }
    }
}
