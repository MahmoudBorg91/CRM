using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class inSubServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServicesDecription_Arabic",
                table: "tbl_TransactionItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicesDecription_English",
                table: "tbl_TransactionItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicesPhoto",
                table: "tbl_TransactionItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SetInMostServices",
                table: "tbl_TransactionItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Time_Services_Arabic",
                table: "tbl_TransactionItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time_Services_English",
                table: "tbl_TransactionItem",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicesDecription_Arabic",
                table: "tbl_TransactionItem");

            migrationBuilder.DropColumn(
                name: "ServicesDecription_English",
                table: "tbl_TransactionItem");

            migrationBuilder.DropColumn(
                name: "ServicesPhoto",
                table: "tbl_TransactionItem");

            migrationBuilder.DropColumn(
                name: "SetInMostServices",
                table: "tbl_TransactionItem");

            migrationBuilder.DropColumn(
                name: "Time_Services_Arabic",
                table: "tbl_TransactionItem");

            migrationBuilder.DropColumn(
                name: "Time_Services_English",
                table: "tbl_TransactionItem");
        }
    }
}
