using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class client_wallet3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Application_tbl_Requirements_RequireID",
                table: "tbl_Application");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Application",
                table: "tbl_Application");

            migrationBuilder.RenameTable(
                name: "tbl_Application",
                newName: "tbl_client_wallet");

            migrationBuilder.RenameColumn(
                name: "fileDate",
                table: "tbl_client_wallet",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Application_RequireID",
                table: "tbl_client_wallet",
                newName: "IX_tbl_client_wallet_RequireID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_client_wallet",
                table: "tbl_client_wallet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_wallet_tbl_Requirements_RequireID",
                table: "tbl_client_wallet",
                column: "RequireID",
                principalTable: "tbl_Requirements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_wallet_tbl_Requirements_RequireID",
                table: "tbl_client_wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_client_wallet",
                table: "tbl_client_wallet");

            migrationBuilder.RenameTable(
                name: "tbl_client_wallet",
                newName: "tbl_Application");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "tbl_Application",
                newName: "fileDate");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_client_wallet_RequireID",
                table: "tbl_Application",
                newName: "IX_tbl_Application_RequireID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Application",
                table: "tbl_Application",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Application_tbl_Requirements_RequireID",
                table: "tbl_Application",
                column: "RequireID",
                principalTable: "tbl_Requirements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
