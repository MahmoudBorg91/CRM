using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class ApplicationTransaction_Request_Log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_ApplicationTransaction_Request_Log",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    The_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_Code = table.Column<int>(type: "int", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item_code = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status_From = table.Column<int>(type: "int", nullable: false),
                    Status_TO = table.Column<int>(type: "int", nullable: false),
                    App_Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ApplicationTransaction_Request_Log", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_ApplicationTransaction_Request_Log_tbl_ApplicationTransaction_Request_App_Code",
                        column: x => x.App_Code,
                        principalTable: "tbl_ApplicationTransaction_Request",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ApplicationTransaction_Request_Log_App_Code",
                table: "tbl_ApplicationTransaction_Request_Log",
                column: "App_Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_ApplicationTransaction_Request_Log");
        }
    }
}
