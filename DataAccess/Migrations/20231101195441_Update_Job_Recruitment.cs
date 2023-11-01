using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update_Job_Recruitment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Employers_EmployerId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_JobSeekers_JobSeekerId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "JobSeekerId",
                table: "Accounts",
                newName: "job_seeker_id");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "Accounts",
                newName: "comp_id");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_JobSeekerId",
                table: "Accounts",
                newName: "IX_Accounts_job_seeker_id");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_EmployerId",
                table: "Accounts",
                newName: "IX_Accounts_comp_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Employers_comp_id",
                table: "Accounts",
                column: "comp_id",
                principalTable: "Employers",
                principalColumn: "comp_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_JobSeekers_job_seeker_id",
                table: "Accounts",
                column: "job_seeker_id",
                principalTable: "JobSeekers",
                principalColumn: "job_seeker_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Employers_comp_id",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_JobSeekers_job_seeker_id",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "job_seeker_id",
                table: "Accounts",
                newName: "JobSeekerId");

            migrationBuilder.RenameColumn(
                name: "comp_id",
                table: "Accounts",
                newName: "EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_job_seeker_id",
                table: "Accounts",
                newName: "IX_Accounts_JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_comp_id",
                table: "Accounts",
                newName: "IX_Accounts_EmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Employers_EmployerId",
                table: "Accounts",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "comp_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_JobSeekers_JobSeekerId",
                table: "Accounts",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "job_seeker_id");
        }
    }
}
