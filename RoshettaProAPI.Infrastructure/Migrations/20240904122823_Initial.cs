using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoshettaProAPI.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    ClinicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.ClinicID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SideEffects = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MedicationForm = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationID);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Specialization = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClinicID = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctors_Clinics_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "Clinics",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmergencyContactID = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patients_Contacts_EmergencyContactID",
                        column: x => x.EmergencyContactID,
                        principalTable: "Contacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    MedicalHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.MedicalHistoryID);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID");
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientXrays",
                columns: table => new
                {
                    XrayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    DateTaken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    XrayImageURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LabName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    XrayType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientXrays", x => x.XrayID);
                    table.ForeignKey(
                        name: "FK_PatientXrays_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID");
                    table.ForeignKey(
                        name: "FK_PatientXrays_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    PrescriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    DateIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID");
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionMedications",
                columns: table => new
                {
                    PrescriptionMedicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    MedicationID = table.Column<int>(type: "int", nullable: false),
                    Dosage = table.Column<int>(type: "int", nullable: false),
                    DosageUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedications", x => x.PrescriptionMedicationID);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedications_Medications_MedicationID",
                        column: x => x.MedicationID,
                        principalTable: "Medications",
                        principalColumn: "MedicationID");
                    table.ForeignKey(
                        name: "FK_PrescriptionMedications_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "ClinicID", "Address", "CreatedBy", "CreatedTime", "Email", "Name", "PhoneNumber", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "123 Cairo St, Cairo, Egypt", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7317), "cairo.medical@example.com", "Cairo Medical Center", "+2021234567", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7349) },
                    { 2, "456 Giza Rd, Giza, Egypt", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7359), "giza.health@example.com", "Giza Health Clinic", "+2027654321", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7363) },
                    { 3, "789 Alexandria Ave, Alexandria, Egypt", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7370), "alex.family@example.com", "Alexandria Family Clinic", "+2034567890", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7374) },
                    { 4, "101 Mansoura Blvd, Mansoura, Egypt", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7380), "mansoura.general@example.com", "Mansoura General Hospital", "+2051234567", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7384) },
                    { 5, "202 Asyut Rd, Asyut, Egypt", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7390), "asyut.specialist@example.com", "Asyut Specialist Clinic", "+2081234567", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7394) },
                    { 6, "303 Suez St, Suez, Egypt", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7400), "suez.healthcare@example.com", "Suez Healthcare", "+2067654321", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7404) },
                    { 7, "404 Fayoum Rd, Fayoum, Egypt", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7410), "fayoum.health@example.com", "Fayoum Health Center", "+2076543210", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7414) },
                    { 8, "505 Luxor St, Luxor, Egypt", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7420), "luxor.medical@example.com", "Luxor Medical Clinic", "+2091234567", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7424) },
                    { 9, "606 Aswan Ave, Aswan, Egypt", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7430), "aswan.care@example.com", "Aswan Care Clinic", "+2097654321", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7434) },
                    { 10, "707 Hurghada Blvd, Hurghada, Egypt", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7440), "hurghada.wellness@example.com", "Hurghada Wellness Center", "+2098765432", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(7444) }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactID", "CreatedBy", "CreatedTime", "Email", "Name", "PhoneNumber", "Relationship", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2616), "ahmed.ali@example.com", "Ahmed Ali", "+201000000001", "Brother", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2656) },
                    { 2, null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2665), "sara.ahmed@example.com", "Sara Ahmed", "+201000000002", "Sister", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2669) },
                    { 3, null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2676), "hassan.youssef@example.com", "Hassan Youssef", "+201000000003", "Father", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2680) },
                    { 4, null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2686), "mona.khaled@example.com", "Mona Khaled", "+201000000004", "Mother", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2690) },
                    { 5, null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2696), "omar.ibrahim@example.com", "Omar Ibrahim", "+201000000005", "Friend", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2700) },
                    { 6, null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2706), "layla.nabil@example.com", "Layla Nabil", "+201000000006", "Cousin", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2710) },
                    { 7, null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2716), "ali.maher@example.com", "Ali Maher", "+201000000007", "Uncle", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2720) },
                    { 8, null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2726), "noha.saad@example.com", "Noha Saad", "+201000000008", "Aunt", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2730) },
                    { 9, null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2735), "youssef.omar@example.com", "Youssef Omar", "+201000000009", "Nephew", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2740) },
                    { 10, null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2745), "dina.yasser@example.com", "Dina Yasser", "+201000000010", "Niece", null, new DateTime(2024, 9, 4, 15, 28, 18, 565, DateTimeKind.Local).AddTicks(2749) }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "MedicationID", "CreatedTime", "Description", "MedicationForm", "Name", "SideEffects", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(6823), "Used for pain relief and fever reduction", 1, "Panadol", "Nausea, Allergic reactions", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(6860) },
                    { 2, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(6870), "Anti-inflammatory and blood thinner", 1, "Aspirin", "Gastrointestinal discomfort, Bleeding", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(6874) },
                    { 3, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(6880), "Antibiotic for bacterial infections", 2, "Amoxicillin", "Diarrhea, Allergic reactions", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(6884) },
                    { 4, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(6890), "Pain relief and fever reduction for children", 3, "Paracetamol Syrup", "Liver damage in high doses", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(6894) },
                    { 5, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7093), "Topical treatment for skin inflammation", 4, "Hydrocortisone Cream", "Skin thinning, Allergic reactions", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7098) },
                    { 6, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7106), "Used for blood sugar control in diabetes", 5, "Insulin Injection", "Hypoglycemia, Allergic reactions", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7110) },
                    { 7, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7116), "Prevents nausea and vomiting", 6, "Ondansetron Suppository", "Headache, Fatigue", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7120) },
                    { 8, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7125), "Opioid pain medication for severe pain", 7, "Fentanyl Patch", "Drowsiness, Addiction", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7129) },
                    { 9, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7135), "Nonsteroidal anti-inflammatory drug (NSAID)", 8, "Ibuprofen Liquid", "Gastrointestinal discomfort, Kidney damage", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7139) },
                    { 10, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7145), "Fiber supplement for digestive health", 9, "Metamucil Powder", "Bloating, Gas", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7149) },
                    { 11, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7155), "Topical NSAID for pain and inflammation", 10, "Diclofenac Gel", "Skin irritation, Allergic reactions", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7159) },
                    { 12, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7165), "Sore throat relief", 2, "Throat Lozenges", "Mouth irritation, Allergic reactions", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7169) },
                    { 13, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7174), "Bronchodilator for asthma", 1, "Albuterol Inhaler", "Tremors, Increased heart rate", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7178) },
                    { 14, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7184), "Opioid pain relief for severe pain", 5, "Morphine Injection", "Drowsiness, Addiction", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7188) },
                    { 15, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7197), "Pain relief and fever reducer", 1, "Tylenol Tablet", "Liver damage in high doses", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7201) },
                    { 16, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7206), "Antifungal for skin infections", 4, "Miconazole Cream", "Skin irritation, Allergic reactions", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7210) },
                    { 17, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7216), "Antibiotic for bacterial infections", 1, "Penicillin Tablet", "Diarrhea, Allergic reactions", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7220) },
                    { 18, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7226), "Cough suppressant", 3, "Dextromethorphan Syrup", "Drowsiness, Dizziness", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7230) },
                    { 19, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7236), "Corticosteroid for inflammation", 8, "Prednisolone Oral Liquid", "Increased appetite, Mood changes", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7240) },
                    { 20, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7245), "Blood thinner to prevent clots", 1, "Warfarin Tablet", "Bleeding, Bruising", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7249) },
                    { 21, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7255), "Relieves heartburn and indigestion", 8, "Gaviscon Liquid", "Nausea, Constipation", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7259) },
                    { 22, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7265), "Antibiotic for serious bacterial infections", 2, "Clindamycin Capsule", "Diarrhea, Allergic reactions", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7269) },
                    { 23, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7274), "NSAID for pain and inflammation", 1, "Naproxen Tablet", "Gastrointestinal discomfort, Dizziness", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7278) },
                    { 24, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7284), "Antihistamine for allergy relief", 1, "Loratadine Tablet", "Dry mouth, Drowsiness", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7288) },
                    { 25, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7294), "Topical antibiotic for skin infections", 4, "Mupirocin Ointment", "Skin irritation, Burning", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7298) },
                    { 26, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7304), "Antihistamine for allergy relief", 3, "Cetirizine Syrup", "Drowsiness, Dry mouth", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7308) },
                    { 27, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7314), "Beta-blocker for blood pressure and anxiety", 1, "Propranolol Tablet", "Dizziness, Fatigue", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7318) },
                    { 28, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7324), "Proton pump inhibitor for acid reflux", 2, "Omeprazole Capsule", "Headache, Diarrhea", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7328) },
                    { 29, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7333), "Antibiotic for bacterial infections", 1, "Doxycycline Tablet", "Photosensitivity, Nausea", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7337) },
                    { 30, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7343), "H2 blocker for acid reflux", 1, "Ranitidine Tablet", "Headache, Constipation", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7348) },
                    { 31, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7354), "Antibiotic for urinary tract infections", 1, "Trimethoprim Tablet", "Nausea, Rash", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7358) },
                    { 32, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7364), "Antibiotic for anaerobic infections", 1, "Metronidazole Tablet", "Nausea, Metallic taste", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7368) },
                    { 33, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7373), "Topical retinoid for acne", 1, "Tretinoin Cream", "Skin irritation, Redness", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7377) },
                    { 34, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7383), "Antifungal shampoo for dandruff", 11, "Ketoconazole Shampoo", "Skin irritation, Dryness", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7387) },
                    { 35, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7393), "Antifungal for serious infections", 5, "Amphotericin B Injection", "Fever, Chills", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7397) },
                    { 36, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7402), "Hormone replacement for hypothyroidism", 1, "Levothyroxine Tablet", "Palpitations, Weight loss", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7406) },
                    { 37, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7412), "Antiviral for cold sores", 5, "Acyclovir Cream", "Skin irritation, Dryness", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7416) },
                    { 38, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7423), "Diuretic for fluid retention", 1, "Furosemide Tablet", "Dehydration, Electrolyte imbalance", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7426) },
                    { 39, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7432), "Antibiotic for bacterial infections", 1, "Azithromycin Tablet", "Nausea, Diarrhea", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7436) },
                    { 40, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7442), "Antibiotic for bacterial infections", 1, "Ciprofloxacin Tablet", "Nausea, Dizziness", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7446) },
                    { 41, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7451), "Antifungal for yeast infections", 2, "Fluconazole Capsule", "Nausea, Headache", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7455) },
                    { 42, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7462), "SNRI for depression and anxiety", 2, "Duloxetine Capsule", "Nausea, Dry mouth", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7465) },
                    { 43, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7474), "Proton pump inhibitor for acid reflux", 2, "Lansoprazole Capsule", "Headache, Diarrhea", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7477) },
                    { 44, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7483), "SSRI for depression and anxiety", 1, "Paroxetine Tablet", "Nausea, Drowsiness", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7487) },
                    { 45, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7495), "Used for nerve pain and seizures", 2, "Gabapentin Capsule", "Dizziness, Fatigue", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7499) },
                    { 46, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7507), "SNRI for depression and anxiety", 2, "Venlafaxine Capsule", "Nausea, Dry mouth", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7510) },
                    { 47, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7516), "Sleep aid for insomnia", 1, "Melatonin Tablet", "Drowsiness, Headache", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7520) },
                    { 48, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7525), "Sedative for short-term insomnia", 1, "Zolpidem Tablet", "Drowsiness, Dizziness", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7529) },
                    { 49, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7535), "Statin for cholesterol reduction", 1, "Simvastatin Tablet", "Muscle pain, Digestive issues", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7539) },
                    { 50, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7547), "ACE inhibitor for blood pressure", 1, "Lisinopril Tablet", "Cough, Dizziness", new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(7551) }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "ClinicID", "CreatedTime", "Email", "FirstName", "ImageURL", "LastName", "PhoneNumber", "Specialization", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6575), "mohamed.hassan@example.com", "Mohamed", null, "Hassan", "+201200000001", 1, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6612) },
                    { 2, 2, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6623), "alaa.salem@example.com", "Alaa", null, "Salem", "+201200000002", 2, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6627) },
                    { 3, 3, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6634), "samir.youssef@example.com", "Samir", null, "Youssef", "+201200000003", 3, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6638) },
                    { 4, 4, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6644), "hassan.ibrahim@example.com", "Hassan", null, "Ibrahim", "+201200000004", 4, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6648) },
                    { 5, 5, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6655), "mona.nabil@example.com", "Mona", null, "Nabil", "+201200000005", 5, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6659) },
                    { 6, 6, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6665), "ahmed.mahmoud@example.com", "Ahmed", null, "Mahmoud", "+201200000006", 6, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6669) },
                    { 7, 7, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6676), "layla.omar@example.com", "Layla", null, "Omar", "+201200000007", 7, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6680) },
                    { 8, 8, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6686), "youssef.hassan@example.com", "Youssef", null, "Hassan", "+201200000008", 8, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6690) },
                    { 9, 9, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6697), "nada.ali@example.com", "Nada", null, "Ali", "+201200000009", 9, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6701) },
                    { 10, 10, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6708), "hany.maged@example.com", "Hany", null, "Maged", "+201200000010", 10, new DateTime(2024, 9, 4, 15, 28, 18, 566, DateTimeKind.Local).AddTicks(6711) }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "Address", "BloodType", "CreatedTime", "DateOfBirth", "Email", "EmergencyContactID", "FirstName", "Gender", "ImageURL", "LastName", "PhoneNumber", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "123 Cairo Street, Cairo", 1, new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7115), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.ahmed@example.com", 1, "Youssef", 1, null, "Ahmed", "+201300000001", new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7199) },
                    { 2, "456 Giza Road, Giza", 2, new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7213), new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "amina.fathy@example.com", 2, "Amina", 2, null, "Fathy", "+201300000002", new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7217) },
                    { 3, "789 Alexandria Avenue, Alexandria", 3, new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7226), new DateTime(1988, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.nabil@example.com", 3, "Omar", 1, null, "Nabil", "+201300000003", new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7230) },
                    { 4, "101 Mansoura Lane, Mansoura", 4, new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7241), new DateTime(1985, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "hassan.mahmoud@example.com", 4, "Hassan", 1, null, "Mahmoud", "+201300000004", new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7245) },
                    { 5, "202 Asyut Street, Asyut", 5, new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7254), new DateTime(1992, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "layla.omar@example.com", 5, "Layla", 2, null, "Omar", "+201300000005", new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7258) },
                    { 6, "303 Suez Road, Suez", 6, new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7266), new DateTime(1995, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed.maher@example.com", 6, "Ahmed", 1, null, "Maher", "+201300000006", new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7270) },
                    { 7, "404 Fayoum Street, Fayoum", 7, new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7279), new DateTime(1987, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "nada.ali@example.com", 7, "Nada", 2, null, "Ali", "+201300000007", new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7283) },
                    { 8, "505 Luxor Avenue, Luxor", 8, new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7292), new DateTime(1989, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mona.yasser@example.com", 8, "Mona", 2, null, "Yasser", "+201300000008", new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7296) },
                    { 9, "606 Aswan Road, Aswan", 1, new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7435), new DateTime(1983, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "hany.ibrahim@example.com", 9, "Hany", 1, null, "Ibrahim", "+201300000009", new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7440) },
                    { 10, "707 Hurghada Street, Hurghada", 5, new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7449), new DateTime(1991, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "dina.hassan@example.com", 10, "Dina", 2, null, "Hassan", "+201300000010", new DateTime(2024, 9, 4, 15, 28, 18, 564, DateTimeKind.Local).AddTicks(7453) }
                });

            migrationBuilder.InsertData(
                table: "MedicalHistories",
                columns: new[] { "MedicalHistoryID", "CreatedBy", "CreatedTime", "Diagnosis", "DoctorID", "Notes", "PatientID", "UpdatedBy", "UpdatedTime", "VisitDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9815), "Hypertension", 1, "Regular check-up", 1, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9854), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9864), "Diabetes", 2, "Diet recommended", 2, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9869), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9876), "Asthma", 3, "Inhaler prescribed", 3, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9880), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9887), "Migraine", 4, "Painkillers prescribed", 4, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9891), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9897), "Back Pain", 5, "Physiotherapy advised", 5, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9901), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9908), "Allergy", 6, "Antihistamines prescribed", 6, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9912), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9919), "High Cholesterol", 7, "Diet change advised", 7, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9922), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9930), "Anemia", 8, "Iron supplements prescribed", 8, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9934), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9941), "Flu", 9, "Rest and fluids advised", 9, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9945), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9951), "Arthritis", 10, "Pain management plan created", 10, null, new DateTime(2024, 9, 4, 15, 28, 18, 570, DateTimeKind.Local).AddTicks(9955), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PatientXrays",
                columns: new[] { "XrayID", "CreatedBy", "CreatedTime", "DateTaken", "DoctorID", "LabName", "Notes", "PatientID", "UpdatedBy", "UpdatedTime", "XrayImageURL", "XrayType" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3000), new DateTime(2024, 8, 20, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(2958), 1, "Cairo Lab", "Possible pneumonia", 1, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3005), "http://example.com/xray1.png", "Chest" },
                    { 2, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3019), new DateTime(2024, 8, 21, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3013), 2, "Alexandria Lab", "Spinal alignment check", 2, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3023), "http://example.com/xray2.png", "Spine" },
                    { 3, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3034), new DateTime(2024, 8, 22, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3028), 3, "Giza Lab", "ACL injury", 3, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3038), "http://example.com/xray3.png", "Knee" },
                    { 4, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3048), new DateTime(2024, 8, 23, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3043), 4, "Luxor Lab", "Head trauma", 4, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3052), "http://example.com/xray4.png", "Skull" },
                    { 5, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3063), new DateTime(2024, 8, 24, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3057), 5, "Aswan Lab", "Abdominal pain investigation", 5, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3066), "http://example.com/xray5.png", "Abdomen" },
                    { 6, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3077), new DateTime(2024, 8, 25, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3071), 6, "Cairo Lab", "Lung infection", 6, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3081), "http://example.com/xray6.png", "Chest" },
                    { 7, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3092), new DateTime(2024, 8, 26, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3086), 7, "Alexandria Lab", "Lower back pain", 7, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3096), "http://example.com/xray7.png", "Spine" },
                    { 8, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3106), new DateTime(2024, 8, 27, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3101), 8, "Giza Lab", "Post-surgery check", 8, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3110), "http://example.com/xray8.png", "Knee" },
                    { 9, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3121), new DateTime(2024, 8, 28, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3115), 9, "Luxor Lab", "Concussion follow-up", 9, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3124), "http://example.com/xray9.png", "Skull" },
                    { 10, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3135), new DateTime(2024, 8, 29, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3130), 10, "Aswan Lab", "Routine check", 10, null, new DateTime(2024, 9, 4, 15, 28, 18, 572, DateTimeKind.Local).AddTicks(3139), "http://example.com/xray10.png", "Abdomen" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "PrescriptionID", "CreatedBy", "CreatedTime", "DateIssued", "DoctorID", "ExpirationDate", "Notes", "PatientID", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1386), new DateTime(2024, 8, 25, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1344), 1, null, "Take with food", 1, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1391) },
                    { 2, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1404), new DateTime(2024, 8, 26, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1399), 2, null, "Take before bed", 2, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1408) },
                    { 3, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1418), new DateTime(2024, 8, 27, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1414), 3, null, "Take every 8 hours", 3, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1422) },
                    { 4, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1432), new DateTime(2024, 8, 28, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1427), 4, null, "Take every morning", 4, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1436) },
                    { 5, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1446), new DateTime(2024, 8, 29, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1441), 5, null, "Take every night", 5, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1450) },
                    { 6, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1459), new DateTime(2024, 8, 30, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1455), 6, null, "Take before meals", 6, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1463) },
                    { 7, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1473), new DateTime(2024, 8, 31, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1469), 7, null, "Take every 12 hours", 7, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1477) },
                    { 8, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1487), new DateTime(2024, 9, 1, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1483), 8, null, "Take with water", 8, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1491) },
                    { 9, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1501), new DateTime(2024, 9, 2, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1497), 9, null, "Take on an empty stomach", 9, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1505) },
                    { 10, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1515), new DateTime(2024, 9, 3, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1511), 10, null, "Take before sleeping", 10, null, new DateTime(2024, 9, 4, 15, 28, 18, 568, DateTimeKind.Local).AddTicks(1519) }
                });

            migrationBuilder.InsertData(
                table: "PrescriptionMedications",
                columns: new[] { "PrescriptionMedicationID", "CreatedBy", "CreatedTime", "Dosage", "DosageUnit", "EndDate", "Frequency", "Instructions", "MedicationID", "PrescriptionID", "StartDate", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9151), 500, "mg", new DateTime(2024, 9, 14, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9141), "Twice a day", "Take with food", 1, 1, new DateTime(2024, 8, 25, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9100), null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9155) },
                    { 2, null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9173), 250, "mg", new DateTime(2024, 9, 13, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9168), "Once a day", "Take before bed", 2, 2, new DateTime(2024, 8, 26, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9164), null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9177) },
                    { 3, null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9193), 100, "mg", new DateTime(2024, 9, 12, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9188), "Every 8 hours", "Take every 8 hours", 3, 3, new DateTime(2024, 8, 27, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9184), null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9197) },
                    { 4, null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9212), 200, "mg", new DateTime(2024, 9, 11, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9207), "Every morning", "Take every morning", 4, 4, new DateTime(2024, 8, 28, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9203), null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9216) },
                    { 5, null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9231), 150, "mg", new DateTime(2024, 9, 10, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9226), "Every night", "Take every night", 5, 5, new DateTime(2024, 8, 29, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9222), null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9234) },
                    { 6, null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9249), 500, "mg", new DateTime(2024, 9, 9, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9245), "Before meals", "Take before meals", 6, 6, new DateTime(2024, 8, 30, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9240), null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9253) },
                    { 7, null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9268), 100, "mg", new DateTime(2024, 9, 8, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9264), "Every 12 hours", "Take every 12 hours", 7, 7, new DateTime(2024, 8, 31, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9259), null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9272) },
                    { 8, null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9287), 75, "mg", new DateTime(2024, 9, 7, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9283), "With water", "Take with water", 8, 8, new DateTime(2024, 9, 1, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9278), null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9291) },
                    { 9, null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9306), 50, "mg", new DateTime(2024, 9, 6, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9301), "On an empty stomach", "Take on an empty stomach", 9, 9, new DateTime(2024, 9, 2, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9297), null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9310) },
                    { 10, null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9325), 300, "mg", new DateTime(2024, 9, 5, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9320), "Before sleeping", "Take before sleeping", 10, 10, new DateTime(2024, 9, 3, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9316), null, new DateTime(2024, 9, 4, 15, 28, 18, 569, DateTimeKind.Local).AddTicks(9329) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ClinicID",
                table: "Doctors",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_DoctorID",
                table: "MedicalHistories",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PatientID",
                table: "MedicalHistories",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_EmergencyContactID",
                table: "Patients",
                column: "EmergencyContactID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientXrays_DoctorID",
                table: "PatientXrays",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientXrays_PatientID",
                table: "PatientXrays",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedications_MedicationID",
                table: "PrescriptionMedications",
                column: "MedicationID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedications_PrescriptionID",
                table: "PrescriptionMedications",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorID",
                table: "Prescriptions",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientID",
                table: "Prescriptions",
                column: "PatientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "PatientXrays");

            migrationBuilder.DropTable(
                name: "PrescriptionMedications");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
