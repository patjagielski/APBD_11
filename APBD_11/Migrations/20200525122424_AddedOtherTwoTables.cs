using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_11.Migrations
{
    public partial class AddedOtherTwoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicament", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medication",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false),
                    IdPrescription = table.Column<int>(nullable: false),
                    Dose = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    Prescription_MedicationIdMedicament = table.Column<int>(nullable: true),
                    Prescription_MedicationIdPrescription = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medication", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "FK_Prescription_Medication_Medicament_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicament",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Medication_Prescription_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "Prescription",
                        principalColumn: "IdPresciption",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Medication_Prescription_Medication_Prescription_MedicationIdMedicament_Prescription_MedicationIdPrescription",
                        columns: x => new { x.Prescription_MedicationIdMedicament, x.Prescription_MedicationIdPrescription },
                        principalTable: "Prescription_Medication",
                        principalColumns: new[] { "IdMedicament", "IdPrescription" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medication_IdPrescription",
                table: "Prescription_Medication",
                column: "IdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medication_Prescription_MedicationIdMedicament_Prescription_MedicationIdPrescription",
                table: "Prescription_Medication",
                columns: new[] { "Prescription_MedicationIdMedicament", "Prescription_MedicationIdPrescription" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medication");

            migrationBuilder.DropTable(
                name: "Medicament");
        }
    }
}
