using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Byway.Infrastructure._Data.Migrations
{
    /// <inheritdoc />
    public partial class figure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfilePictureUrl",
                value: "images/instructors/photo-1463453091185-61582044d556.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfilePictureUrl",
                value: "images/instructors/photo-1438761681033-6461ffad8d80.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProfilePictureUrl",
                value: "images/instructors/photo-1472099645785-5658abf4ff4e.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProfilePictureUrl",
                value: "images/instructors/photo-1494790108377-be9c29b29330.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProfilePictureUrl",
                value: "images/instructors/photo-1507003211169-0a1dd7228f2d.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProfilePictureUrl",
                value: "images/instructors/photo-1519085360753-af0119f7cbe7.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProfilePictureUrl",
                value: "images/instructors/photo-1534528741775-53994a69daeb.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProfilePictureUrl",
                value: "images/instructors/photo-1500648767791-00dcc994a43e.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProfilePictureUrl",
                value: "images/instructors/photo-1500648767791-00dcc994a43e.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProfilePictureUrl",
                value: "images/instructorsphoto-1531123897727-8f129e1688ce.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProfilePictureUrl",
                value: "images/instructorsphoto-1506794778202-cad84cf45f1d.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProfilePictureUrl",
                value: "images/instructorsphoto-1506794778202-cad84cf45f1d.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfilePictureUrl",
                value: "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=400&h=400&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfilePictureUrl",
                value: "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=400&h=400&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProfilePictureUrl",
                value: "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=400&h=400&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProfilePictureUrl",
                value: "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=400&h=400&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProfilePictureUrl",
                value: "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=400&h=400&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProfilePictureUrl",
                value: "https://images.unsplash.com/photo-1487412720507-e7ab37603c6f?w=400&h=400&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProfilePictureUrl",
                value: "https://images.unsplash.com/photo-1519085360753-af0119f7cbe7?w=400&h=400&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProfilePictureUrl",
                value: "https://images.unsplash.com/photo-1534528741775-53994a69daeb?w=400&h=400&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProfilePictureUrl",
                value: "https://images.unsplash.com/photo-1463453091185-61582044d556?w=400&h=400&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProfilePictureUrl",
                value: "https://images.unsplash.com/photo-1531123897727-8f129e1688ce?w=400&h=400&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProfilePictureUrl",
                value: "https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?w=400&h=400&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProfilePictureUrl",
                value: "https://images.unsplash.com/photo-1489424731084-a5d8b219a5bb?w=400&h=400&fit=crop&crop=center");
        }
    }
}
