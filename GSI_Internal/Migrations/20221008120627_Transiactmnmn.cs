using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class Transiactmnmn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_TransiactionItem_Selection_tbl_RequestSelection_Group_SelectionGroupID",
                table: "tbl_TransiactionItem_Selection");

            migrationBuilder.AlterColumn<int>(
                name: "SelectionGroupID",
                table: "tbl_TransiactionItem_Selection",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_TransiactionItem_Selection_tbl_RequestSelection_Group_SelectionGroupID",
                table: "tbl_TransiactionItem_Selection",
                column: "SelectionGroupID",
                principalTable: "tbl_RequestSelection_Group",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_TransiactionItem_Selection_tbl_RequestSelection_Group_SelectionGroupID",
                table: "tbl_TransiactionItem_Selection");

            migrationBuilder.AlterColumn<int>(
                name: "SelectionGroupID",
                table: "tbl_TransiactionItem_Selection",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_TransiactionItem_Selection_tbl_RequestSelection_Group_SelectionGroupID",
                table: "tbl_TransiactionItem_Selection",
                column: "SelectionGroupID",
                principalTable: "tbl_RequestSelection_Group",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
