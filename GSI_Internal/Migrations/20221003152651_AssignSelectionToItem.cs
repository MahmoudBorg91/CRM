using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class AssignSelectionToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_AssignSelectionToItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionItemID = table.Column<int>(type: "int", nullable: false),
                    SelectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AssignSelectionToItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_AssignSelectionToItem_tbl_TransactionItem_TransactionItemID",
                        column: x => x.TransactionItemID,
                        principalTable: "tbl_TransactionItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_AssignSelectionToItem_tbl_TransiactionItem_Selection_SelectionID",
                        column: x => x.SelectionID,
                        principalTable: "tbl_TransiactionItem_Selection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AssignSelectionToItem_SelectionID",
                table: "tbl_AssignSelectionToItem",
                column: "SelectionID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AssignSelectionToItem_TransactionItemID",
                table: "tbl_AssignSelectionToItem",
                column: "TransactionItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_AssignSelectionToItem");
        }
    }
}
