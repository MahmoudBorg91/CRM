using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class RequestAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestAction",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequetDataID = table.Column<int>(type: "int", nullable: false),
                    RequestFromUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfStartRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfEndtRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    UserTakeAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestAction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RequestAction_Requests_Data_RequetDataID",
                        column: x => x.RequetDataID,
                        principalTable: "Requests_Data",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestAction_RequetDataID",
                table: "RequestAction",
                column: "RequetDataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestAction");
        }
    }
}
