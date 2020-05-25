using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_11.Migrations
{
    public partial class AddedPatientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPatient",
                table: "Prescription",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionIdPresciption",
                table: "Prescription",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    IdPatient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.IdPatient);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdPatient",
                table: "Prescription",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PrescriptionIdPresciption",
                table: "Prescription",
                column: "PrescriptionIdPresciption");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Patient_IdPatient",
                table: "Prescription",
                column: "IdPatient",
                principalTable: "Patient",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Prescription_PrescriptionIdPresciption",
                table: "Prescription",
                column: "PrescriptionIdPresciption",
                principalTable: "Prescription",
                principalColumn: "IdPresciption",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Patient_IdPatient",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Prescription_PrescriptionIdPresciption",
                table: "Prescription");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_IdPatient",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_PrescriptionIdPresciption",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "IdPatient",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "PrescriptionIdPresciption",
                table: "Prescription");
        }
    }
}
