using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class UpdateSlideShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowInMobile",
                table: "tbl_SlideShow",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowInWeb",
                table: "tbl_SlideShow",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowInMobile",
                table: "tbl_SlideShow");

            migrationBuilder.DropColumn(
                name: "ShowInWeb",
                table: "tbl_SlideShow");
        }
    }
}
