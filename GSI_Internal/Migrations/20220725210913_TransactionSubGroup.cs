using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class TransactionSubGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_TransactionSubGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubGroupNameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubGroupNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionGroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TransactionSubGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_TransactionSubGroup_tbl_TransactionGroup_TransactionGroupID",
                        column: x => x.TransactionGroupID,
                        principalTable: "tbl_TransactionGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransactionSubGroup_TransactionGroupID",
                table: "tbl_TransactionSubGroup",
                column: "TransactionGroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_TransactionSubGroup");
        }
    }
}
