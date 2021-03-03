using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swole.Migrations
{
    public partial class AddGymMemberEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Gyms_GymId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_GymId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Members");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "GymEmployee",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GymMember",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GymId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymMember", x => new { x.GymId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_GymMember_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymMember_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymEmployee_MemberId",
                table: "GymEmployee",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_GymMember_MemberId",
                table: "GymMember",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_GymEmployee_Members_MemberId",
                table: "GymEmployee",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymEmployee_Members_MemberId",
                table: "GymEmployee");

            migrationBuilder.DropTable(
                name: "GymMember");

            migrationBuilder.DropIndex(
                name: "IX_GymEmployee_MemberId",
                table: "GymEmployee");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "GymEmployee");

            migrationBuilder.AddColumn<Guid>(
                name: "GymId",
                table: "Members",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_GymId",
                table: "Members",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Gyms_GymId",
                table: "Members",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
