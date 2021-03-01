using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swole.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Gym_GymId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Gym_GymId",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gym",
                table: "Gym");

            migrationBuilder.RenameTable(
                name: "Gym",
                newName: "Gyms");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Employee",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Employee",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gyms",
                table: "Gyms",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GymEmployee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GymId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymEmployee", x => new { x.GymId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_GymEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymEmployee_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymEmployee_EmployeeId",
                table: "GymEmployee",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Gyms_GymId",
                table: "Employee",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Gyms_GymId",
                table: "Members",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Gyms_GymId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Gyms_GymId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "GymEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gyms",
                table: "Gyms");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Gyms",
                newName: "Gym");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gym",
                table: "Gym",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Gym_GymId",
                table: "Employee",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Gym_GymId",
                table: "Members",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
