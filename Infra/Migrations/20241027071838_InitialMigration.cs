using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtividadeEmGrupoP2.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "football_manager");

            migrationBuilder.CreateTable(
                name: "football_team",
                schema: "football_manager",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    founded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    nationality = table.Column<string>(type: "text", nullable: false),
                    stadium = table.Column<string>(type: "text", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false),
                    coach = table.Column<string>(type: "text", nullable: false),
                    league = table.Column<string>(type: "text", nullable: false),
                    championships_won = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true, defaultValue: ""),
                    last_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_football_team", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "football_player",
                schema: "football_manager",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    nationality = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<string>(type: "text", nullable: false),
                    jersey_number = table.Column<int>(type: "integer", nullable: false),
                    height = table.Column<decimal>(type: "numeric", nullable: false),
                    weight = table.Column<decimal>(type: "numeric", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    footed = table.Column<string>(type: "text", nullable: false),
                    goals_scored = table.Column<int>(type: "integer", nullable: false),
                    assists = table.Column<int>(type: "integer", nullable: false),
                    football_team_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true, defaultValue: ""),
                    last_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_football_player", x => x.id);
                    table.ForeignKey(
                        name: "FK_football_player_football_team_football_team_id",
                        column: x => x.football_team_id,
                        principalSchema: "football_manager",
                        principalTable: "football_team",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_football_player_football_team_id",
                schema: "football_manager",
                table: "football_player",
                column: "football_team_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "football_player",
                schema: "football_manager");

            migrationBuilder.DropTable(
                name: "football_team",
                schema: "football_manager");
        }
    }
}
