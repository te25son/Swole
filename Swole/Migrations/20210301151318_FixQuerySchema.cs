using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swole.Migrations
{
    public partial class FixQuerySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Gyms_GymId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_GymId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GymId",
                table: "Employee",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GymId",
                table: "Employee",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Gyms_GymId",
                table: "Employee",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
