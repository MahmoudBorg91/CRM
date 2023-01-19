using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class TaskDocumentsV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "fileName",
                table: "TaskDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskDocuments_TaskID",
                table: "TaskDocuments",
                column: "TaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDocuments_TaskMain_TaskID",
                table: "TaskDocuments",
                column: "TaskID",
                principalTable: "TaskMain",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDocuments_TaskMain_TaskID",
                table: "TaskDocuments");

            migrationBuilder.DropIndex(
                name: "IX_TaskDocuments_TaskID",
                table: "TaskDocuments");

            migrationBuilder.AlterColumn<string>(
                name: "fileName",
                table: "TaskDocuments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
