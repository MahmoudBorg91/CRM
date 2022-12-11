using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class SlideShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "tbl_SlideShow",
                newName: "Title_English");

            migrationBuilder.RenameColumn(
                name: "ReSizeme",
                table: "tbl_SlideShow",
                newName: "Title_Arabic");

            migrationBuilder.AddColumn<string>(
                name: "ReSizeme_Arabic",
                table: "tbl_SlideShow",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReSizeme_English",
                table: "tbl_SlideShow",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReSizeme_Arabic",
                table: "tbl_SlideShow");

            migrationBuilder.DropColumn(
                name: "ReSizeme_English",
                table: "tbl_SlideShow");

            migrationBuilder.RenameColumn(
                name: "Title_English",
                table: "tbl_SlideShow",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Title_Arabic",
                table: "tbl_SlideShow",
                newName: "ReSizeme");
        }
    }
}
