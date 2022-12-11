using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class cccc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_RequestSelection_tbl_ApplicationTransaction_Request_App_Code",
                table: "tbl_RequestSelection");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_RequestSelection_tbl_TransiactionItem_Selection_SelectionID",
                table: "tbl_RequestSelection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_RequestSelection",
                table: "tbl_RequestSelection");

            migrationBuilder.RenameTable(
                name: "tbl_RequestSelection",
                newName: "RequestSelection");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_RequestSelection_SelectionID",
                table: "RequestSelection",
                newName: "IX_RequestSelection_SelectionID");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_RequestSelection_App_Code",
                table: "RequestSelection",
                newName: "IX_RequestSelection_App_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestSelection",
                table: "RequestSelection",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSelection_tbl_ApplicationTransaction_Request_App_Code",
                table: "RequestSelection",
                column: "App_Code",
                principalTable: "tbl_ApplicationTransaction_Request",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSelection_tbl_TransiactionItem_Selection_SelectionID",
                table: "RequestSelection",
                column: "SelectionID",
                principalTable: "tbl_TransiactionItem_Selection",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestSelection_tbl_ApplicationTransaction_Request_App_Code",
                table: "RequestSelection");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSelection_tbl_TransiactionItem_Selection_SelectionID",
                table: "RequestSelection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestSelection",
                table: "RequestSelection");

            migrationBuilder.RenameTable(
                name: "RequestSelection",
                newName: "tbl_RequestSelection");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSelection_SelectionID",
                table: "tbl_RequestSelection",
                newName: "IX_tbl_RequestSelection_SelectionID");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSelection_App_Code",
                table: "tbl_RequestSelection",
                newName: "IX_tbl_RequestSelection_App_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_RequestSelection",
                table: "tbl_RequestSelection",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_RequestSelection_tbl_ApplicationTransaction_Request_App_Code",
                table: "tbl_RequestSelection",
                column: "App_Code",
                principalTable: "tbl_ApplicationTransaction_Request",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_RequestSelection_tbl_TransiactionItem_Selection_SelectionID",
                table: "tbl_RequestSelection",
                column: "SelectionID",
                principalTable: "tbl_TransiactionItem_Selection",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
