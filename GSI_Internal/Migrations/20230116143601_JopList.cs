using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class JopList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JopList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JopNameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JopNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JopCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    occupationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    qualificationArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    qualificationEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkilllevelArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkilllevelEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JopList", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JopList");
        }
    }
}
