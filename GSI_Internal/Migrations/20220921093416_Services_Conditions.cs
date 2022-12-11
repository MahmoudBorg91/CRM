using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class Services_Conditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Services_Conditions_Arabic",
                table: "tbl_TransactionItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Services_Conditions_English",
                table: "tbl_TransactionItem",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Services_Conditions_Arabic",
                table: "tbl_TransactionItem");

            migrationBuilder.DropColumn(
                name: "Services_Conditions_English",
                table: "tbl_TransactionItem");
        }
    }
}
