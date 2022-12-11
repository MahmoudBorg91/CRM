using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class prosessing2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_ApplicationTransaction_Request_Processing",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveStatus = table.Column<int>(type: "int", nullable: false),
                    App_Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ApplicationTransaction_Request_Processing", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_ApplicationTransaction_Request_Processing_tbl_ApplicationTransaction_Request_App_Code",
                        column: x => x.App_Code,
                        principalTable: "tbl_ApplicationTransaction_Request",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ApplicationTransaction_Request_Processing_App_Code",
                table: "tbl_ApplicationTransaction_Request_Processing",
                column: "App_Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_ApplicationTransaction_Request_Processing");
        }
    }
}
