using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Byway.Infrastructure._Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseContentEntitywithitsdataseedAndModifiedCourseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LecturesCount",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Level",
                value: "Advenced");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Level",
                value: "Intermediate");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Level",
                value: "Intermediate");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Level",
                value: "Advenced");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "Level",
                value: "Advenced");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "Level",
                value: "Advenced");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "Level",
                value: "Intermediate");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "Level",
                value: "Advenced");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "Level",
                value: "Beginner");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "Level",
                value: "Beginner");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                column: "Level",
                value: "Intermediate");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                column: "Level",
                value: "Beginner");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13,
                column: "Level",
                value: "Advenced");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 14,
                column: "Level",
                value: "Advenced");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 15,
                column: "Level",
                value: "Advenced");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 16,
                column: "Level",
                value: "Advenced");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 17,
                column: "Level",
                value: "Beginner");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 18,
                column: "Level",
                value: "Beginner");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 19,
                column: "Level",
                value: "Beginner");

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
                name: "IX_CoursesContents_CourseId",
                table: "CoursesContents",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesContents");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LecturesCount",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1200, 145 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1500, 180 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 900, 120 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1350, 165 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1800, 200 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1200, 155 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1050, 135 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1250, 150 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 850, 110 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 2000, 220 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1400, 175 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1300, 160 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 950, 125 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1100, 140 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1000, 130 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 900, 115 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1400, 170 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 1650, 190 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DurationInMinutes", "LecturesCount" },
                values: new object[] { 800, 105 });
        }
    }
}
