using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class RequestInquiry_Answer3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestInquiry_Answer_tbl_ApplicationTransaction_Request_App_Code",
                table: "RequestInquiry_Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestInquiry_Answer_tbl_TransactionItemInquiry_InquiryID",
                table: "RequestInquiry_Answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestInquiry_Answer",
                table: "RequestInquiry_Answer");

            migrationBuilder.RenameTable(
                name: "RequestInquiry_Answer",
                newName: "tbl_RequestInquiry_Answer");

            migrationBuilder.RenameIndex(
                name: "IX_RequestInquiry_Answer_InquiryID",
                table: "tbl_RequestInquiry_Answer",
                newName: "IX_tbl_RequestInquiry_Answer_InquiryID");

            migrationBuilder.RenameIndex(
                name: "IX_RequestInquiry_Answer_App_Code",
                table: "tbl_RequestInquiry_Answer",
                newName: "IX_tbl_RequestInquiry_Answer_App_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_RequestInquiry_Answer",
                table: "tbl_RequestInquiry_Answer",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_RequestInquiry_Answer_tbl_ApplicationTransaction_Request_App_Code",
                table: "tbl_RequestInquiry_Answer",
                column: "App_Code",
                principalTable: "tbl_ApplicationTransaction_Request",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_RequestInquiry_Answer_tbl_TransactionItemInquiry_InquiryID",
                table: "tbl_RequestInquiry_Answer",
                column: "InquiryID",
                principalTable: "tbl_TransactionItemInquiry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_RequestInquiry_Answer_tbl_ApplicationTransaction_Request_App_Code",
                table: "tbl_RequestInquiry_Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_RequestInquiry_Answer_tbl_TransactionItemInquiry_InquiryID",
                table: "tbl_RequestInquiry_Answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_RequestInquiry_Answer",
                table: "tbl_RequestInquiry_Answer");

            migrationBuilder.RenameTable(
                name: "tbl_RequestInquiry_Answer",
                newName: "RequestInquiry_Answer");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_RequestInquiry_Answer_InquiryID",
                table: "RequestInquiry_Answer",
                newName: "IX_RequestInquiry_Answer_InquiryID");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_RequestInquiry_Answer_App_Code",
                table: "RequestInquiry_Answer",
                newName: "IX_RequestInquiry_Answer_App_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestInquiry_Answer",
                table: "RequestInquiry_Answer",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestInquiry_Answer_tbl_ApplicationTransaction_Request_App_Code",
                table: "RequestInquiry_Answer",
                column: "App_Code",
                principalTable: "tbl_ApplicationTransaction_Request",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestInquiry_Answer_tbl_TransactionItemInquiry_InquiryID",
                table: "RequestInquiry_Answer",
                column: "InquiryID",
                principalTable: "tbl_TransactionItemInquiry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
