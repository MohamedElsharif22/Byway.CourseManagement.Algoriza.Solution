using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Byway.Infrastructure._Data.Migrations
{
    /// <inheritdoc />
    public partial class modifiedCoursesDataSeedImgUrlsandaddedphotostotheroot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoverPictureUrl",
                value: "images/courses/photo-1517077304055-6e89abbf09b0.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CoverPictureUrl",
                value: "images/courses/photo-1551288049-bebda4e38f71.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CoverPictureUrl",
                value: "images/courses/photo-1633356122544-f134324a6cee.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CoverPictureUrl",
                value: "images/courses/photo-1512941937669-90a1b58e7e9c.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CoverPictureUrl",
                value: "images/courses/photo-1555949963-aa79dcee981c.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CoverPictureUrl",
                value: "images/courses/photo-1618401471353-b98afee0b2eb.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CoverPictureUrl",
                value: "images/courses/photo-1461749280684-dccba630e2f6.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CoverPictureUrl",
                value: "images/instructors/photo-1607252650355-f7fd0460ccdb.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CoverPictureUrl",
                value: "images/instructors/photo-1627398242454-45a1465c2479.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CoverPictureUrl",
                value: "images/instructors/photo-1620712943543-bcc4688e7485.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CoverPictureUrl",
                value: "images/instructors/photo-1451187580459-43490279c0fa.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CoverPictureUrl",
                value: "images/instructors/photo-1579468118864-1b9ea3c0db4a.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CoverPictureUrl",
                value: "images/instructors/photo-1526379095098-d400fd0bf935.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 14,
                column: "CoverPictureUrl",
                value: "images/instructors/photo-1541701494587-cb58502866ab.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 15,
                column: "CoverPictureUrl",
                value: "images/instructors/photo-1507003211169-0a1dd7228f2d.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 16,
                column: "CoverPictureUrl",
                value: "images/instructors/photo-1460925895917-afdab827c52f.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 17,
                column: "CoverPictureUrl",
                value: "images/instructors/photo-1550751827-4bd374c3f58b.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 18,
                column: "CoverPictureUrl",
                value: "images/instructors/photo-1563013544-824ae1b704d3.jpeg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 19,
                column: "CoverPictureUrl",
                value: "images/instructors/photo-1627398242454-45a1465c2479.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProfilePictureUrl",
                value: "images/instructors/photo-1531123897727-8f129e1688ce.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProfilePictureUrl",
                value: "images/instructors/photo-1506794778202-cad84cf45f1d.jpeg");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProfilePictureUrl",
                value: "images/instructors/photo-1506794778202-cad84cf45f1d.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1517077304055-6e89abbf09b0?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1551288049-bebda4e38f71?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1633356122544-f134324a6cee?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1512941937669-90a1b58e7e9c?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1555949963-aa79dcee981c?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1618401471353-b98afee0b2eb?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1461749280684-dccba630e2f6?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1607252650355-f7fd0460ccdb?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1627398242454-45a1465c2479?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1620712943543-bcc4688e7485?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1451187580459-43490279c0fa?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1579468118864-1b9ea3c0db4a?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1526379095098-d400fd0bf935?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 14,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1541701494587-cb58502866ab?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 15,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 16,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1460925895917-afdab827c52f?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 17,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1550751827-4bd374c3f58b?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 18,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1563013544-824ae1b704d3?w=800&h=600&fit=crop&crop=center");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 19,
                column: "CoverPictureUrl",
                value: "https://images.unsplash.com/photo-1609277205247-56d6e9eb9b85?w=800&h=600&fit=crop&crop=center");

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
    }
}
