using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class AssignRequirmentToItemTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_AssignRequirmentToItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionItemID = table.Column<int>(type: "int", nullable: false),
                    RequirmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AssignRequirmentToItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_AssignRequirmentToItem_tbl_Requirements_RequirmentID",
                        column: x => x.RequirmentID,
                        principalTable: "tbl_Requirements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_AssignRequirmentToItem_tbl_TransactionItem_TransactionItemID",
                        column: x => x.TransactionItemID,
                        principalTable: "tbl_TransactionItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AssignRequirmentToItem_RequirmentID",
                table: "tbl_AssignRequirmentToItem",
                column: "RequirmentID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AssignRequirmentToItem_TransactionItemID",
                table: "tbl_AssignRequirmentToItem",
                column: "TransactionItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_AssignRequirmentToItem");
        }
    }
}
