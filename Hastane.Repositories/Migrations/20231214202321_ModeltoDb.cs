using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hastane.Repositories.Migrations
{
    public partial class ModeltoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Departments_DepartmentId",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Doktors_Departments_DepartmentId",
                table: "Doktors");

            migrationBuilder.DropIndex(
                name: "IX_Doktors_DepartmentId",
                table: "Doktors");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Doktors");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Doktors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Doktors_ClinicId",
                table: "Doktors",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Departments_DepartmentId",
                table: "Clinics",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doktors_Clinics_ClinicId",
                table: "Doktors",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Departments_DepartmentId",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Doktors_Clinics_ClinicId",
                table: "Doktors");

            migrationBuilder.DropIndex(
                name: "IX_Doktors_ClinicId",
                table: "Doktors");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Doktors");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Clinics");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Doktors",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Clinics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Doktors_DepartmentId",
                table: "Doktors",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Departments_DepartmentId",
                table: "Clinics",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktors_Departments_DepartmentId",
                table: "Doktors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
