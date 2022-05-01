using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KillTeam.Web.Data.Migrations
{
    public partial class _0004r : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Faction");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Faction",
                newName: "Description");

            migrationBuilder.AddColumn<Guid>(
                name: "RaceId",
                table: "Faction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FactionGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactionGroup_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faction_RaceId",
                table: "Faction",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_FactionGroup_RaceId",
                table: "FactionGroup",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faction_Race_RaceId",
                table: "Faction",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faction_Race_RaceId",
                table: "Faction");

            migrationBuilder.DropTable(
                name: "FactionGroup");

            migrationBuilder.DropIndex(
                name: "IX_Faction_RaceId",
                table: "Faction");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "Faction");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Faction",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Faction",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
