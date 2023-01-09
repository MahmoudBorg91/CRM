using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class IconAndIsAvial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "tbl_TransactionItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNotAvailbale",
                table: "tbl_TransactionItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "tbl_TransactionGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNotAvailbale",
                table: "tbl_TransactionGroup",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "tbl_TransactionItem");

            migrationBuilder.DropColumn(
                name: "IsNotAvailbale",
                table: "tbl_TransactionItem");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "tbl_TransactionGroup");

            migrationBuilder.DropColumn(
                name: "IsNotAvailbale",
                table: "tbl_TransactionGroup");
        }
    }
}
