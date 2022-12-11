using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class RequirmentsFileAttachmentTB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_RequirmentsFileAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequireID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RequirmentsFileAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_RequirmentsFileAttachment_tbl_ApplicationTransaction_Request_App_Code",
                        column: x => x.App_Code,
                        principalTable: "tbl_ApplicationTransaction_Request",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_RequirmentsFileAttachment_tbl_Requirements_RequireID",
                        column: x => x.RequireID,
                        principalTable: "tbl_Requirements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RequirmentsFileAttachment_App_Code",
                table: "tbl_RequirmentsFileAttachment",
                column: "App_Code");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RequirmentsFileAttachment_RequireID",
                table: "tbl_RequirmentsFileAttachment",
                column: "RequireID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_RequirmentsFileAttachment");
        }
    }
}
