using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Byway.Infrastructure._Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    jopTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    About = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
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
                    InstructorId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoughtCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CheckoutId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoughtCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoughtCourse_Checkouts_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "Checkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoughtCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 8, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Programming" },
                    { 2, new DateTimeOffset(new DateTime(2024, 8, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Data Science" },
                    { 3, new DateTimeOffset(new DateTime(2024, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Web Development" },
                    { 4, new DateTimeOffset(new DateTime(2024, 8, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mobile Development" },
                    { 5, new DateTimeOffset(new DateTime(2024, 8, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Machine Learning" },
                    { 6, new DateTimeOffset(new DateTime(2024, 8, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "DevOps" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "About", "CreatedAt", "Name", "jopTitle" },
                values: new object[,]
                {
                    { 1, "Experienced full-stack developer with 10+ years in the industry. Passionate about teaching clean code and best practices.", new DateTimeOffset(new DateTime(2024, 8, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "John Smith", "Senior Software Engineer" },
                    { 2, "PhD in Statistics with expertise in machine learning and data visualization. Former researcher at Google AI.", new DateTimeOffset(new DateTime(2024, 8, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sarah Johnson", "Data Scientist" },
                    { 3, "React and Vue.js specialist with a keen eye for UI/UX design. Previously worked at Netflix and Spotify.", new DateTimeOffset(new DateTime(2024, 8, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mike Chen", "Frontend Developer" },
                    { 4, "iOS and Android development expert. Published 15+ apps on app stores with millions of downloads.", new DateTimeOffset(new DateTime(2024, 8, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Emily Rodriguez", "Mobile App Developer" },
                    { 5, "AI researcher and engineer specializing in deep learning and computer vision. Author of 'ML in Practice'.", new DateTimeOffset(new DateTime(2024, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "David Kumar", "Machine Learning Engineer" },
                    { 6, "Cloud infrastructure expert with AWS and Azure certifications. Specializes in CI/CD and containerization.", new DateTimeOffset(new DateTime(2024, 8, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Lisa Thompson", "DevOps Engineer" },
                    { 7, "Microservices architecture specialist with expertise in .NET, Node.js, and distributed systems.", new DateTimeOffset(new DateTime(2024, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Alex Morgan", "Backend Developer" },
                    { 8, "MERN stack expert with 8 years of experience building scalable web applications for startups.", new DateTimeOffset(new DateTime(2024, 8, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Maria Garcia", "Full Stack Developer" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CoverPictureUrl", "CreatedAt", "Description", "InstructorId", "Price", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, 1, "https://images.unsplash.com/photo-1517077304055-6e89abbf09b0?w=800&h=600&fit=crop&crop=center", new DateTimeOffset(new DateTime(2024, 8, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Master C# programming from basics to advanced topics including OOP, LINQ, and async programming.", 1, 99.99m, 5, "Complete C# Programming Bootcamp" },
                    { 2, 2, "https://images.unsplash.com/photo-1551288049-bebda4e38f71?w=800&h=600&fit=crop&crop=center", new DateTimeOffset(new DateTime(2024, 8, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn data analysis, visualization, and machine learning using Python, pandas, and scikit-learn.", 2, 129.99m, 4, "Data Science with Python" },
                    { 3, 3, "https://images.unsplash.com/photo-1633356122544-f134324a6cee?w=800&h=600&fit=crop&crop=center", new DateTimeOffset(new DateTime(2024, 8, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Build dynamic web applications using React, Redux, and modern JavaScript ES6+ features.", 3, 89.99m, 5, "Modern React Development" },
                    { 4, 4, "https://images.unsplash.com/photo-1512941937669-90a1b58e7e9c?w=800&h=600&fit=crop&crop=center", new DateTimeOffset(new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create professional iOS applications using Swift and SwiftUI. Publish your first app to the App Store.", 4, 149.99m, 4, "iOS App Development with Swift" },
                    { 5, 5, "https://images.unsplash.com/photo-1555949963-aa79dcee981c?w=800&h=600&fit=crop&crop=center", new DateTimeOffset(new DateTime(2024, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Introduction to machine learning algorithms, neural networks, and practical implementation.", 5, 179.99m, 5, "Machine Learning Fundamentals" },
                    { 6, 6, "https://images.unsplash.com/photo-1618401471353-b98afee0b2eb?w=800&h=600&fit=crop&crop=center", new DateTimeOffset(new DateTime(2024, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn containerization and orchestration for modern application deployment and scaling.", 6, 139.99m, 4, "Docker and Kubernetes Mastery" },
                    { 7, 1, "https://images.unsplash.com/photo-1461749280684-dccba630e2f6?w=800&h=600&fit=crop&crop=center", new DateTimeOffset(new DateTime(2024, 8, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Build robust RESTful APIs using ASP.NET Core, Entity Framework, and clean architecture principles.", 7, 119.99m, 5, "ASP.NET Core Web API Development" },
                    { 8, 4, "https://images.unsplash.com/photo-1607252650355-f7fd0460ccdb?w=800&h=600&fit=crop&crop=center", new DateTimeOffset(new DateTime(2024, 8, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create native Android applications using Kotlin, Android Jetpack, and Material Design.", 4, 134.99m, 4, "Android Development with Kotlin" },
                    { 9, 3, "https://images.unsplash.com/photo-1627398242454-45a1465c2479?w=800&h=600&fit=crop&crop=center", new DateTimeOffset(new DateTime(2024, 8, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Master Vue.js 3 with Composition API, Vuex, Vue Router, and build modern single-page applications.", 3, 94.99m, 4, "Vue.js Complete Guide" },
                    { 10, 5, "https://images.unsplash.com/photo-1620712943543-bcc4688e7485?w=800&h=600&fit=crop&crop=center", new DateTimeOffset(new DateTime(2024, 8, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Advanced machine learning course covering neural networks, CNNs, RNNs, and practical AI applications.", 5, 199.99m, 5, "Deep Learning with TensorFlow" },
                    { 11, 6, "https://images.unsplash.com/photo-1451187580459-43490279c0fa?w=800&h=600&fit=crop&crop=center", new DateTimeOffset(new DateTime(2024, 8, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Design and deploy scalable cloud solutions using AWS services, serverless architecture, and best practices.", 6, 159.99m, 4, "Cloud Architecture on AWS" },
                    { 12, 3, "https://images.unsplash.com/photo-1579468118864-1b9ea3c0db4a?w=800&h=600&fit=crop&crop=center", new DateTimeOffset(new DateTime(2024, 8, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "End-to-end web development using Node.js, Express, React, and MongoDB (MERN stack).", 8, 144.99m, 5, "Full Stack JavaScript Development" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoughtCourse_CheckoutId",
                table: "BoughtCourse",
                column: "CheckoutId");

            migrationBuilder.CreateIndex(
                name: "IX_BoughtCourse_CourseId",
                table: "BoughtCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoughtCourse");

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
