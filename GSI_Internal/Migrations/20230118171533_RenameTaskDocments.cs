using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class RenameTaskDocments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDocuments");

            migrationBuilder.CreateTable(
                name: "TaskDocuments_tbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskID = table.Column<int>(type: "int", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDocuments_tbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TaskDocuments_tbl_TaskMain_TaskID",
                        column: x => x.TaskID,
                        principalTable: "TaskMain",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDocuments_tbl_TaskID",
                table: "TaskDocuments_tbl",
                column: "TaskID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDocuments_tbl");

            migrationBuilder.CreateTable(
                name: "TaskDocuments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskID = table.Column<int>(type: "int", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TaskDocuments_TaskMain_TaskID",
                        column: x => x.TaskID,
                        principalTable: "TaskMain",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDocuments_TaskID",
                table: "TaskDocuments",
                column: "TaskID");
        }
    }
}
