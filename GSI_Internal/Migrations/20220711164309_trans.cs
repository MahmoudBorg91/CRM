using Microsoft.EntityFrameworkCore.Migrations;

namespace GSI_Internal.Migrations
{
    public partial class trans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_TransactionGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionGroup_NameArabic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionGroup_NameEnglish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TransactionGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TransactionItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionNameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernmentFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TransactionItem", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_TransactionGroup");

            migrationBuilder.DropTable(
                name: "tbl_TransactionItem");
        }
    }
}
