using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class transferfromApllicationRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TarnferUserFrom",
                table: "tbl_ApplicationTransaction_Request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferUserTo",
                table: "tbl_ApplicationTransaction_Request",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TarnferUserFrom",
                table: "tbl_ApplicationTransaction_Request");

            migrationBuilder.DropColumn(
                name: "TransferUserTo",
                table: "tbl_ApplicationTransaction_Request");
        }
    }
}
