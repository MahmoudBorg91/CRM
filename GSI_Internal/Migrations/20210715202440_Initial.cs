using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GSI_Internal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Solution",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoulutionNAme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Solution", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblCustommer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Thedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GovermnetID = table.Column<int>(type: "int", nullable: false),
                    GovermentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    PersonKeyNAme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonKeyPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonKeyJop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustommer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbllead",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    theDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cutomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cutomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchCount = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbllead", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Application",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDofSoulution = table.Column<int>(type: "int", nullable: false),
                    SoulutionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Application", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_Application_tbl_Solution_IDofSoulution",
                        column: x => x.IDofSoulution,
                        principalTable: "tbl_Solution",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemoRequestMain",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadID = table.Column<int>(type: "int", nullable: false),
                    Demo_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Demo_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfAtt = table.Column<int>(type: "int", nullable: false),
                    Compettior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoRequestMain", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DemoRequestMain_tbllead_LeadID",
                        column: x => x.LeadID,
                        principalTable: "tbllead",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_FollowUP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    The_Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionCode = table.Column<int>(type: "int", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FollowUP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_FollowUP_tbllead_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "tbllead",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemoRequestSub",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEMOID = table.Column<int>(type: "int", nullable: false),
                    IDOFAplication = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoRequestSub", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DemoRequestSub_DemoRequestMain_DEMOID",
                        column: x => x.DEMOID,
                        principalTable: "DemoRequestMain",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DemoRequestSub_tbl_Application_IDOFAplication",
                        column: x => x.IDOFAplication,
                        principalTable: "tbl_Application",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemoRequestMain_LeadID",
                table: "DemoRequestMain",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_DemoRequestSub_DEMOID",
                table: "DemoRequestSub",
                column: "DEMOID");

            migrationBuilder.CreateIndex(
                name: "IX_DemoRequestSub_IDOFAplication",
                table: "DemoRequestSub",
                column: "IDOFAplication");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Application_IDofSoulution",
                table: "tbl_Application",
                column: "IDofSoulution");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_FollowUP_CustomerID",
                table: "tbl_FollowUP",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemoRequestSub");

            migrationBuilder.DropTable(
                name: "tbl_FollowUP");

            migrationBuilder.DropTable(
                name: "tblCustommer");

            migrationBuilder.DropTable(
                name: "DemoRequestMain");

            migrationBuilder.DropTable(
                name: "tbl_Application");

            migrationBuilder.DropTable(
                name: "tbllead");

            migrationBuilder.DropTable(
                name: "tbl_Solution");
        }
    }
}
