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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33aa2b17-d015-46a9-aaea-5d49158b1c0a", null, "Patient", "PATIENT" },
                    { "c82d6f15-3890-414f-83af-3b16f2b36761", null, "Doctor", "DOCTOR" },
                    { "d6b9438c-71ff-41b2-96ff-86759f7b8ba2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "CreatedTime", "Email", "FirstName", "ImageURL", "LastName", "PhoneNumber", "Specialization", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9068), "mohamed.hassan@example.com", "Mohamed", null, "Hassan", "+201200000001", 1, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9092) },
                    { 2, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9096), "alaa.salem@example.com", "Alaa", null, "Salem", "+201200000002", 2, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9098) },
                    { 3, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9100), "samir.youssef@example.com", "Samir", null, "Youssef", "+201200000003", 3, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9102) },
                    { 4, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9105), "hassan.ibrahim@example.com", "Hassan", null, "Ibrahim", "+201200000004", 4, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9107) },
                    { 5, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9109), "mona.nabil@example.com", "Mona", null, "Nabil", "+201200000005", 5, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9111) },
                    { 6, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9114), "ahmed.mahmoud@example.com", "Ahmed", null, "Mahmoud", "+201200000006", 6, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9116) },
                    { 7, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9118), "layla.omar@example.com", "Layla", null, "Omar", "+201200000007", 7, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9120) },
                    { 8, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9123), "youssef.hassan@example.com", "Youssef", null, "Hassan", "+201200000008", 8, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9124) },
                    { 9, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9127), "nada.ali@example.com", "Nada", null, "Ali", "+201200000009", 9, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9129) },
                    { 10, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9131), "hany.maged@example.com", "Hany", null, "Maged", "+201200000010", 10, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(9133) }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "MedicationID", "CreatedTime", "Description", "MedicationForm", "Name", "SideEffects", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6787), "Used for pain relief and fever reduction", 1, "Panadol", "Nausea, Allergic reactions", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6800) },
                    { 2, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6805), "Anti-inflammatory and blood thinner", 1, "Aspirin", "Gastrointestinal discomfort, Bleeding", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6806) },
                    { 3, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6809), "Antibiotic for bacterial infections", 2, "Amoxicillin", "Diarrhea, Allergic reactions", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6811) },
                    { 4, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6814), "Pain relief and fever reduction for children", 3, "Paracetamol Syrup", "Liver damage in high doses", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6816) },
                    { 5, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6818), "Topical treatment for skin inflammation", 4, "Hydrocortisone Cream", "Skin thinning, Allergic reactions", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6820) },
                    { 6, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6823), "Used for blood sugar control in diabetes", 5, "Insulin Injection", "Hypoglycemia, Allergic reactions", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6824) },
                    { 7, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6827), "Prevents nausea and vomiting", 6, "Ondansetron Suppository", "Headache, Fatigue", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6829) },
                    { 8, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6832), "Opioid pain medication for severe pain", 7, "Fentanyl Patch", "Drowsiness, Addiction", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6834) },
                    { 9, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6836), "Nonsteroidal anti-inflammatory drug (NSAID)", 8, "Ibuprofen Liquid", "Gastrointestinal discomfort, Kidney damage", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6838) },
                    { 10, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6840), "Fiber supplement for digestive health", 9, "Metamucil Powder", "Bloating, Gas", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6842) },
                    { 11, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6844), "Topical NSAID for pain and inflammation", 10, "Diclofenac Gel", "Skin irritation, Allergic reactions", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6846) },
                    { 12, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6849), "Sore throat relief", 2, "Throat Lozenges", "Mouth irritation, Allergic reactions", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6851) },
                    { 13, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6853), "Bronchodilator for asthma", 1, "Albuterol Inhaler", "Tremors, Increased heart rate", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6855) },
                    { 14, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6858), "Opioid pain relief for severe pain", 5, "Morphine Injection", "Drowsiness, Addiction", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6860) },
                    { 15, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6863), "Pain relief and fever reducer", 1, "Tylenol Tablet", "Liver damage in high doses", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6865) },
                    { 16, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6867), "Antifungal for skin infections", 4, "Miconazole Cream", "Skin irritation, Allergic reactions", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6869) },
                    { 17, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6871), "Antibiotic for bacterial infections", 1, "Penicillin Tablet", "Diarrhea, Allergic reactions", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6873) },
                    { 18, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6875), "Cough suppressant", 3, "Dextromethorphan Syrup", "Drowsiness, Dizziness", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6877) },
                    { 19, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6880), "Corticosteroid for inflammation", 8, "Prednisolone Oral Liquid", "Increased appetite, Mood changes", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6881) },
                    { 20, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6884), "Blood thinner to prevent clots", 1, "Warfarin Tablet", "Bleeding, Bruising", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6886) },
                    { 21, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6888), "Relieves heartburn and indigestion", 8, "Gaviscon Liquid", "Nausea, Constipation", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6890) },
                    { 22, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6892), "Antibiotic for serious bacterial infections", 2, "Clindamycin Capsule", "Diarrhea, Allergic reactions", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6894) },
                    { 23, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6897), "NSAID for pain and inflammation", 1, "Naproxen Tablet", "Gastrointestinal discomfort, Dizziness", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6898) },
                    { 24, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6901), "Antihistamine for allergy relief", 1, "Loratadine Tablet", "Dry mouth, Drowsiness", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6902) },
                    { 25, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6905), "Topical antibiotic for skin infections", 4, "Mupirocin Ointment", "Skin irritation, Burning", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6907) },
                    { 26, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6909), "Antihistamine for allergy relief", 3, "Cetirizine Syrup", "Drowsiness, Dry mouth", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6911) },
                    { 27, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6913), "Beta-blocker for blood pressure and anxiety", 1, "Propranolol Tablet", "Dizziness, Fatigue", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6915) },
                    { 28, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6917), "Proton pump inhibitor for acid reflux", 2, "Omeprazole Capsule", "Headache, Diarrhea", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6919) },
                    { 29, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6922), "Antibiotic for bacterial infections", 1, "Doxycycline Tablet", "Photosensitivity, Nausea", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6924) },
                    { 30, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6927), "H2 blocker for acid reflux", 1, "Ranitidine Tablet", "Headache, Constipation", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6928) },
                    { 31, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6931), "Antibiotic for urinary tract infections", 1, "Trimethoprim Tablet", "Nausea, Rash", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6933) },
                    { 32, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6935), "Antibiotic for anaerobic infections", 1, "Metronidazole Tablet", "Nausea, Metallic taste", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6937) },
                    { 33, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6939), "Topical retinoid for acne", 1, "Tretinoin Cream", "Skin irritation, Redness", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6941) },
                    { 34, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6943), "Antifungal shampoo for dandruff", 11, "Ketoconazole Shampoo", "Skin irritation, Dryness", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(6945) },
                    { 35, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7031), "Antifungal for serious infections", 5, "Amphotericin B Injection", "Fever, Chills", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7033) },
                    { 36, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7036), "Hormone replacement for hypothyroidism", 1, "Levothyroxine Tablet", "Palpitations, Weight loss", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7037) },
                    { 37, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7040), "Antiviral for cold sores", 5, "Acyclovir Cream", "Skin irritation, Dryness", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7041) },
                    { 38, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7044), "Diuretic for fluid retention", 1, "Furosemide Tablet", "Dehydration, Electrolyte imbalance", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7046) },
                    { 39, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7048), "Antibiotic for bacterial infections", 1, "Azithromycin Tablet", "Nausea, Diarrhea", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7050) },
                    { 40, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7052), "Antibiotic for bacterial infections", 1, "Ciprofloxacin Tablet", "Nausea, Dizziness", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7054) },
                    { 41, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7056), "Antifungal for yeast infections", 2, "Fluconazole Capsule", "Nausea, Headache", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7058) },
                    { 42, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7060), "SNRI for depression and anxiety", 2, "Duloxetine Capsule", "Nausea, Dry mouth", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7062) },
                    { 43, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7065), "Proton pump inhibitor for acid reflux", 2, "Lansoprazole Capsule", "Headache, Diarrhea", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7066) },
                    { 44, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7069), "SSRI for depression and anxiety", 1, "Paroxetine Tablet", "Nausea, Drowsiness", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7070) },
                    { 45, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7073), "Used for nerve pain and seizures", 2, "Gabapentin Capsule", "Dizziness, Fatigue", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7075) },
                    { 46, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7078), "SNRI for depression and anxiety", 2, "Venlafaxine Capsule", "Nausea, Dry mouth", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7079) },
                    { 47, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7082), "Sleep aid for insomnia", 1, "Melatonin Tablet", "Drowsiness, Headache", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7083) },
                    { 48, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7086), "Sedative for short-term insomnia", 1, "Zolpidem Tablet", "Drowsiness, Dizziness", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7088) },
                    { 49, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7090), "Statin for cholesterol reduction", 1, "Simvastatin Tablet", "Muscle pain, Digestive issues", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7092) },
                    { 50, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7094), "ACE inhibitor for blood pressure", 1, "Lisinopril Tablet", "Cough, Dizziness", new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(7096) }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "Address", "BloodType", "CreatedTime", "DateOfBirth", "Email", "EmergencyContactName", "EmergencyContactPhone", "FirstName", "Gender", "ImageURL", "LastName", "PhoneNumber", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "123 Cairo Street, Cairo", 1, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6120), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.ahmed@example.com", "Ali Ahmed", "+201300000011", "Youssef", 1, null, "Ahmed", "+201300000001", new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6399) },
                    { 2, "456 Giza Road, Giza", 2, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6404), new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "amina.fathy@example.com", "Sara Fathy", "+201300000012", "Amina", 2, null, "Fathy", "+201300000002", new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6405) },
                    { 3, "789 Alexandria Avenue, Alexandria", 3, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6410), new DateTime(1988, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.nabil@example.com", "Nabil Omar", "+201300000013", "Omar", 1, null, "Nabil", "+201300000003", new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6411) },
                    { 4, "101 Mansoura Lane, Mansoura", 4, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6415), new DateTime(1985, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "hassan.mahmoud@example.com", "Mahmoud Hassan", "+201300000014", "Hassan", 1, null, "Mahmoud", "+201300000004", new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6416) },
                    { 5, "202 Asyut Street, Asyut", 5, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6420), new DateTime(1992, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "layla.omar@example.com", "Omar Layla", "+201300000015", "Layla", 2, null, "Omar", "+201300000005", new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6421) },
                    { 6, "303 Suez Road, Suez", 6, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6425), new DateTime(1995, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed.maher@example.com", "Maher Ahmed", "+201300000016", "Ahmed", 1, null, "Maher", "+201300000006", new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6426) },
                    { 7, "404 Fayoum Street, Fayoum", 7, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6431), new DateTime(1987, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "nada.ali@example.com", "Ali Nada", "+201300000017", "Nada", 2, null, "Ali", "+201300000007", new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6433) },
                    { 8, "505 Luxor Avenue, Luxor", 8, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6437), new DateTime(1989, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mona.yasser@example.com", "Yasser Mona", "+201300000018", "Mona", 2, null, "Yasser", "+201300000008", new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6438) },
                    { 9, "606 Aswan Road, Aswan", 1, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6442), new DateTime(1983, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "hany.ibrahim@example.com", "Ibrahim Hany", "+201300000019", "Hany", 1, null, "Ibrahim", "+201300000009", new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6444) },
                    { 10, "707 Hurghada Street, Hurghada", 5, new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6447), new DateTime(1991, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "dina.hassan@example.com", "Hassan Dina", "+201300000020", "Dina", 2, null, "Hassan", "+201300000010", new DateTime(2024, 9, 8, 11, 33, 44, 973, DateTimeKind.Local).AddTicks(6449) }
                });

            migrationBuilder.InsertData(
                table: "MedicalHistories",
                columns: new[] { "MedicalHistoryID", "CreatedTime", "Diagnosis", "DoctorID", "Notes", "PatientID", "UpdatedTime", "VisitDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5463), "Hypertension", 1, "Regular check-up", 1, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5476), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5480), "Diabetes", 2, "Diet recommended", 2, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5482), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5485), "Asthma", 3, "Inhaler prescribed", 3, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5487), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5489), "Migraine", 4, "Painkillers prescribed", 4, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5491), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5493), "Back Pain", 5, "Physiotherapy advised", 5, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5495), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5497), "Allergy", 6, "Antihistamines prescribed", 6, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5499), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5501), "High Cholesterol", 7, "Diet change advised", 7, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5503), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5506), "Anemia", 8, "Iron supplements prescribed", 8, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5507), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5510), "Flu", 9, "Rest and fluids advised", 9, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5511), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5514), "Arthritis", 10, "Pain management plan created", 10, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(5516), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PatientXrays",
                columns: new[] { "XrayID", "CreatedTime", "DateTaken", "DoctorID", "LabName", "Notes", "PatientID", "UpdatedTime", "XrayImageURL", "XrayType" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9695), new DateTime(2024, 8, 24, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9679), 1, "Cairo Lab", "Possible pneumonia", 1, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9697), "http://example.com/xray1.png", "Chest" },
                    { 2, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9702), new DateTime(2024, 8, 25, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9700), 2, "Alexandria Lab", "Spinal alignment check", 2, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9704), "http://example.com/xray2.png", "Spine" },
                    { 3, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9709), new DateTime(2024, 8, 26, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9706), 3, "Giza Lab", "ACL injury", 3, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9710), "http://example.com/xray3.png", "Knee" },
                    { 4, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9714), new DateTime(2024, 8, 27, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9712), 4, "Luxor Lab", "Head trauma", 4, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9716), "http://example.com/xray4.png", "Skull" },
                    { 5, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9720), new DateTime(2024, 8, 28, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9718), 5, "Aswan Lab", "Abdominal pain investigation", 5, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9722), "http://example.com/xray5.png", "Abdomen" },
                    { 6, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9726), new DateTime(2024, 8, 29, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9724), 6, "Cairo Lab", "Lung infection", 6, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9727), "http://example.com/xray6.png", "Chest" },
                    { 7, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9731), new DateTime(2024, 8, 30, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9729), 7, "Alexandria Lab", "Lower back pain", 7, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9733), "http://example.com/xray7.png", "Spine" },
                    { 8, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9737), new DateTime(2024, 8, 31, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9735), 8, "Giza Lab", "Post-surgery check", 8, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9739), "http://example.com/xray8.png", "Knee" },
                    { 9, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9743), new DateTime(2024, 9, 1, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9741), 9, "Luxor Lab", "Concussion follow-up", 9, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9744), "http://example.com/xray9.png", "Skull" },
                    { 10, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9749), new DateTime(2024, 9, 2, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9746), 10, "Aswan Lab", "Routine check", 10, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(9750), "http://example.com/xray10.png", "Abdomen" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "PrescriptionID", "CreatedTime", "DateIssued", "DoctorID", "ExpirationDate", "Notes", "PatientID", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4823), new DateTime(2024, 8, 29, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4805), 1, null, "Take with food", 1, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4825) },
                    { 2, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4831), new DateTime(2024, 8, 30, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4829), 2, null, "Take before bed", 2, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4832) },
                    { 3, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4837), new DateTime(2024, 8, 31, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4835), 3, null, "Take every 8 hours", 3, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4839) },
                    { 4, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4843), new DateTime(2024, 9, 1, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4841), 4, null, "Take every morning", 4, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4845) },
                    { 5, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4849), new DateTime(2024, 9, 2, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4847), 5, null, "Take every night", 5, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4851) },
                    { 6, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4856), new DateTime(2024, 9, 3, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4854), 6, null, "Take before meals", 6, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4857) },
                    { 7, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4862), new DateTime(2024, 9, 4, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4860), 7, null, "Take every 12 hours", 7, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4863) },
                    { 8, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4868), new DateTime(2024, 9, 5, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4866), 8, null, "Take with water", 8, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4869) },
                    { 9, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4874), new DateTime(2024, 9, 6, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4872), 9, null, "Take on an empty stomach", 9, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4875) },
                    { 10, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4880), new DateTime(2024, 9, 7, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4878), 10, null, "Take before sleeping", 10, new DateTime(2024, 9, 8, 11, 33, 44, 974, DateTimeKind.Local).AddTicks(4881) }
                });

            migrationBuilder.InsertData(
                table: "PrescriptionMedications",
                columns: new[] { "PrescriptionMedicationID", "CreatedTime", "Dosage", "DosageUnit", "EndDate", "Frequency", "Instructions", "MedicationID", "PrescriptionID", "StartDate", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1361), 500, "mg", new DateTime(2024, 9, 18, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1356), "Twice a day", "Take with food", 1, 1, new DateTime(2024, 8, 29, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1338), new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1364) },
                    { 2, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1371), 250, "mg", new DateTime(2024, 9, 17, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1369), "Once a day", "Take before bed", 2, 2, new DateTime(2024, 8, 30, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1367), new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1373) },
                    { 3, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1380), 100, "mg", new DateTime(2024, 9, 16, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1378), "Every 8 hours", "Take every 8 hours", 3, 3, new DateTime(2024, 8, 31, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1376), new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1381) },
                    { 4, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1389), 200, "mg", new DateTime(2024, 9, 15, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1386), "Every morning", "Take every morning", 4, 4, new DateTime(2024, 9, 1, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1384), new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1390) },
                    { 5, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1397), 150, "mg", new DateTime(2024, 9, 14, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1395), "Every night", "Take every night", 5, 5, new DateTime(2024, 9, 2, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1393), new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1398) },
                    { 6, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1410), 500, "mg", new DateTime(2024, 9, 13, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1408), "Before meals", "Take before meals", 6, 6, new DateTime(2024, 9, 3, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1402), new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1412) },
                    { 7, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1419), 100, "mg", new DateTime(2024, 9, 12, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1417), "Every 12 hours", "Take every 12 hours", 7, 7, new DateTime(2024, 9, 4, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1415), new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1421) },
                    { 8, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1429), 75, "mg", new DateTime(2024, 9, 11, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1427), "With water", "Take with water", 8, 8, new DateTime(2024, 9, 5, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1424), new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1430) },
                    { 9, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1437), 50, "mg", new DateTime(2024, 9, 10, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1435), "On an empty stomach", "Take on an empty stomach", 9, 9, new DateTime(2024, 9, 6, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1433), new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1439) },
                    { 10, new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1446), 300, "mg", new DateTime(2024, 9, 9, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1444), "Before sleeping", "Take before sleeping", 10, 10, new DateTime(2024, 9, 7, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1442), new DateTime(2024, 9, 8, 11, 33, 44, 975, DateTimeKind.Local).AddTicks(1447) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "PatientXrays");

            migrationBuilder.DropTable(
                name: "PrescriptionMedications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
