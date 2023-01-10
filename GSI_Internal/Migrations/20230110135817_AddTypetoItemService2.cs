using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class AddTypetoItemService2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemServiceType",
                table: "tbl_TransactionItem",
                newName: "ItemServiceTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemServiceTypeID",
                table: "tbl_TransactionItem",
                newName: "ItemServiceType");
        }
    }
}
