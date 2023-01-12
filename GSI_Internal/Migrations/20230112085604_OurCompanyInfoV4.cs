using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class OurCompanyInfoV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OurCompanyInfo",
                table: "OurCompanyInfo");

            migrationBuilder.RenameTable(
                name: "OurCompanyInfo",
                newName: "tbl_OurCompanyInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_OurCompanyInfo",
                table: "tbl_OurCompanyInfo",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_OurCompanyInfo",
                table: "tbl_OurCompanyInfo");

            migrationBuilder.RenameTable(
                name: "tbl_OurCompanyInfo",
                newName: "OurCompanyInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OurCompanyInfo",
                table: "OurCompanyInfo",
                column: "ID");
        }
    }
}
