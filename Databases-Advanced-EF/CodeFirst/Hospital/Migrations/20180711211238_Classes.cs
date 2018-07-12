using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_HospitalDatabase.Migrations
{
    public partial class Classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Medicaments_MedicamentId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions");

            migrationBuilder.RenameTable(
                name: "Prescriptions",
                newName: "PatientMedicaments");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_MedicamentId",
                table: "PatientMedicaments",
                newName: "IX_PatientMedicaments_MedicamentId");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Visitations",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Patients",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Patients",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patients",
                type: "varchar(80)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Patients",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Medicaments",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Diagnoses",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Diagnoses",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientMedicaments",
                table: "PatientMedicaments",
                columns: new[] { "PatientId", "MedicamentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicaments_Medicaments_MedicamentId",
                table: "PatientMedicaments",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "MedicamentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicaments_Patients_PatientId",
                table: "PatientMedicaments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicaments_Medicaments_MedicamentId",
                table: "PatientMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicaments_Patients_PatientId",
                table: "PatientMedicaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientMedicaments",
                table: "PatientMedicaments");

            migrationBuilder.RenameTable(
                name: "PatientMedicaments",
                newName: "Prescriptions");

            migrationBuilder.RenameIndex(
                name: "IX_PatientMedicaments_MedicamentId",
                table: "Prescriptions",
                newName: "IX_Prescriptions_MedicamentId");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Visitations",
                type: "NVARCHAR(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Patients",
                type: "NVARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Patients",
                type: "NVARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patients",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Patients",
                type: "NVARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Medicaments",
                type: "NVARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Diagnoses",
                type: "NVARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Diagnoses",
                type: "NVARCHAR(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions",
                columns: new[] { "PatientId", "MedicamentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Medicaments_MedicamentId",
                table: "Prescriptions",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "MedicamentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_PatientId",
                table: "Prescriptions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
