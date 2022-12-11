using Microsoft.EntityFrameworkCore.Migrations;

namespace GSI_Internal.Migrations
{
    public partial class transfoeginkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionGroupID",
                table: "tbl_TransactionItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransactionItem_TransactionGroupID",
                table: "tbl_TransactionItem",
                column: "TransactionGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_TransactionItem_tbl_TransactionGroup_TransactionGroupID",
                table: "tbl_TransactionItem",
                column: "TransactionGroupID",
                principalTable: "tbl_TransactionGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_TransactionItem_tbl_TransactionGroup_TransactionGroupID",
                table: "tbl_TransactionItem");

            migrationBuilder.DropIndex(
                name: "IX_tbl_TransactionItem_TransactionGroupID",
                table: "tbl_TransactionItem");

            migrationBuilder.DropColumn(
                name: "TransactionGroupID",
                table: "tbl_TransactionItem");
        }
    }
}
