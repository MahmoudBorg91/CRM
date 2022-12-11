using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class updteApplicationRequestLOg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumberOfTransiactionOfEntity",
                table: "tbl_ApplicationTransaction_Request_Log",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfTransiactionOfEntity",
                table: "tbl_ApplicationTransaction_Request_Log");
        }
    }
}
