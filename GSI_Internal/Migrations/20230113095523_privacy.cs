using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class privacy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrivacyAndPolicy",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrivacyAndPolicyAr",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefundPolicy",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefundPolicyAr",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrivacyAndPolicy",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "PrivacyAndPolicyAr",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "RefundPolicy",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "RefundPolicyAr",
                table: "ContactUs");
        }
    }
}
