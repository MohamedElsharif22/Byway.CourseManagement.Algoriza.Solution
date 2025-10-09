using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Byway.Infrastructure._Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentTransactionId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JopTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
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
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoverPictureUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Level = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoughtCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CheckoutId = table.Column<int>(type: "int", nullable: false),
                    PricePaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoughtCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoughtCourses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoughtCourses_Checkouts_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "Checkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoughtCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoursesContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LecturesCount = table.Column<int>(type: "int", nullable: false),
                    DurationInHours = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesContents_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 8, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Programming", new DateTimeOffset(new DateTime(2024, 8, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2024, 8, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Data Science", new DateTimeOffset(new DateTime(2024, 8, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2024, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Web Development", new DateTimeOffset(new DateTime(2024, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2024, 8, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mobile Development", new DateTimeOffset(new DateTime(2024, 8, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, new DateTimeOffset(new DateTime(2024, 8, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Machine Learning", new DateTimeOffset(new DateTime(2024, 8, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, new DateTimeOffset(new DateTime(2024, 8, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "DevOps", new DateTimeOffset(new DateTime(2024, 8, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, new DateTimeOffset(new DateTime(2024, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Design", new DateTimeOffset(new DateTime(2024, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, new DateTimeOffset(new DateTime(2024, 9, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Business", new DateTimeOffset(new DateTime(2024, 9, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, new DateTimeOffset(new DateTime(2024, 9, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Marketing", new DateTimeOffset(new DateTime(2024, 9, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, new DateTimeOffset(new DateTime(2024, 9, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Cybersecurity", new DateTimeOffset(new DateTime(2024, 9, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "About", "CreatedAt", "JopTitle", "Name", "ProfilePictureUrl", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Experienced full-stack developer with 10+ years in the industry. Passionate about teaching clean code and best practices.", new DateTimeOffset(new DateTime(2024, 8, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Senior_SoftwareEngineer", "John Smith", "images/instructors/photo-1463453091185-61582044d556.jpeg", new DateTimeOffset(new DateTime(2024, 8, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, "PhD in Statistics with expertise in machine learning and data visualization. Former researcher at Google AI.", new DateTimeOffset(new DateTime(2024, 8, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "DataScientist", "Sarah Johnson", "images/instructors/photo-1438761681033-6461ffad8d80.jpeg", new DateTimeOffset(new DateTime(2024, 8, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, "React and Vue.js specialist with a keen eye for UI/UX design. Previously worked at Netflix and Spotify.", new DateTimeOffset(new DateTime(2024, 8, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Frontend_Developer", "Mike Chen", "images/instructors/photo-1472099645785-5658abf4ff4e.jpeg", new DateTimeOffset(new DateTime(2024, 8, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, "iOS and Android development expert. Published 15+ apps on app stores with millions of downloads.", new DateTimeOffset(new DateTime(2024, 8, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MobileApp_Developer", "Emily Rodriguez", "images/instructors/photo-1494790108377-be9c29b29330.jpeg", new DateTimeOffset(new DateTime(2024, 8, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, "AI researcher and engineer specializing in deep learning and computer vision. Author of 'ML in Practice'.", new DateTimeOffset(new DateTime(2024, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MachineLearning_Engineer", "David Kumar", "images/instructors/photo-1507003211169-0a1dd7228f2d.jpeg", new DateTimeOffset(new DateTime(2024, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, "Cloud infrastructure expert with AWS and Azure certifications. Specializes in CI/CD and containerization.", new DateTimeOffset(new DateTime(2024, 8, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "DevOps_Engineer", "Lisa Thompson", "images/instructors/photo-1519085360753-af0119f7cbe7.jpeg", new DateTimeOffset(new DateTime(2024, 8, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, "Microservices architecture specialist with expertise in .NET, Node.js, and distributed systems.", new DateTimeOffset(new DateTime(2024, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Backend_Developer", "Alex Morgan", "images/instructors/photo-1534528741775-53994a69daeb.jpeg", new DateTimeOffset(new DateTime(2024, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, "MERN stack expert with 8 years of experience building scalable web applications for startups.", new DateTimeOffset(new DateTime(2024, 8, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "FullStack_Developer", "Maria Garcia", "images/instructors/photo-1500648767791-00dcc994a43e.jpeg", new DateTimeOffset(new DateTime(2024, 8, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, "Award-winning designer specializing in user experience research and interface design. Former design lead at Adobe.", new DateTimeOffset(new DateTime(2024, 8, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "UXUI_Designer", "Robert Wilson", "images/instructors/photo-1500648767791-00dcc994a43e.jpeg", new DateTimeOffset(new DateTime(2024, 8, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, "MBA from Stanford with 12 years in strategic consulting. Expert in business process optimization and digital transformation.", new DateTimeOffset(new DateTime(2024, 8, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Business_Analyst", "Jennifer Lee", "images/instructors/photo-1531123897727-8f129e1688ce.jpeg", new DateTimeOffset(new DateTime(2024, 8, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 11, "Former marketing director at Fortune 500 companies. Specialist in growth hacking and performance marketing.", new DateTimeOffset(new DateTime(2024, 8, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "DigitalMarketingStrategist", "Michael Torres", "images/instructors/photo-1506794778202-cad84cf45f1d.jpeg", new DateTimeOffset(new DateTime(2024, 8, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 12, "Ethical hacker and security consultant with CISSP certification. Former security engineer at Microsoft.", new DateTimeOffset(new DateTime(2024, 8, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "CybersecurityExpert", "Amanda Zhang", "images/instructors/photo-1506794778202-cad84cf45f1d.jpeg", new DateTimeOffset(new DateTime(2024, 8, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CoverPictureUrl", "CreatedAt", "Description", "InstructorId", "Level", "Price", "Rating", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "images/courses/photo-1517077304055-6e89abbf09b0.jpeg", new DateTimeOffset(new DateTime(2024, 8, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Master C# programming from basics to advanced topics including OOP, LINQ, and async programming.", 1, "Advenced", 99.99m, 5, "Complete C# Programming Bootcamp", new DateTimeOffset(new DateTime(2024, 8, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, 2, "images/courses/photo-1551288049-bebda4e38f71.jpeg", new DateTimeOffset(new DateTime(2024, 8, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn data analysis, visualization, and machine learning using Python, pandas, and scikit-learn.", 2, "Intermediate", 129.99m, 4, "Data Science with Python", new DateTimeOffset(new DateTime(2024, 8, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, 3, "images/courses/photo-1633356122544-f134324a6cee.jpeg", new DateTimeOffset(new DateTime(2024, 8, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Build dynamic web applications using React, Redux, and modern JavaScript ES6+ features.", 3, "Intermediate", 89.99m, 5, "Modern React Development", new DateTimeOffset(new DateTime(2024, 8, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, 4, "images/courses/photo-1512941937669-90a1b58e7e9c.jpeg", new DateTimeOffset(new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create professional iOS applications using Swift and SwiftUI. Publish your first app to the App Store.", 4, "Advenced", 149.99m, 4, "iOS App Development with Swift", new DateTimeOffset(new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, 5, "images/courses/photo-1555949963-aa79dcee981c.jpeg", new DateTimeOffset(new DateTime(2024, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Introduction to machine learning algorithms, neural networks, and practical implementation.", 5, "Advenced", 179.99m, 5, "Machine Learning Fundamentals", new DateTimeOffset(new DateTime(2024, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, 6, "images/courses/photo-1618401471353-b98afee0b2eb.jpeg", new DateTimeOffset(new DateTime(2024, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn containerization and orchestration for modern application deployment and scaling.", 6, "Advenced", 139.99m, 4, "Docker and Kubernetes Mastery", new DateTimeOffset(new DateTime(2024, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, 1, "images/courses/photo-1461749280684-dccba630e2f6.jpeg", new DateTimeOffset(new DateTime(2024, 8, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Build robust RESTful APIs using ASP.NET Core, Entity Framework, and clean architecture principles.", 7, "Intermediate", 119.99m, 5, "ASP.NET Core Web API Development", new DateTimeOffset(new DateTime(2024, 8, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, 4, "images/instructors/photo-1607252650355-f7fd0460ccdb.jpeg", new DateTimeOffset(new DateTime(2024, 8, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create native Android applications using Kotlin, Android Jetpack, and Material Design.", 4, "Advenced", 134.99m, 4, "Android Development with Kotlin", new DateTimeOffset(new DateTime(2024, 8, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, 3, "images/instructors/photo-1627398242454-45a1465c2479.jpeg", new DateTimeOffset(new DateTime(2024, 8, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Master Vue.js 3 with Composition API, Vuex, Vue Router, and build modern single-page applications.", 3, "Beginner", 94.99m, 4, "Vue.js Complete Guide", new DateTimeOffset(new DateTime(2024, 8, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, 5, "images/instructors/photo-1620712943543-bcc4688e7485.jpeg", new DateTimeOffset(new DateTime(2024, 8, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Advanced machine learning course covering neural networks, CNNs, RNNs, and practical AI applications.", 5, "Beginner", 199.99m, 5, "Deep Learning with TensorFlow", new DateTimeOffset(new DateTime(2024, 8, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 11, 6, "images/instructors/photo-1451187580459-43490279c0fa.jpeg", new DateTimeOffset(new DateTime(2024, 8, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Design and deploy scalable cloud solutions using AWS services, serverless architecture, and best practices.", 6, "Intermediate", 159.99m, 4, "Cloud Architecture on AWS", new DateTimeOffset(new DateTime(2024, 8, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 12, 3, "images/instructors/photo-1579468118864-1b9ea3c0db4a.jpeg", new DateTimeOffset(new DateTime(2024, 8, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "End-to-end web development using Node.js, Express, React, and MongoDB (MERN stack).", 8, "Beginner", 144.99m, 5, "Full Stack JavaScript Development", new DateTimeOffset(new DateTime(2024, 8, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 13, 1, "images/instructors/photo-1526379095098-d400fd0bf935.jpeg", new DateTimeOffset(new DateTime(2024, 8, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Deep dive into Python advanced concepts including decorators, metaclasses, async programming, and performance optimization.", 1, "Advenced", 109.99m, 4, "Advanced Python Programming", new DateTimeOffset(new DateTime(2024, 8, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 14, 7, "images/instructors/photo-1541701494587-cb58502866ab.jpeg", new DateTimeOffset(new DateTime(2024, 8, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Complete course on user interface and user experience design principles, tools, and methodologies.", 9, "Advenced", 124.99m, 5, "UI/UX Design Masterclass", new DateTimeOffset(new DateTime(2024, 8, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 15, 8, "images/instructors/photo-1507003211169-0a1dd7228f2d.jpeg", new DateTimeOffset(new DateTime(2024, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn business analysis techniques, process mapping, and optimization strategies for digital transformation.", 10, "Advenced", 114.99m, 4, "Business Analysis and Process Optimization", new DateTimeOffset(new DateTime(2024, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 16, 9, "images/instructors/photo-1460925895917-afdab827c52f.jpeg", new DateTimeOffset(new DateTime(2024, 9, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Master digital marketing strategies, SEO, social media marketing, and growth hacking techniques.", 11, "Advenced", 99.99m, 5, "Digital Marketing and Growth Hacking", new DateTimeOffset(new DateTime(2024, 9, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 17, 10, "images/instructors/photo-1550751827-4bd374c3f58b.jpeg", new DateTimeOffset(new DateTime(2024, 9, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Introduction to cybersecurity principles, ethical hacking, penetration testing, and security best practices.", 12, "Beginner", 149.99m, 4, "Cybersecurity Fundamentals", new DateTimeOffset(new DateTime(2024, 9, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 18, 10, "images/instructors/photo-1563013544-824ae1b704d3.jpeg", new DateTimeOffset(new DateTime(2024, 9, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Advanced penetration testing techniques, vulnerability assessment, and incident response strategies.", 12, "Beginner", 189.99m, 5, "Advanced Cybersecurity and Ethical Hacking", new DateTimeOffset(new DateTime(2024, 9, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 19, 7, "images/instructors/photo-1627398242454-45a1465c2479.jpeg", new DateTimeOffset(new DateTime(2024, 9, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Master Figma for creating professional product designs, prototypes, and design systems.", 9, "Beginner", 89.99m, 4, "Figma for Product Design", new DateTimeOffset(new DateTime(2024, 9, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CoursesContents",
                columns: new[] { "Id", "CourseId", "CreatedAt", "DurationInHours", "LecturesCount", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2024, 8, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 8, "Introduction to C# and .NET", new DateTimeOffset(new DateTime(2024, 8, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, 1, new DateTimeOffset(new DateTime(2024, 8, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 12, "C# Basics and Syntax", new DateTimeOffset(new DateTime(2024, 8, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, 2, new DateTimeOffset(new DateTime(2024, 8, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 10, "Python Fundamentals for Data Science", new DateTimeOffset(new DateTime(2024, 8, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, 2, new DateTimeOffset(new DateTime(2024, 8, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 12, "NumPy and Data Manipulation", new DateTimeOffset(new DateTime(2024, 8, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 11, 3, new DateTimeOffset(new DateTime(2024, 8, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 9, "React Fundamentals and JSX", new DateTimeOffset(new DateTime(2024, 8, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 12, 3, new DateTimeOffset(new DateTime(2024, 8, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 13, "React Hooks and State Management", new DateTimeOffset(new DateTime(2024, 8, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 16, 4, new DateTimeOffset(new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 11, "Swift Programming Basics", new DateTimeOffset(new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 17, 4, new DateTimeOffset(new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 14, "SwiftUI Fundamentals", new DateTimeOffset(new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 21, 5, new DateTimeOffset(new DateTime(2024, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 8, "Introduction to Machine Learning", new DateTimeOffset(new DateTime(2024, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 22, 5, new DateTimeOffset(new DateTime(2024, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 15, "Supervised Learning Algorithms", new DateTimeOffset(new DateTime(2024, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 26, 6, new DateTimeOffset(new DateTime(2024, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 10, "Docker Fundamentals", new DateTimeOffset(new DateTime(2024, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 27, 6, new DateTimeOffset(new DateTime(2024, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 11, "Container Images and Dockerfiles", new DateTimeOffset(new DateTime(2024, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 31, 7, new DateTimeOffset(new DateTime(2024, 8, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 9, "ASP.NET Core Fundamentals", new DateTimeOffset(new DateTime(2024, 8, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 32, 7, new DateTimeOffset(new DateTime(2024, 8, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 8, "RESTful API Design Principles", new DateTimeOffset(new DateTime(2024, 8, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 36, 8, new DateTimeOffset(new DateTime(2024, 8, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 12, "Kotlin Programming Essentials", new DateTimeOffset(new DateTime(2024, 8, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 37, 8, new DateTimeOffset(new DateTime(2024, 8, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 7, "Android Studio and Development Environment", new DateTimeOffset(new DateTime(2024, 8, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 41, 9, new DateTimeOffset(new DateTime(2024, 8, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 10, "Vue.js 3 Fundamentals", new DateTimeOffset(new DateTime(2024, 8, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 42, 9, new DateTimeOffset(new DateTime(2024, 8, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 12, "Composition API Deep Dive", new DateTimeOffset(new DateTime(2024, 8, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 46, 10, new DateTimeOffset(new DateTime(2024, 8, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 10, "TensorFlow Fundamentals", new DateTimeOffset(new DateTime(2024, 8, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 47, 10, new DateTimeOffset(new DateTime(2024, 8, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 14, "Deep Neural Networks", new DateTimeOffset(new DateTime(2024, 8, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 48, 10, new DateTimeOffset(new DateTime(2024, 8, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 16, "Convolutional Neural Networks (CNNs)", new DateTimeOffset(new DateTime(2024, 8, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 51, 11, new DateTimeOffset(new DateTime(2024, 8, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 11, "AWS Fundamentals and Core Services", new DateTimeOffset(new DateTime(2024, 8, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 52, 11, new DateTimeOffset(new DateTime(2024, 8, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 12, "EC2 and Compute Services", new DateTimeOffset(new DateTime(2024, 8, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 56, 12, new DateTimeOffset(new DateTime(2024, 8, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 10, "Modern JavaScript (ES6+)", new DateTimeOffset(new DateTime(2024, 8, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 57, 12, new DateTimeOffset(new DateTime(2024, 8, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 14, "Node.js and Express Backend", new DateTimeOffset(new DateTime(2024, 8, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 61, 13, new DateTimeOffset(new DateTime(2024, 8, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 11, "Python Advanced Syntax and Features", new DateTimeOffset(new DateTime(2024, 8, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 62, 13, new DateTimeOffset(new DateTime(2024, 8, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 9, "Decorators and Context Managers", new DateTimeOffset(new DateTime(2024, 8, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 66, 14, new DateTimeOffset(new DateTime(2024, 8, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 10, "Design Thinking and User Research", new DateTimeOffset(new DateTime(2024, 8, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 67, 14, new DateTimeOffset(new DateTime(2024, 8, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 12, "UI Design Principles and Typography", new DateTimeOffset(new DateTime(2024, 8, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 71, 15, new DateTimeOffset(new DateTime(2024, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 9, "Business Analysis Fundamentals", new DateTimeOffset(new DateTime(2024, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 72, 15, new DateTimeOffset(new DateTime(2024, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 11, "Requirements Gathering and Documentation", new DateTimeOffset(new DateTime(2024, 9, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 76, 16, new DateTimeOffset(new DateTime(2024, 9, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 10, "Digital Marketing Foundations", new DateTimeOffset(new DateTime(2024, 9, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 77, 16, new DateTimeOffset(new DateTime(2024, 9, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 13, "SEO and Content Marketing", new DateTimeOffset(new DateTime(2024, 9, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 81, 17, new DateTimeOffset(new DateTime(2024, 9, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 8, "Introduction to Cybersecurity", new DateTimeOffset(new DateTime(2024, 9, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 82, 17, new DateTimeOffset(new DateTime(2024, 9, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 12, "Network Security and Protocols", new DateTimeOffset(new DateTime(2024, 9, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 86, 18, new DateTimeOffset(new DateTime(2024, 9, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 15, "Advanced Penetration Testing", new DateTimeOffset(new DateTime(2024, 9, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 87, 18, new DateTimeOffset(new DateTime(2024, 9, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 13, "Web Application Security Testing", new DateTimeOffset(new DateTime(2024, 9, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 91, 19, new DateTimeOffset(new DateTime(2024, 9, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 8, "Figma Interface and Basics", new DateTimeOffset(new DateTime(2024, 9, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 92, 19, new DateTimeOffset(new DateTime(2024, 9, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 11, "Components and Auto Layout", new DateTimeOffset(new DateTime(2024, 9, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
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
                name: "IX_BoughtCourses_CheckoutId",
                table: "BoughtCourses",
                column: "CheckoutId");

            migrationBuilder.CreateIndex(
                name: "IX_BoughtCourses_CourseId",
                table: "BoughtCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_BoughtCourses_UserId",
                table: "BoughtCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesContents_CourseId",
                table: "CoursesContents",
                column: "CourseId");
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
                name: "BoughtCourses");

            migrationBuilder.DropTable(
                name: "CoursesContents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
