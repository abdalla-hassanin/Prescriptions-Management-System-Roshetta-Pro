using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoshettaProAPI.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "BloodTypes",
                columns: table => new
                {
                    BloodTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodTypeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTypes", x => x.BloodTypeID);
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
                name: "Genders",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "MedicationForms",
                columns: table => new
                {
                    MedicationFormID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationForms", x => x.MedicationFormID);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    SpecializationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.SpecializationID);
                });

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    ClinicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Clinics_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID");
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
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmergencyContactID = table.Column<int>(type: "int", nullable: true),
                    BloodTypeID = table.Column<int>(type: "int", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patients_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_BloodTypes_BloodTypeID",
                        column: x => x.BloodTypeID,
                        principalTable: "BloodTypes",
                        principalColumn: "BloodTypeID");
                    table.ForeignKey(
                        name: "FK_Patients_Contacts_EmergencyContactID",
                        column: x => x.EmergencyContactID,
                        principalTable: "Contacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Genders_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Genders",
                        principalColumn: "GenderID");
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
                    MedicationFormID = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationID);
                    table.ForeignKey(
                        name: "FK_Medications_MedicationForms_MedicationFormID",
                        column: x => x.MedicationFormID,
                        principalTable: "MedicationForms",
                        principalColumn: "MedicationFormID");
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SpecializationID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClinicID = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Doctors_Specializations_SpecializationID",
                        column: x => x.SpecializationID,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationID");
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
                table: "Addresses",
                columns: new[] { "AddressID", "AddressLine1", "AddressLine2", "City", "Country", "CreatedBy", "CreatedTime", "PostalCode", "State", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "123 Main St", null, "Cairo", "Egypt", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5295), "11511", "Cairo", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5310) },
                    { 2, "456 Elm St", null, "Giza", "Egypt", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5315), "12511", "Giza", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5317) },
                    { 3, "789 Pine St", null, "Alexandria", "Egypt", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5320), "21521", "Alexandria", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5322) },
                    { 4, "101 Maple St", null, "Mansoura", "Egypt", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5324), "35511", "Dakahlia", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5326) },
                    { 5, "202 Cedar St", null, "Asyut", "Egypt", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5329), "71511", "Asyut", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5331) },
                    { 6, "303 Oak St", null, "Suez", "Egypt", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5333), "43511", "Suez", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5335) },
                    { 7, "404 Birch St", null, "Fayoum", "Egypt", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5338), "63511", "Fayoum", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5339) },
                    { 8, "505 Willow St", null, "Luxor", "Egypt", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5342), "85511", "Luxor", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5344) },
                    { 9, "606 Cherry St", null, "Aswan", "Egypt", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5346), "81511", "Aswan", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5348) },
                    { 10, "707 Palm St", null, "Hurghada", "Egypt", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5351), "84511", "Red Sea", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(5352) }
                });

            migrationBuilder.InsertData(
                table: "BloodTypes",
                columns: new[] { "BloodTypeID", "BloodTypeName" },
                values: new object[,]
                {
                    { 1, "A+" },
                    { 2, "A-" },
                    { 3, "B+" },
                    { 4, "B-" },
                    { 5, "AB+" },
                    { 6, "AB-" },
                    { 7, "O+" },
                    { 8, "O-" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactID", "CreatedBy", "CreatedTime", "Email", "Name", "PhoneNumber", "Relationship", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7328), "ahmed.ali@example.com", "Ahmed Ali", "+201000000001", "Brother", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7342) },
                    { 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7346), "sara.ahmed@example.com", "Sara Ahmed", "+201000000002", "Sister", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7347) },
                    { 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7350), "hassan.youssef@example.com", "Hassan Youssef", "+201000000003", "Father", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7352) },
                    { 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7355), "mona.khaled@example.com", "Mona Khaled", "+201000000004", "Mother", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7356) },
                    { 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7359), "omar.ibrahim@example.com", "Omar Ibrahim", "+201000000005", "Friend", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7361) },
                    { 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7363), "layla.nabil@example.com", "Layla Nabil", "+201000000006", "Cousin", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7365) },
                    { 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7367), "ali.maher@example.com", "Ali Maher", "+201000000007", "Uncle", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7369) },
                    { 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7372), "noha.saad@example.com", "Noha Saad", "+201000000008", "Aunt", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7373) },
                    { 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7376), "youssef.omar@example.com", "Youssef Omar", "+201000000009", "Nephew", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7378) },
                    { 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7380), "dina.yasser@example.com", "Dina Yasser", "+201000000010", "Niece", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(7382) }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderID", "GenderName" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "MedicationForms",
                columns: new[] { "MedicationFormID", "CreatedBy", "CreatedTime", "FormName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(932), "Tablet", null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(949) },
                    { 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(953), "Capsule", null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(955) },
                    { 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(957), "Syrup", null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(959) },
                    { 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(961), "Ointment", null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(963) },
                    { 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(965), "Injection", null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(967) },
                    { 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(969), "Suppository", null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(970) },
                    { 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(973), "Patch", null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(974) },
                    { 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(977), "Liquid", null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(978) },
                    { 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(980), "Powder", null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(982) },
                    { 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(984), "Gel", null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(986) },
                    { 11, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(988), "Lozenge", null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(990) }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "SpecializationID", "CreatedBy", "CreatedTime", "SpecializationName", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8393), "Cardiology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8413) },
                    { 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8417), "Dermatology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8419) },
                    { 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8422), "Endocrinology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8423) },
                    { 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8426), "Gastroenterology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8427) },
                    { 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8429), "Hematology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8431) },
                    { 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8433), "Neurology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8435) },
                    { 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8437), "Oncology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8439) },
                    { 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8441), "Ophthalmology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8443) },
                    { 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8445), "Orthopedics", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8447) },
                    { 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8449), "Pediatrics", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8450) },
                    { 11, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8453), "Psychiatry", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8454) },
                    { 12, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8456), "Pulmonology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8458) },
                    { 13, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8460), "Radiology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8462) },
                    { 14, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8464), "Rheumatology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8466) },
                    { 15, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8468), "Urology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8469) },
                    { 16, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8472), "Obstetrics and Gynecology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8473) },
                    { 17, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8476), "Nephrology", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8477) },
                    { 18, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8479), "General Surgery", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8481) },
                    { 19, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8483), "Plastic Surgery", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8485) },
                    { 20, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8487), "Emergency Medicine", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8489) },
                    { 21, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8491), "Geriatrics", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(8493) }
                });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "ClinicID", "AddressID", "CreatedBy", "CreatedTime", "Email", "Name", "PhoneNumber", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(972), "cairo.medical@example.com", "Cairo Medical Center", "+2021234567", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(988) },
                    { 2, 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(992), "giza.health@example.com", "Giza Health Clinic", "+2027654321", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(994) },
                    { 3, 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(997), "alex.family@example.com", "Alexandria Family Clinic", "+2034567890", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(999) },
                    { 4, 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1001), "mansoura.general@example.com", "Mansoura General Hospital", "+2051234567", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1003) },
                    { 5, 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1006), "asyut.specialist@example.com", "Asyut Specialist Clinic", "+2081234567", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1007) },
                    { 6, 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1010), "suez.healthcare@example.com", "Suez Healthcare", "+2067654321", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1011) },
                    { 7, 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1014), "fayoum.health@example.com", "Fayoum Health Center", "+2076543210", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1016) },
                    { 8, 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1018), "luxor.medical@example.com", "Luxor Medical Clinic", "+2091234567", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1020) },
                    { 9, 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1023), "aswan.care@example.com", "Aswan Care Clinic", "+2097654321", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1024) },
                    { 10, 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1027), "hurghada.wellness@example.com", "Hurghada Wellness Center", "+2098765432", null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(1029) }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "MedicationID", "CreatedBy", "CreatedTime", "Description", "MedicationFormID", "Name", "SideEffects", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8747), "Used for pain relief and fever reduction", 1, "Panadol", "Nausea, Allergic reactions", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8766) },
                    { 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8770), "Anti-inflammatory and blood thinner", 1, "Aspirin", "Gastrointestinal discomfort, Bleeding", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8772) },
                    { 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8777), "Antibiotic for bacterial infections", 2, "Augmentin", "Diarrhea, Allergic reactions", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8778) },
                    { 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8781), "Antibiotic for bacterial infections", 2, "Cipro", "Nausea, Diarrhea", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8783) },
                    { 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8786), "Insulin for diabetes management", 3, "Lantus", "Hypoglycemia, Weight gain", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8788) },
                    { 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8791), "Oral medication for type 2 diabetes", 3, "Glucophage", "Nausea, Diarrhea", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8792) },
                    { 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8795), "Bronchodilator for asthma relief", 4, "Ventolin", "Tremor, Palpitations", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8797) },
                    { 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8800), "Combination inhaler for asthma", 4, "Seretide", "Throat irritation, Hoarseness", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8802) },
                    { 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8805), "Statin for cholesterol management", 5, "Atorvastatin", "Muscle pain, Liver enzyme abnormalities", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8806) },
                    { 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8809), "Proton pump inhibitor for acid reflux", 6, "Omeprazole", "Headache, Abdominal pain", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8811) },
                    { 11, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8814), "Antibiotic for bacterial infections", 2, "Amoxicillin", "Nausea, Diarrhea", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8816) },
                    { 12, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8819), "Antibiotic for bacterial infections", 2, "Zinnat", "Nausea, Diarrhea", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8821) },
                    { 13, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8824), "Anticoagulant for preventing blood clots", 7, "Clexane", "Bleeding, Anemia", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8825) },
                    { 14, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8828), "Anticoagulant for preventing blood clots", 7, "Xarelto", "Bleeding, Nausea", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8830) },
                    { 15, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8833), "Statin for lowering cholesterol", 5, "Lipitor", "Muscle pain, Liver enzyme abnormalities", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8835) },
                    { 16, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8838), "Statin for lowering cholesterol", 5, "Crestor", "Muscle pain, Liver enzyme abnormalities", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8840) },
                    { 17, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8843), "Proton pump inhibitor for acid reflux", 6, "Nexium", "Headache, Abdominal pain", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8844) },
                    { 18, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8847), "H2 blocker for acid reflux", 6, "Zantac", "Headache, Dizziness", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8849) },
                    { 19, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8852), "Used for pain relief and fever reduction", 1, "Paracetamol", "Nausea, Allergic reactions", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8854) },
                    { 20, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8857), "Anti-inflammatory and pain relief", 1, "Ibuprofen", "Gastrointestinal discomfort, Bleeding", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8859) },
                    { 21, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8862), "Anti-inflammatory and pain relief", 1, "Voltaren", "Gastrointestinal discomfort, Skin rash", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8863) },
                    { 22, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8866), "Anti-inflammatory and pain relief", 1, "Brufen", "Gastrointestinal discomfort, Skin rash", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8868) },
                    { 23, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8871), "Antibiotic for anaerobic bacterial infections", 2, "Flagyl", "Nausea, Metallic taste", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8873) },
                    { 24, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8876), "Antibiotic for bacterial infections", 2, "Doxycycline", "Nausea, Photosensitivity", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8878) },
                    { 25, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8881), "Antibiotic for bacterial infections", 2, "Tavanic", "Nausea, Diarrhea", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8882) },
                    { 26, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8885), "Antibiotic for bacterial infections", 2, "Moxifloxacin", "Nausea, Dizziness", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8887) },
                    { 27, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8890), "Corticosteroid for inflammation and allergies", 8, "Prednisolone", "Weight gain, Mood swings", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8892) },
                    { 28, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8895), "Corticosteroid for inflammation and allergies", 8, "Hydrocortisone", "Weight gain, Skin thinning", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8897) },
                    { 29, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8901), "Immunosuppressant for rheumatoid arthritis", 9, "Methotrexate", "Nausea, Liver damage", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8902) },
                    { 30, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8905), "Immunosuppressant for rheumatoid arthritis", 9, "Humira", "Injection site reactions, Infections", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8907) },
                    { 31, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8909), "Immunosuppressant for rheumatoid arthritis", 9, "Enbrel", "Injection site reactions, Infections", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8911) },
                    { 32, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8914), "Immunosuppressant for rheumatoid arthritis", 9, "Plaquenil", "Nausea, Vision changes", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8916) },
                    { 33, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8918), "Antiviral for influenza", 10, "Tamiflu", "Nausea, Vomiting", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8920) },
                    { 34, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8922), "Antiviral for herpes infections", 10, "Zovirax", "Nausea, Diarrhea", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8924) },
                    { 35, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8927), "Antiviral for herpes infections", 10, "Valtrex", "Nausea, Headache", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8928) },
                    { 36, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8931), "Antiemetic for nausea and vomiting", 11, "Zofran", "Headache, Dizziness", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8932) },
                    { 37, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8935), "Antiemetic for nausea and vomiting", 11, "Domperidone", "Dry mouth, Drowsiness", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8937) },
                    { 38, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8939), "Calcium channel blocker for hypertension", 1, "Amlodipine", "Swelling, Dizziness", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8941) },
                    { 39, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8944), "ACE inhibitor for hypertension", 2, "Captopril", "Cough, Elevated blood potassium", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8946) },
                    { 40, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8949), "Angiotensin receptor blocker for hypertension", 3, "Losartan", "Dizziness, Back pain", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8950) },
                    { 41, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8954), "Calcium channel blocker for hypertension", 4, "Norvasc", "Swelling, Dizziness", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8956) },
                    { 42, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8959), "Diuretic for edema and hypertension", 5, "Lasix", "Dehydration, Electrolyte imbalance", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8961) },
                    { 43, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8964), "Potassium-sparing diuretic", 6, "Spironolactone", "Hyperkalemia, Gynecomastia", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8966) },
                    { 44, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8969), "Potassium-sparing diuretic", 7, "Aldactone", "Hyperkalemia, Gynecomastia", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8971) },
                    { 45, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8974), "Anticoagulant for preventing blood clots", 7, "Warfarin", "Bleeding, Nausea", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8975) },
                    { 46, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8978), "Anticoagulant for preventing blood clots", 7, "Heparin", "Bleeding, Anemia", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8980) },
                    { 47, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8984), "Hormone replacement for hypothyroidism", 8, "Levothyroxine", "Palpitations, Weight loss", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8986) },
                    { 48, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8989), "Hormone replacement for hypothyroidism", 9, "Euthyrox", "Palpitations, Weight loss", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8990) },
                    { 49, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8993), "Hormone replacement for hypothyroidism", 10, "Synthroid", "Palpitations, Weight loss", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8995) },
                    { 50, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(8998), "SNRI for depression and anxiety", 11, "Duloxetine", "Nausea, Dry mouth", null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(9000) }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "AddressID", "BloodTypeID", "CreatedBy", "CreatedTime", "DateOfBirth", "Email", "EmergencyContactID", "FirstName", "GenderID", "ImageURL", "LastName", "PhoneNumber", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, 1, 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(2963), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.ahmed@example.com", 1, "Youssef", 1, null, "Ahmed", "+201300000001", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3012) },
                    { 2, 2, 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3022), new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "amina.fathy@example.com", 2, "Amina", 2, null, "Fathy", "+201300000002", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3023) },
                    { 3, 3, 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3028), new DateTime(1988, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.nabil@example.com", 3, "Omar", 1, null, "Nabil", "+201300000003", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3029) },
                    { 4, 4, 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3033), new DateTime(1985, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "hassan.mahmoud@example.com", 4, "Hassan", 1, null, "Mahmoud", "+201300000004", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3035) },
                    { 5, 5, 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3039), new DateTime(1992, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "layla.omar@example.com", 5, "Layla", 2, null, "Omar", "+201300000005", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3041) },
                    { 6, 6, 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3045), new DateTime(1995, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed.maher@example.com", 6, "Ahmed", 1, null, "Maher", "+201300000006", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3047) },
                    { 7, 7, 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3050), new DateTime(1987, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "nada.ali@example.com", 7, "Nada", 2, null, "Ali", "+201300000007", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3052) },
                    { 8, 8, 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3056), new DateTime(1989, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mona.yasser@example.com", 8, "Mona", 2, null, "Yasser", "+201300000008", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3058) },
                    { 9, 9, 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3062), new DateTime(1983, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "hany.ibrahim@example.com", 9, "Hany", 1, null, "Ibrahim", "+201300000009", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3064) },
                    { 10, 10, 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3068), new DateTime(1991, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "dina.hassan@example.com", 10, "Dina", 2, null, "Hassan", "+201300000010", null, new DateTime(2024, 9, 2, 12, 32, 49, 985, DateTimeKind.Local).AddTicks(3070) }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "ClinicID", "CreatedBy", "CreatedTime", "Email", "FirstName", "ImageURL", "LastName", "PhoneNumber", "SpecializationID", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6505), "mohamed.hassan@example.com", "Mohamed", null, "Hassan", "+201200000001", 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6521) },
                    { 2, 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6526), "alaa.salem@example.com", "Alaa", null, "Salem", "+201200000002", 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6528) },
                    { 3, 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6531), "samir.youssef@example.com", "Samir", null, "Youssef", "+201200000003", 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6533) },
                    { 4, 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6577), "hassan.ibrahim@example.com", "Hassan", null, "Ibrahim", "+201200000004", 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6579) },
                    { 5, 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6582), "mona.nabil@example.com", "Mona", null, "Nabil", "+201200000005", 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6584) },
                    { 6, 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6587), "ahmed.mahmoud@example.com", "Ahmed", null, "Mahmoud", "+201200000006", 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6588) },
                    { 7, 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6591), "layla.omar@example.com", "Layla", null, "Omar", "+201200000007", 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6593) },
                    { 8, 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6596), "youssef.hassan@example.com", "Youssef", null, "Hassan", "+201200000008", 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6597) },
                    { 9, 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6600), "nada.ali@example.com", "Nada", null, "Ali", "+201200000009", 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6602) },
                    { 10, 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6605), "hany.maged@example.com", "Hany", null, "Maged", "+201200000010", 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 986, DateTimeKind.Local).AddTicks(6606) }
                });

            migrationBuilder.InsertData(
                table: "MedicalHistories",
                columns: new[] { "MedicalHistoryID", "CreatedBy", "CreatedTime", "Diagnosis", "DoctorID", "Notes", "PatientID", "UpdatedBy", "UpdatedTime", "VisitDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(9994), "Hypertension", 1, "Regular check-up", 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(11), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(17), "Diabetes", 2, "Diet recommended", 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(19), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(22), "Asthma", 3, "Inhaler prescribed", 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(24), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(27), "Migraine", 4, "Painkillers prescribed", 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(29), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(31), "Back Pain", 5, "Physiotherapy advised", 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(33), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(36), "Allergy", 6, "Antihistamines prescribed", 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(37), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(40), "High Cholesterol", 7, "Diet change advised", 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(42), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(45), "Anemia", 8, "Iron supplements prescribed", 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(46), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(50), "Flu", 9, "Rest and fluids advised", 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(51), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(54), "Arthritis", 10, "Pain management plan created", 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(56), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PatientXrays",
                columns: new[] { "XrayID", "CreatedBy", "CreatedTime", "DateTaken", "DoctorID", "LabName", "Notes", "PatientID", "UpdatedBy", "UpdatedTime", "XrayImageURL", "XrayType" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5515), new DateTime(2024, 8, 18, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5495), 1, "Cairo Lab", "Possible pneumonia", 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5517), "http://example.com/xray1.png", "Chest" },
                    { 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5523), new DateTime(2024, 8, 19, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5520), 2, "Alexandria Lab", "Spinal alignment check", 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5525), "http://example.com/xray2.png", "Spine" },
                    { 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5529), new DateTime(2024, 8, 20, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5527), 3, "Giza Lab", "ACL injury", 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5531), "http://example.com/xray3.png", "Knee" },
                    { 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5537), new DateTime(2024, 8, 21, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5534), 4, "Luxor Lab", "Head trauma", 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5538), "http://example.com/xray4.png", "Skull" },
                    { 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5544), new DateTime(2024, 8, 22, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5541), 5, "Aswan Lab", "Abdominal pain investigation", 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5545), "http://example.com/xray5.png", "Abdomen" },
                    { 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5550), new DateTime(2024, 8, 23, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5548), 6, "Cairo Lab", "Lung infection", 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5552), "http://example.com/xray6.png", "Chest" },
                    { 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5556), new DateTime(2024, 8, 24, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5554), 7, "Alexandria Lab", "Lower back pain", 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5558), "http://example.com/xray7.png", "Spine" },
                    { 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5563), new DateTime(2024, 8, 25, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5560), 8, "Giza Lab", "Post-surgery check", 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5564), "http://example.com/xray8.png", "Knee" },
                    { 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5569), new DateTime(2024, 8, 26, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5566), 9, "Luxor Lab", "Concussion follow-up", 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5571), "http://example.com/xray9.png", "Skull" },
                    { 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5577), new DateTime(2024, 8, 27, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5574), 10, "Aswan Lab", "Routine check", 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 989, DateTimeKind.Local).AddTicks(5578), "http://example.com/xray10.png", "Abdomen" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "PrescriptionID", "CreatedBy", "CreatedTime", "DateIssued", "DoctorID", "ExpirationDate", "Notes", "PatientID", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4507), new DateTime(2024, 8, 23, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4487), 1, null, "Take with food", 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4509) },
                    { 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4514), new DateTime(2024, 8, 24, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4512), 2, null, "Take before bed", 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4516) },
                    { 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4521), new DateTime(2024, 8, 25, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4519), 3, null, "Take every 8 hours", 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4523) },
                    { 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4529), new DateTime(2024, 8, 26, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4526), 4, null, "Take every morning", 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4531) },
                    { 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4535), new DateTime(2024, 8, 27, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4533), 5, null, "Take every night", 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4537) },
                    { 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4541), new DateTime(2024, 8, 28, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4539), 6, null, "Take before meals", 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4543) },
                    { 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4547), new DateTime(2024, 8, 29, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4545), 7, null, "Take every 12 hours", 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4549) },
                    { 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4554), new DateTime(2024, 8, 30, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4551), 8, null, "Take with water", 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4555) },
                    { 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4560), new DateTime(2024, 8, 31, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4558), 9, null, "Take on an empty stomach", 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4562) },
                    { 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4566), new DateTime(2024, 9, 1, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4564), 10, null, "Take before sleeping", 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 987, DateTimeKind.Local).AddTicks(4568) }
                });

            migrationBuilder.InsertData(
                table: "PrescriptionMedications",
                columns: new[] { "PrescriptionMedicationID", "CreatedBy", "CreatedTime", "Dosage", "DosageUnit", "EndDate", "Frequency", "Instructions", "MedicationID", "PrescriptionID", "StartDate", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5515), 500, "mg", new DateTime(2024, 9, 12, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5510), "Twice a day", "Take with food", 1, 1, new DateTime(2024, 8, 23, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5492), null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5517) },
                    { 2, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5525), 250, "mg", new DateTime(2024, 9, 11, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5523), "Once a day", "Take before bed", 2, 2, new DateTime(2024, 8, 24, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5521), null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5527) },
                    { 3, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5535), 100, "mg", new DateTime(2024, 9, 10, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5533), "Every 8 hours", "Take every 8 hours", 3, 3, new DateTime(2024, 8, 25, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5531), null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5536) },
                    { 4, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5543), 200, "mg", new DateTime(2024, 9, 9, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5541), "Every morning", "Take every morning", 4, 4, new DateTime(2024, 8, 26, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5539), null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5545) },
                    { 5, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5551), 150, "mg", new DateTime(2024, 9, 8, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5549), "Every night", "Take every night", 5, 5, new DateTime(2024, 8, 27, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5547), null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5553) },
                    { 6, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5560), 500, "mg", new DateTime(2024, 9, 7, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5558), "Before meals", "Take before meals", 6, 6, new DateTime(2024, 8, 28, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5556), null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5561) },
                    { 7, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5568), 100, "mg", new DateTime(2024, 9, 6, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5566), "Every 12 hours", "Take every 12 hours", 7, 7, new DateTime(2024, 8, 29, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5564), null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5569) },
                    { 8, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5576), 75, "mg", new DateTime(2024, 9, 5, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5574), "With water", "Take with water", 8, 8, new DateTime(2024, 8, 30, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5572), null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5577) },
                    { 9, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5584), 50, "mg", new DateTime(2024, 9, 4, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5582), "On an empty stomach", "Take on an empty stomach", 9, 9, new DateTime(2024, 8, 31, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5580), null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5585) },
                    { 10, null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5592), 300, "mg", new DateTime(2024, 9, 3, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5590), "Before sleeping", "Take before sleeping", 10, 10, new DateTime(2024, 9, 1, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5588), null, new DateTime(2024, 9, 2, 12, 32, 49, 988, DateTimeKind.Local).AddTicks(5594) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_AddressID",
                table: "Clinics",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ClinicID",
                table: "Doctors",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializationID",
                table: "Doctors",
                column: "SpecializationID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_DoctorID",
                table: "MedicalHistories",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PatientID",
                table: "MedicalHistories",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_MedicationFormID",
                table: "Medications",
                column: "MedicationFormID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressID",
                table: "Patients",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BloodTypeID",
                table: "Patients",
                column: "BloodTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_EmergencyContactID",
                table: "Patients",
                column: "EmergencyContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenderID",
                table: "Patients",
                column: "GenderID");

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
                name: "MedicationForms");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "BloodTypes");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
