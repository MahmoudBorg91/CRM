using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class RequestInquiry_Answer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppCode",
                table: "RequestInquiry_Answer",
                newName: "App_Code");

            migrationBuilder.CreateIndex(
                name: "IX_RequestInquiry_Answer_App_Code",
                table: "RequestInquiry_Answer",
                column: "App_Code");

            migrationBuilder.CreateIndex(
                name: "IX_RequestInquiry_Answer_InquiryID",
                table: "RequestInquiry_Answer",
                column: "InquiryID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestInquiry_Answer_tbl_ApplicationTransaction_Request_App_Code",
                table: "RequestInquiry_Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestInquiry_Answer_tbl_TransactionItemInquiry_InquiryID",
                table: "RequestInquiry_Answer");

            migrationBuilder.DropIndex(
                name: "IX_RequestInquiry_Answer_App_Code",
                table: "RequestInquiry_Answer");

            migrationBuilder.DropIndex(
                name: "IX_RequestInquiry_Answer_InquiryID",
                table: "RequestInquiry_Answer");

            migrationBuilder.RenameColumn(
                name: "App_Code",
                table: "RequestInquiry_Answer",
                newName: "AppCode");
        }
    }
}
