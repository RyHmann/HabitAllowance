using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class RewardRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitEventRewards");

            migrationBuilder.CreateTable(
                name: "Rewards",
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
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_HabitRoutines_HabitRoutineId",
                        column: x => x.HabitRoutineId,
                        principalTable: "HabitRoutines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_HabitRoutineId",
                table: "Rewards",
                column: "HabitRoutineId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.CreateTable(
                name: "HabitEventRewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitRoutineId = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<decimal>(type: "money", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    RewardType = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_HabitEventRewards_HabitRoutineId",
                table: "HabitEventRewards",
                column: "HabitRoutineId",
                unique: true);
        }
    }
}
