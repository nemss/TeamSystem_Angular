using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeamSystem.Data.Migrations
{
    public partial class added_ThumnailUrl_inTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(maxLength: 1, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ThumbnailUrl = table.Column<string>(maxLength: 1, nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MatchHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuestTeamPlayer = table.Column<string>(maxLength: 150, nullable: true),
                    HomeTeamPlayer = table.Column<string>(maxLength: 150, nullable: true),
                    MatchDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchHistories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModelRoles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Role = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Full_Name = table.Column<string>(maxLength: 100, nullable: true),
                    IsReserve = table.Column<bool>(nullable: true),
                    PreviousTeam = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonHistories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(maxLength: 50, nullable: false),
                    ThumbnailUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuestTeam_ID = table.Column<int>(nullable: true),
                    GuestTeamScore = table.Column<int>(nullable: true),
                    HomeTeam_ID = table.Column<int>(nullable: true),
                    HomeTeamScore = table.Column<int>(nullable: true),
                    MatchDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Matches__GuestTe__628FA481",
                        column: x => x.GuestTeam_ID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Matches__HomeTea__619B8048",
                        column: x => x.HomeTeam_ID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonModels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    IsReserve = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    ModelRole_ID = table.Column<int>(nullable: false),
                    Team_ID = table.Column<int>(nullable: false),
                    UCN = table.Column<string>(type: "nchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK__PersonMod__Model__4F7CD00D",
                        column: x => x.ModelRole_ID,
                        principalTable: "ModelRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PersonMod__Team___4E88ABD4",
                        column: x => x.Team_ID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StartingMembersOfATeam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Team_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartingMembersOfATeam", x => x.ID);
                    table.ForeignKey(
                        name: "FK__StartingM__Team___571DF1D5",
                        column: x => x.Team_ID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StartingPlayers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Member_ID = table.Column<int>(nullable: true),
                    Player_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartingPlayers", x => x.ID);
                    table.ForeignKey(
                        name: "FK__StartingP__Membe__5BE2A6F2",
                        column: x => x.Member_ID,
                        principalTable: "StartingMembersOfATeam",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__StartingP__Playe__5CD6CB2B",
                        column: x => x.Player_ID,
                        principalTable: "PersonModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GuestTeam_ID",
                table: "Matches",
                column: "GuestTeam_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeam_ID",
                table: "Matches",
                column: "HomeTeam_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__ModelRol__DA15413E45F365D3",
                table: "ModelRoles",
                column: "Role",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonModels_ModelRole_ID",
                table: "PersonModels",
                column: "ModelRole_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonModels_Team_ID",
                table: "PersonModels",
                column: "Team_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__PersonMo__C5B186D24CA06362",
                table: "PersonModels",
                column: "UCN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Starting__02215C0B5535A963",
                table: "StartingMembersOfATeam",
                column: "Team_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StartingPlayers_Member_ID",
                table: "StartingPlayers",
                column: "Member_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StartingPlayers_Player_ID",
                table: "StartingPlayers",
                column: "Player_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "MatchHistories");

            migrationBuilder.DropTable(
                name: "PersonHistories");

            migrationBuilder.DropTable(
                name: "StartingPlayers");

            migrationBuilder.DropTable(
                name: "StartingMembersOfATeam");

            migrationBuilder.DropTable(
                name: "PersonModels");

            migrationBuilder.DropTable(
                name: "ModelRoles");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
