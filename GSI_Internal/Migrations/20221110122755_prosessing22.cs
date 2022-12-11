using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class prosessing22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTransactionTimeToProcess",
                table: "tbl_ApplicationTransaction_Request_Processing",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsProsessByUser",
                table: "tbl_ApplicationTransaction_Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserProsessID",
                table: "tbl_ApplicationTransaction_Request",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTransactionTimeToProcess",
                table: "tbl_ApplicationTransaction_Request_Processing");

            migrationBuilder.DropColumn(
                name: "IsProsessByUser",
                table: "tbl_ApplicationTransaction_Request");

            migrationBuilder.DropColumn(
                name: "UserProsessID",
                table: "tbl_ApplicationTransaction_Request");
        }
    }
}
