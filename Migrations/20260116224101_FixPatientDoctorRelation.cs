using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class FixPatientDoctorRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments2_Doctors2_DoctorId",
                table: "Appointments2");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments2_Patients2_PatientId",
                table: "Appointments2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff2",
                table: "Staff2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescriptions2",
                table: "Prescriptions2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients2",
                table: "Patients2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors2",
                table: "Doctors2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinics2",
                table: "Clinics2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments2",
                table: "Appointments2");

            migrationBuilder.RenameTable(
                name: "Staff2",
                newName: "Staff");

            migrationBuilder.RenameTable(
                name: "Prescriptions2",
                newName: "Prescriptions");

            migrationBuilder.RenameTable(
                name: "Patients2",
                newName: "Patients");

            migrationBuilder.RenameTable(
                name: "Doctors2",
                newName: "Doctors");

            migrationBuilder.RenameTable(
                name: "Clinics2",
                newName: "Clinics");

            migrationBuilder.RenameTable(
                name: "Appointments2",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments2_PatientId",
                table: "Appointments",
                newName: "IX_Appointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments2_DoctorId",
                table: "Appointments",
                newName: "IX_Appointments_DoctorId");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryDoctorId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clinics",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DoctorClinic",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorClinic", x => new { x.DoctorId, x.ClinicId });
                    table.ForeignKey(
                        name: "FK_DoctorClinic_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorClinic_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PrimaryDoctorId",
                table: "Patients",
                column: "PrimaryDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Name",
                table: "Doctors",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_Name",
                table: "Clinics",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorClinic_ClinicId",
                table: "DoctorClinic",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_PrimaryDoctorId",
                table: "Patients",
                column: "PrimaryDoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_PrimaryDoctorId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "DoctorClinic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PrimaryDoctorId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_Name",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_Name",
                table: "Clinics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PrimaryDoctorId",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "Staff2");

            migrationBuilder.RenameTable(
                name: "Prescriptions",
                newName: "Prescriptions2");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Patients2");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "Doctors2");

            migrationBuilder.RenameTable(
                name: "Clinics",
                newName: "Clinics2");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointments2");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments2",
                newName: "IX_Appointments2_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments2",
                newName: "IX_Appointments2_DoctorId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctors2",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clinics2",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff2",
                table: "Staff2",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescriptions2",
                table: "Prescriptions2",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients2",
                table: "Patients2",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors2",
                table: "Doctors2",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinics2",
                table: "Clinics2",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments2",
                table: "Appointments2",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments2_Doctors2_DoctorId",
                table: "Appointments2",
                column: "DoctorId",
                principalTable: "Doctors2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments2_Patients2_PatientId",
                table: "Appointments2",
                column: "PatientId",
                principalTable: "Patients2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
