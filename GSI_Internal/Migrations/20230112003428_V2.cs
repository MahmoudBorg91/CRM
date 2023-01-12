using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_TransactionItem_tbl_TransactionItem_Type_ItemServiceTypeID",
                table: "tbl_TransactionItem");

            migrationBuilder.DropIndex(
                name: "IX_tbl_TransactionItem_ItemServiceTypeID",
                table: "tbl_TransactionItem");

            migrationBuilder.DropColumn(
                name: "ItemServiceTypeID",
                table: "tbl_TransactionItem");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransactionItem_TransactionItemTypeId",
                table: "tbl_TransactionItem",
                column: "TransactionItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_TransactionItem_tbl_TransactionItem_Type_TransactionItemTypeId",
                table: "tbl_TransactionItem",
                column: "TransactionItemTypeId",
                principalTable: "tbl_TransactionItem_Type",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_TransactionItem_tbl_TransactionItem_Type_TransactionItemTypeId",
                table: "tbl_TransactionItem");

            migrationBuilder.DropIndex(
                name: "IX_tbl_TransactionItem_TransactionItemTypeId",
                table: "tbl_TransactionItem");

            migrationBuilder.AddColumn<int>(
                name: "ItemServiceTypeID",
                table: "tbl_TransactionItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransactionItem_ItemServiceTypeID",
                table: "tbl_TransactionItem",
                column: "ItemServiceTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_TransactionItem_tbl_TransactionItem_Type_ItemServiceTypeID",
                table: "tbl_TransactionItem",
                column: "ItemServiceTypeID",
                principalTable: "tbl_TransactionItem_Type",
                principalColumn: "ID");
        }
    }
}
