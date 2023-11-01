using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Job_Recruitment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    comp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comp_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    comp_address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    comp_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comp_logoURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.comp_id);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekers",
                columns: table => new
                {
                    job_seeker_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resume_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    skills = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekers", x => x.job_seeker_id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    job_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    job_title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    job_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    job_requirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    job_location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    job_salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    application_deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    job_time_type = table.Column<int>(type: "int", nullable: false),
                    comp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.job_id);
                    table.ForeignKey(
                        name: "FK_Jobs_Employers_comp_id",
                        column: x => x.comp_id,
                        principalTable: "Employers",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    acc_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email_address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    user_type = table.Column<int>(type: "int", nullable: false),
                    JobSeekerId = table.Column<int>(type: "int", nullable: true),
                    EmployerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.acc_id);
                    table.ForeignKey(
                        name: "FK_Accounts_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "comp_id");
                    table.ForeignKey(
                        name: "FK_Accounts_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "job_seeker_id");
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    resume_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resume_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    resume_content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resume_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job_seeker_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.resume_id);
                    table.ForeignKey(
                        name: "FK_Resumes_JobSeekers_job_seeker_id",
                        column: x => x.job_seeker_id,
                        principalTable: "JobSeekers",
                        principalColumn: "job_seeker_id");
                });

            migrationBuilder.CreateTable(
                name: "JobApplicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    job_id = table.Column<int>(type: "int", nullable: true),
                    job_seeker_id = table.Column<int>(type: "int", nullable: true),
                    application_status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplicants_JobSeekers_job_seeker_id",
                        column: x => x.job_seeker_id,
                        principalTable: "JobSeekers",
                        principalColumn: "job_seeker_id");
                    table.ForeignKey(
                        name: "FK_JobApplicants_Jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "Jobs",
                        principalColumn: "job_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EmployerId",
                table: "Accounts",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_JobSeekerId",
                table: "Accounts",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplicants_job_id",
                table: "JobApplicants",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplicants_job_seeker_id",
                table: "JobApplicants",
                column: "job_seeker_id");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_comp_id",
                table: "Jobs",
                column: "comp_id");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_job_seeker_id",
                table: "Resumes",
                column: "job_seeker_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "JobApplicants");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "JobSeekers");

            migrationBuilder.DropTable(
                name: "Employers");
        }
    }
}
