using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Job_Recruitment_v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowedEmployers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Employers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "JobSeekers",
                newName: "FullName");

            migrationBuilder.AddColumn<bool>(
                name: "IsEmployer",
                table: "JobSeekers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmployer",
                table: "JobSeekers");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "JobSeekers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "JobSeekers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "JobSeekers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Employers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FollowedEmployers",
                columns: table => new
                {
                    FollowedEmployerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    JobSeekerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowedEmployers", x => x.FollowedEmployerId);
                    table.ForeignKey(
                        name: "FK_FollowedEmployers_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "EmployerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowedEmployers_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "JobSeekerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowedEmployers_EmployerId",
                table: "FollowedEmployers",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowedEmployers_JobSeekerId",
                table: "FollowedEmployers",
                column: "JobSeekerId");
        }
    }
}
