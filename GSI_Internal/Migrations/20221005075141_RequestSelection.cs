using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class RequestSelection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestSelection",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSelection", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RequestSelection_tbl_ApplicationTransaction_Request_App_Code",
                        column: x => x.App_Code,
                        principalTable: "tbl_ApplicationTransaction_Request",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestSelection_tbl_TransiactionItem_Selection_SelectionID",
                        column: x => x.SelectionID,
                        principalTable: "tbl_TransiactionItem_Selection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestSelection_App_Code",
                table: "RequestSelection",
                column: "App_Code");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSelection_SelectionID",
                table: "RequestSelection",
                column: "SelectionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestSelection");
        }
    }
}
