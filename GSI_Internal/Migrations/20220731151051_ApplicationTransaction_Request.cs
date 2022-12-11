using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class ApplicationTransaction_Request : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_ApplicationTransaction_Request",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    The_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ClientPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransiactionItem_Code = table.Column<int>(type: "int", nullable: false),
                    TransiactionItem_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransiactionItem_GovernmentFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransiactionItem_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransiactionItem_Net = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    files = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ApplicationTransaction_Request", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_ApplicationTransaction_Request");
        }
    }
}
