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
                    ImageURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
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
                    EmergencyContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
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
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                table: "Doctors",
                columns: new[] { "DoctorID", "CreatedTime", "Email", "FirstName", "ImageURL", "LastName", "PhoneNumber", "Specialization", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(8941), "mohamed.hassan@example.com", "Mohamed", null, "Hassan", "+201200000001", 1, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(8967) },
                    { 2, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(8974), "alaa.salem@example.com", "Alaa", null, "Salem", "+201200000002", 2, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(8977) },
                    { 3, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(8982), "samir.youssef@example.com", "Samir", null, "Youssef", "+201200000003", 3, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(8985) },
                    { 4, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(8990), "hassan.ibrahim@example.com", "Hassan", null, "Ibrahim", "+201200000004", 4, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(8993) },
                    { 5, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(8997), "mona.nabil@example.com", "Mona", null, "Nabil", "+201200000005", 5, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(9001) },
                    { 6, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(9005), "ahmed.mahmoud@example.com", "Ahmed", null, "Mahmoud", "+201200000006", 6, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(9008) },
                    { 7, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(9013), "layla.omar@example.com", "Layla", null, "Omar", "+201200000007", 7, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(9016) },
                    { 8, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(9021), "youssef.hassan@example.com", "Youssef", null, "Hassan", "+201200000008", 8, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(9024) },
                    { 9, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(9028), "nada.ali@example.com", "Nada", null, "Ali", "+201200000009", 9, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(9031) },
                    { 10, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(9036), "hany.maged@example.com", "Hany", null, "Maged", "+201200000010", 10, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(9039) }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "MedicationID", "CreatedTime", "Description", "MedicationForm", "Name", "SideEffects", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4161), "Used for pain relief and fever reduction", 1, "Panadol", "Nausea, Allergic reactions", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4187) },
                    { 2, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4194), "Anti-inflammatory and blood thinner", 1, "Aspirin", "Gastrointestinal discomfort, Bleeding", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4197) },
                    { 3, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4202), "Antibiotic for bacterial infections", 2, "Amoxicillin", "Diarrhea, Allergic reactions", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4205) },
                    { 4, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4209), "Pain relief and fever reduction for children", 3, "Paracetamol Syrup", "Liver damage in high doses", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4212) },
                    { 5, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4217), "Topical treatment for skin inflammation", 4, "Hydrocortisone Cream", "Skin thinning, Allergic reactions", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4220) },
                    { 6, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4224), "Used for blood sugar control in diabetes", 5, "Insulin Injection", "Hypoglycemia, Allergic reactions", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4227) },
                    { 7, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4232), "Prevents nausea and vomiting", 6, "Ondansetron Suppository", "Headache, Fatigue", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4235) },
                    { 8, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4239), "Opioid pain medication for severe pain", 7, "Fentanyl Patch", "Drowsiness, Addiction", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4242) },
                    { 9, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4246), "Nonsteroidal anti-inflammatory drug (NSAID)", 8, "Ibuprofen Liquid", "Gastrointestinal discomfort, Kidney damage", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4249) },
                    { 10, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4254), "Fiber supplement for digestive health", 9, "Metamucil Powder", "Bloating, Gas", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4257) },
                    { 11, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4261), "Topical NSAID for pain and inflammation", 10, "Diclofenac Gel", "Skin irritation, Allergic reactions", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4264) },
                    { 12, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4268), "Sore throat relief", 2, "Throat Lozenges", "Mouth irritation, Allergic reactions", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4271) },
                    { 13, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4276), "Bronchodilator for asthma", 1, "Albuterol Inhaler", "Tremors, Increased heart rate", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4279) },
                    { 14, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4283), "Opioid pain relief for severe pain", 5, "Morphine Injection", "Drowsiness, Addiction", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4286) },
                    { 15, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4291), "Pain relief and fever reducer", 1, "Tylenol Tablet", "Liver damage in high doses", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4295) },
                    { 16, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4299), "Antifungal for skin infections", 4, "Miconazole Cream", "Skin irritation, Allergic reactions", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4302) },
                    { 17, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4307), "Antibiotic for bacterial infections", 1, "Penicillin Tablet", "Diarrhea, Allergic reactions", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4310) },
                    { 18, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4314), "Cough suppressant", 3, "Dextromethorphan Syrup", "Drowsiness, Dizziness", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4317) },
                    { 19, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4322), "Corticosteroid for inflammation", 8, "Prednisolone Oral Liquid", "Increased appetite, Mood changes", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4325) },
                    { 20, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4329), "Blood thinner to prevent clots", 1, "Warfarin Tablet", "Bleeding, Bruising", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4332) },
                    { 21, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4336), "Relieves heartburn and indigestion", 8, "Gaviscon Liquid", "Nausea, Constipation", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4339) },
                    { 22, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4344), "Antibiotic for serious bacterial infections", 2, "Clindamycin Capsule", "Diarrhea, Allergic reactions", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4346) },
                    { 23, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4351), "NSAID for pain and inflammation", 1, "Naproxen Tablet", "Gastrointestinal discomfort, Dizziness", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4354) },
                    { 24, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4530), "Antihistamine for allergy relief", 1, "Loratadine Tablet", "Dry mouth, Drowsiness", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4534) },
                    { 25, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4538), "Topical antibiotic for skin infections", 4, "Mupirocin Ointment", "Skin irritation, Burning", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4541) },
                    { 26, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4545), "Antihistamine for allergy relief", 3, "Cetirizine Syrup", "Drowsiness, Dry mouth", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4548) },
                    { 27, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4553), "Beta-blocker for blood pressure and anxiety", 1, "Propranolol Tablet", "Dizziness, Fatigue", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4556) },
                    { 28, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4560), "Proton pump inhibitor for acid reflux", 2, "Omeprazole Capsule", "Headache, Diarrhea", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4563) },
                    { 29, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4568), "Antibiotic for bacterial infections", 1, "Doxycycline Tablet", "Photosensitivity, Nausea", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4571) },
                    { 30, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4575), "H2 blocker for acid reflux", 1, "Ranitidine Tablet", "Headache, Constipation", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4578) },
                    { 31, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4584), "Antibiotic for urinary tract infections", 1, "Trimethoprim Tablet", "Nausea, Rash", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4587) },
                    { 32, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4591), "Antibiotic for anaerobic infections", 1, "Metronidazole Tablet", "Nausea, Metallic taste", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4594) },
                    { 33, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4598), "Topical retinoid for acne", 1, "Tretinoin Cream", "Skin irritation, Redness", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4601) },
                    { 34, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4606), "Antifungal shampoo for dandruff", 11, "Ketoconazole Shampoo", "Skin irritation, Dryness", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4609) },
                    { 35, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4613), "Antifungal for serious infections", 5, "Amphotericin B Injection", "Fever, Chills", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4616) },
                    { 36, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4621), "Hormone replacement for hypothyroidism", 1, "Levothyroxine Tablet", "Palpitations, Weight loss", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4624) },
                    { 37, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4628), "Antiviral for cold sores", 5, "Acyclovir Cream", "Skin irritation, Dryness", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4631) },
                    { 38, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4635), "Diuretic for fluid retention", 1, "Furosemide Tablet", "Dehydration, Electrolyte imbalance", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4638) },
                    { 39, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4643), "Antibiotic for bacterial infections", 1, "Azithromycin Tablet", "Nausea, Diarrhea", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4645) },
                    { 40, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4650), "Antibiotic for bacterial infections", 1, "Ciprofloxacin Tablet", "Nausea, Dizziness", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4653) },
                    { 41, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4657), "Antifungal for yeast infections", 2, "Fluconazole Capsule", "Nausea, Headache", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4660) },
                    { 42, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4664), "SNRI for depression and anxiety", 2, "Duloxetine Capsule", "Nausea, Dry mouth", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4667) },
                    { 43, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4672), "Proton pump inhibitor for acid reflux", 2, "Lansoprazole Capsule", "Headache, Diarrhea", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4675) },
                    { 44, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4679), "SSRI for depression and anxiety", 1, "Paroxetine Tablet", "Nausea, Drowsiness", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4682) },
                    { 45, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4687), "Used for nerve pain and seizures", 2, "Gabapentin Capsule", "Dizziness, Fatigue", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4690) },
                    { 46, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4694), "SNRI for depression and anxiety", 2, "Venlafaxine Capsule", "Nausea, Dry mouth", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4697) },
                    { 47, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4701), "Sleep aid for insomnia", 1, "Melatonin Tablet", "Drowsiness, Headache", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4704) },
                    { 48, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4709), "Sedative for short-term insomnia", 1, "Zolpidem Tablet", "Drowsiness, Dizziness", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4712) },
                    { 49, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4716), "Statin for cholesterol reduction", 1, "Simvastatin Tablet", "Muscle pain, Digestive issues", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4719) },
                    { 50, new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4723), "ACE inhibitor for blood pressure", 1, "Lisinopril Tablet", "Cough, Dizziness", new DateTime(2024, 9, 4, 19, 8, 0, 199, DateTimeKind.Local).AddTicks(4726) }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "Address", "BloodType", "CreatedTime", "DateOfBirth", "Email", "EmergencyContactName", "EmergencyContactPhone", "FirstName", "Gender", "ImageURL", "LastName", "PhoneNumber", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "123 Cairo Street, Cairo", 1, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4680), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.ahmed@example.com", "Ali Ahmed", "+201300000011", "Youssef", 1, null, "Ahmed", "+201300000001", new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4757) },
                    { 2, "456 Giza Road, Giza", 2, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4768), new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "amina.fathy@example.com", "Sara Fathy", "+201300000012", "Amina", 2, null, "Fathy", "+201300000002", new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4771) },
                    { 3, "789 Alexandria Avenue, Alexandria", 3, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4778), new DateTime(1988, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.nabil@example.com", "Nabil Omar", "+201300000013", "Omar", 1, null, "Nabil", "+201300000003", new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4781) },
                    { 4, "101 Mansoura Lane, Mansoura", 4, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4789), new DateTime(1985, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "hassan.mahmoud@example.com", "Mahmoud Hassan", "+201300000014", "Hassan", 1, null, "Mahmoud", "+201300000004", new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4792) },
                    { 5, "202 Asyut Street, Asyut", 5, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4799), new DateTime(1992, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "layla.omar@example.com", "Omar Layla", "+201300000015", "Layla", 2, null, "Omar", "+201300000005", new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4802) },
                    { 6, "303 Suez Road, Suez", 6, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4808), new DateTime(1995, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed.maher@example.com", "Maher Ahmed", "+201300000016", "Ahmed", 1, null, "Maher", "+201300000006", new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4811) },
                    { 7, "404 Fayoum Street, Fayoum", 7, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4819), new DateTime(1987, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "nada.ali@example.com", "Ali Nada", "+201300000017", "Nada", 2, null, "Ali", "+201300000007", new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4822) },
                    { 8, "505 Luxor Avenue, Luxor", 8, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4828), new DateTime(1989, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mona.yasser@example.com", "Yasser Mona", "+201300000018", "Mona", 2, null, "Yasser", "+201300000008", new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4831) },
                    { 9, "606 Aswan Road, Aswan", 1, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4838), new DateTime(1983, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "hany.ibrahim@example.com", "Ibrahim Hany", "+201300000019", "Hany", 1, null, "Ibrahim", "+201300000009", new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4841) },
                    { 10, "707 Hurghada Street, Hurghada", 5, new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4847), new DateTime(1991, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "dina.hassan@example.com", "Hassan Dina", "+201300000020", "Dina", 2, null, "Hassan", "+201300000010", new DateTime(2024, 9, 4, 19, 8, 0, 197, DateTimeKind.Local).AddTicks(4850) }
                });

            migrationBuilder.InsertData(
                table: "MedicalHistories",
                columns: new[] { "MedicalHistoryID", "CreatedTime", "Diagnosis", "DoctorID", "Notes", "PatientID", "UpdatedTime", "VisitDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(838), "Hypertension", 1, "Regular check-up", 1, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(868), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(875), "Diabetes", 2, "Diet recommended", 2, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(879), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(884), "Asthma", 3, "Inhaler prescribed", 3, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(887), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(892), "Migraine", 4, "Painkillers prescribed", 4, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(895), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(900), "Back Pain", 5, "Physiotherapy advised", 5, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(903), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(908), "Allergy", 6, "Antihistamines prescribed", 6, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(911), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(916), "High Cholesterol", 7, "Diet change advised", 7, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(919), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(923), "Anemia", 8, "Iron supplements prescribed", 8, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(926), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(931), "Flu", 9, "Rest and fluids advised", 9, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(934), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(939), "Arthritis", 10, "Pain management plan created", 10, new DateTime(2024, 9, 4, 19, 8, 0, 201, DateTimeKind.Local).AddTicks(942), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PatientXrays",
                columns: new[] { "XrayID", "CreatedTime", "DateTaken", "DoctorID", "LabName", "Notes", "PatientID", "UpdatedTime", "XrayImageURL", "XrayType" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(836), new DateTime(2024, 8, 20, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(796), 1, "Cairo Lab", "Possible pneumonia", 1, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(839), "http://example.com/xray1.png", "Chest" },
                    { 2, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(849), new DateTime(2024, 8, 21, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(844), 2, "Alexandria Lab", "Spinal alignment check", 2, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(852), "http://example.com/xray2.png", "Spine" },
                    { 3, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(861), new DateTime(2024, 8, 22, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(857), 3, "Giza Lab", "ACL injury", 3, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(864), "http://example.com/xray3.png", "Knee" },
                    { 4, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(873), new DateTime(2024, 8, 23, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(869), 4, "Luxor Lab", "Head trauma", 4, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(876), "http://example.com/xray4.png", "Skull" },
                    { 5, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(884), new DateTime(2024, 8, 24, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(880), 5, "Aswan Lab", "Abdominal pain investigation", 5, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(887), "http://example.com/xray5.png", "Abdomen" },
                    { 6, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(897), new DateTime(2024, 8, 25, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(892), 6, "Cairo Lab", "Lung infection", 6, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(900), "http://example.com/xray6.png", "Chest" },
                    { 7, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(908), new DateTime(2024, 8, 26, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(904), 7, "Alexandria Lab", "Lower back pain", 7, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(911), "http://example.com/xray7.png", "Spine" },
                    { 8, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(920), new DateTime(2024, 8, 27, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(915), 8, "Giza Lab", "Post-surgery check", 8, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(923), "http://example.com/xray8.png", "Knee" },
                    { 9, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(931), new DateTime(2024, 8, 28, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(927), 9, "Luxor Lab", "Concussion follow-up", 9, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(934), "http://example.com/xray9.png", "Skull" },
                    { 10, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(943), new DateTime(2024, 8, 29, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(938), 10, "Aswan Lab", "Routine check", 10, new DateTime(2024, 9, 4, 19, 8, 0, 202, DateTimeKind.Local).AddTicks(946), "http://example.com/xray10.png", "Abdomen" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "PrescriptionID", "CreatedTime", "DateIssued", "DoctorID", "ExpirationDate", "Notes", "PatientID", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9552), new DateTime(2024, 8, 25, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9513), 1, null, "Take with food", 1, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9556) },
                    { 2, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9565), new DateTime(2024, 8, 26, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9562), 2, null, "Take before bed", 2, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9568) },
                    { 3, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9576), new DateTime(2024, 8, 27, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9573), 3, null, "Take every 8 hours", 3, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9579) },
                    { 4, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9587), new DateTime(2024, 8, 28, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9583), 4, null, "Take every morning", 4, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9590) },
                    { 5, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9597), new DateTime(2024, 8, 29, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9594), 5, null, "Take every night", 5, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9600) },
                    { 6, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9608), new DateTime(2024, 8, 30, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9604), 6, null, "Take before meals", 6, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9611) },
                    { 7, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9618), new DateTime(2024, 8, 31, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9615), 7, null, "Take every 12 hours", 7, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9621) },
                    { 8, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9629), new DateTime(2024, 9, 1, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9625), 8, null, "Take with water", 8, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9632) },
                    { 9, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9640), new DateTime(2024, 9, 2, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9636), 9, null, "Take on an empty stomach", 9, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9643) },
                    { 10, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9650), new DateTime(2024, 9, 3, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9647), 10, null, "Take before sleeping", 10, new DateTime(2024, 9, 4, 19, 8, 0, 198, DateTimeKind.Local).AddTicks(9653) }
                });

            migrationBuilder.InsertData(
                table: "PrescriptionMedications",
                columns: new[] { "PrescriptionMedicationID", "CreatedTime", "Dosage", "DosageUnit", "EndDate", "Frequency", "Instructions", "MedicationID", "PrescriptionID", "StartDate", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2740), 500, "mg", new DateTime(2024, 9, 14, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2732), "Twice a day", "Take with food", 1, 1, new DateTime(2024, 8, 25, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2696), new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2744) },
                    { 2, new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2757), 250, "mg", new DateTime(2024, 9, 13, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2754), "Once a day", "Take before bed", 2, 2, new DateTime(2024, 8, 26, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2750), new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2761) },
                    { 3, new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2852), 100, "mg", new DateTime(2024, 9, 12, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2848), "Every 8 hours", "Take every 8 hours", 3, 3, new DateTime(2024, 8, 27, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2843), new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2855) },
                    { 4, new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2868), 200, "mg", new DateTime(2024, 9, 11, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2864), "Every morning", "Take every morning", 4, 4, new DateTime(2024, 8, 28, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2861), new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2871) },
                    { 5, new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2882), 150, "mg", new DateTime(2024, 9, 10, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2878), "Every night", "Take every night", 5, 5, new DateTime(2024, 8, 29, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2875), new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2885) },
                    { 6, new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2897), 500, "mg", new DateTime(2024, 9, 9, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2893), "Before meals", "Take before meals", 6, 6, new DateTime(2024, 8, 30, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2890), new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2900) },
                    { 7, new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2911), 100, "mg", new DateTime(2024, 9, 8, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2908), "Every 12 hours", "Take every 12 hours", 7, 7, new DateTime(2024, 8, 31, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2905), new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2914) },
                    { 8, new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2926), 75, "mg", new DateTime(2024, 9, 7, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2922), "With water", "Take with water", 8, 8, new DateTime(2024, 9, 1, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2919), new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2929) },
                    { 9, new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2941), 50, "mg", new DateTime(2024, 9, 6, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2937), "On an empty stomach", "Take on an empty stomach", 9, 9, new DateTime(2024, 9, 2, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2933), new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2943) },
                    { 10, new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2955), 300, "mg", new DateTime(2024, 9, 5, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2951), "Before sleeping", "Take before sleeping", 10, 10, new DateTime(2024, 9, 3, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2948), new DateTime(2024, 9, 4, 19, 8, 0, 200, DateTimeKind.Local).AddTicks(2958) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_DoctorID",
                table: "MedicalHistories",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PatientID",
                table: "MedicalHistories",
                column: "PatientID");

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
        }
    }
}
