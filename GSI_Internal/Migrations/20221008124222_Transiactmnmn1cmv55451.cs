using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class Transiactmnmn1cmv55451 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_TransiactionItem_Selection_tbl_RequestSelection_Group_SelectionGroupID",
                table: "tbl_TransiactionItem_Selection");

            migrationBuilder.RenameColumn(
                name: "SelectionGroupID",
                table: "tbl_TransiactionItem_Selection",
                newName: "GroupID");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_TransiactionItem_Selection_SelectionGroupID",
                table: "tbl_TransiactionItem_Selection",
                newName: "IX_tbl_TransiactionItem_Selection_GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_TransiactionItem_Selection_tbl_RequestSelection_Group_GroupID",
                table: "tbl_TransiactionItem_Selection",
                column: "GroupID",
                principalTable: "tbl_RequestSelection_Group",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_TransiactionItem_Selection_tbl_RequestSelection_Group_GroupID",
                table: "tbl_TransiactionItem_Selection");

            migrationBuilder.RenameColumn(
                name: "GroupID",
                table: "tbl_TransiactionItem_Selection",
                newName: "SelectionGroupID");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_TransiactionItem_Selection_GroupID",
                table: "tbl_TransiactionItem_Selection",
                newName: "IX_tbl_TransiactionItem_Selection_SelectionGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_TransiactionItem_Selection_tbl_RequestSelection_Group_SelectionGroupID",
                table: "tbl_TransiactionItem_Selection",
                column: "SelectionGroupID",
                principalTable: "tbl_RequestSelection_Group",
                principalColumn: "ID");
        }
    }
}
