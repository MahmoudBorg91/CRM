using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class AddTypetoItemService22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransactionItem_TransactionSubGroupID",
                table: "tbl_TransactionItem",
                column: "TransactionSubGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_TransactionItem_tbl_TransactionSubGroup_TransactionSubGroupID",
                table: "tbl_TransactionItem",
                column: "TransactionSubGroupID",
                principalTable: "tbl_TransactionSubGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_TransactionItem_tbl_TransactionSubGroup_TransactionSubGroupID",
                table: "tbl_TransactionItem");

            migrationBuilder.DropIndex(
                name: "IX_tbl_TransactionItem_TransactionSubGroupID",
                table: "tbl_TransactionItem");
        }
    }
}
