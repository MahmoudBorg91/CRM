﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class SelectionGroupID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransiactionItem_Selection_SelectionGroupID",
                table: "tbl_TransiactionItem_Selection",
                column: "SelectionGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_TransiactionItem_Selection_tbl_RequestSelection_Group_SelectionGroupID",
                table: "tbl_TransiactionItem_Selection",
                column: "SelectionGroupID",
                principalTable: "tbl_RequestSelection_Group",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_TransiactionItem_Selection_tbl_RequestSelection_Group_SelectionGroupID",
                table: "tbl_TransiactionItem_Selection");

            migrationBuilder.DropIndex(
                name: "IX_tbl_TransiactionItem_Selection_SelectionGroupID",
                table: "tbl_TransiactionItem_Selection");
        }
    }
}
