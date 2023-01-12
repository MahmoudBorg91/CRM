using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class OurCompanyInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OurCompanyInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUS_Englis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUS_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUS_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUS_Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurMission_Englis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurMission_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurMission_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurMission_Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurVision_Englis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurVision_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurVision_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurVision_Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurGoal_Englis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurGoal_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurGoal_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurGoal_Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurValues_Englis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurValues_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurValues_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurValues_Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurCompanyInfo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OurCompanyInfo");
        }
    }
}
