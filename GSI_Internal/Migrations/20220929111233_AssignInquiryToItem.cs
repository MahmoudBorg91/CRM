using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class AssignInquiryToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_AssignInquiryToItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionItemID = table.Column<int>(type: "int", nullable: false),
                    InquiryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AssignInquiryToItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_AssignInquiryToItem_tbl_TransactionItem_TransactionItemID",
                        column: x => x.TransactionItemID,
                        principalTable: "tbl_TransactionItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_AssignInquiryToItem_tbl_TransactionItemInquiry_InquiryID",
                        column: x => x.InquiryID,
                        principalTable: "tbl_TransactionItemInquiry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AssignInquiryToItem_InquiryID",
                table: "tbl_AssignInquiryToItem",
                column: "InquiryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AssignInquiryToItem_TransactionItemID",
                table: "tbl_AssignInquiryToItem",
                column: "TransactionItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_AssignInquiryToItem");
        }
    }
}
