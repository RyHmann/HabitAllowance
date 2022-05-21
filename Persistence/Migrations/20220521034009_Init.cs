using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HabitRoutines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HabitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitRoutines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitRoutines_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabitEventRewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<decimal>(type: "money", nullable: false),
                    RewardType = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    HabitRoutineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitEventRewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitEventRewards_HabitRoutines_HabitRoutineId",
                        column: x => x.HabitRoutineId,
                        principalTable: "HabitRoutines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabitEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HabitRoutineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitEvents_HabitRoutines_HabitRoutineId",
                        column: x => x.HabitRoutineId,
                        principalTable: "HabitRoutines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitEventRewards_HabitRoutineId",
                table: "HabitEventRewards",
                column: "HabitRoutineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HabitEvents_HabitRoutineId",
                table: "HabitEvents",
                column: "HabitRoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitRoutines_HabitId",
                table: "HabitRoutines",
                column: "HabitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitEventRewards");

            migrationBuilder.DropTable(
                name: "HabitEvents");

            migrationBuilder.DropTable(
                name: "HabitRoutines");

            migrationBuilder.DropTable(
                name: "Habits");
        }
    }
}
