using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FixedPatientModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CovidAssessments_Patients_PatientId",
                table: "CovidAssessments");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "CovidAssessments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CovidAssessments_PatientId",
                table: "CovidAssessments",
                newName: "IX_CovidAssessments_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CovidAssessments_Users_UserId",
                table: "CovidAssessments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CovidAssessments_Users_UserId",
                table: "CovidAssessments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CovidAssessments",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_CovidAssessments_UserId",
                table: "CovidAssessments",
                newName: "IX_CovidAssessments_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_CovidAssessments_Patients_PatientId",
                table: "CovidAssessments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
