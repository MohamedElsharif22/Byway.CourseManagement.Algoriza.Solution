using Byway.Domain.Entities;
using Byway.Domain.Entities.Course_;
using Byway.Domain.Entities.enums;
using Byway.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Infrastructure._Data
{
    public class BywayContextSeed
    {
        public static void SeedDatabase(ModelBuilder modelBuilder)
        {
            // Seed Categories
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Programming", CreatedAt = new DateTimeOffset(2024, 8, 1, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2024, 8, 1, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 2, Name = "Data Science", CreatedAt = new DateTimeOffset(2024, 8, 6, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2024, 8, 6, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 3, Name = "Web Development", CreatedAt = new DateTimeOffset(2024, 8, 11, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2024, 8, 11, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 4, Name = "Mobile Development", CreatedAt = new DateTimeOffset(2024, 8, 16, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2024, 8, 16, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 5, Name = "Machine Learning", CreatedAt = new DateTimeOffset(2024, 8, 21, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2024, 8, 21, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 6, Name = "DevOps", CreatedAt = new DateTimeOffset(2024, 8, 26, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2024, 8, 26, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 7, Name = "Design", CreatedAt = new DateTimeOffset(2024, 9, 1, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2024, 9, 1, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 8, Name = "Business", CreatedAt = new DateTimeOffset(2024, 9, 6, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2024, 9, 6, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 9, Name = "Marketing", CreatedAt = new DateTimeOffset(2024, 9, 11, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2024, 9, 11, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 10, Name = "Cybersecurity", CreatedAt = new DateTimeOffset(2024, 9, 16, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2024, 9, 16, 10, 0, 0, TimeSpan.Zero) }
            };

            modelBuilder.Entity<Category>().HasData(categories);

            // Seed Instructors
            var instructors = new List<Instructor>
            {
                new Instructor
                {
                    Id = 1,
                    Name = "John Smith",
                    JopTitle = JobTitles.Senior_SoftwareEngineer,
                    About = "Experienced full-stack developer with 10+ years in the industry. Passionate about teaching clean code and best practices.",
                    ProfilePictureUrl = "images/instructors/photo-1463453091185-61582044d556.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 3, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 3, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 2,
                    Name = "Sarah Johnson",
                    JopTitle = JobTitles.DataScientist,
                    About = "PhD in Statistics with expertise in machine learning and data visualization. Former researcher at Google AI.",
                    ProfilePictureUrl = "images/instructors/photo-1438761681033-6461ffad8d80.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 5, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 5, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 3,
                    Name = "Mike Chen",
                    JopTitle = JobTitles.Frontend_Developer,
                    About = "React and Vue.js specialist with a keen eye for UI/UX design. Previously worked at Netflix and Spotify.",
                    ProfilePictureUrl = "images/instructors/photo-1472099645785-5658abf4ff4e.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 7, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 7, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 4,
                    Name = "Emily Rodriguez",
                    JopTitle = JobTitles.MobileApp_Developer,
                    About = "iOS and Android development expert. Published 15+ apps on app stores with millions of downloads.",
                    ProfilePictureUrl = "images/instructors/photo-1494790108377-be9c29b29330.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 9, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 9, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 5,
                    Name = "David Kumar",
                    JopTitle = JobTitles.MachineLearning_Engineer,
                    About = "AI researcher and engineer specializing in deep learning and computer vision. Author of 'ML in Practice'.",
                    ProfilePictureUrl = "images/instructors/photo-1507003211169-0a1dd7228f2d.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 11, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 11, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 6,
                    Name = "Lisa Thompson",
                    JopTitle = JobTitles.DevOps_Engineer,
                    About = "Cloud infrastructure expert with AWS and Azure certifications. Specializes in CI/CD and containerization.",
                    ProfilePictureUrl = "images/instructors/photo-1519085360753-af0119f7cbe7.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 13, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 13, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 7,
                    Name = "Alex Morgan",
                    JopTitle = JobTitles.Backend_Developer,
                    About = "Microservices architecture specialist with expertise in .NET, Node.js, and distributed systems.",
                    ProfilePictureUrl = "images/instructors/photo-1534528741775-53994a69daeb.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 15, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 15, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 8,
                    Name = "Maria Garcia",
                    JopTitle = JobTitles.FullStack_Developer,
                    About = "MERN stack expert with 8 years of experience building scalable web applications for startups.",
                    ProfilePictureUrl = "images/instructors/photo-1500648767791-00dcc994a43e.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 17, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 17, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 9,
                    Name = "Robert Wilson",
                    JopTitle = JobTitles.UXUI_Designer,
                    About = "Award-winning designer specializing in user experience research and interface design. Former design lead at Adobe.",
                    ProfilePictureUrl = "images/instructors/photo-1500648767791-00dcc994a43e.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 19, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 19, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 10,
                    Name = "Jennifer Lee",
                    JopTitle = JobTitles.Business_Analyst,
                    About = "MBA from Stanford with 12 years in strategic consulting. Expert in business process optimization and digital transformation.",
                    ProfilePictureUrl = "images/instructors/photo-1531123897727-8f129e1688ce.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 21, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 21, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 11,
                    Name = "Michael Torres",
                    JopTitle = JobTitles.DigitalMarketingStrategist,
                    About = "Former marketing director at Fortune 500 companies. Specialist in growth hacking and performance marketing.",
                    ProfilePictureUrl = "images/instructors/photo-1506794778202-cad84cf45f1d.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 23, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 23, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 12,
                    Name = "Amanda Zhang",
                    JopTitle = JobTitles.CybersecurityExpert,
                    About = "Ethical hacker and security consultant with CISSP certification. Former security engineer at Microsoft.",
                    ProfilePictureUrl = "images/instructors/photo-1506794778202-cad84cf45f1d.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 25, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 25, 10, 0, 0, TimeSpan.Zero)
                }
            };

            modelBuilder.Entity<Instructor>().HasData(instructors);

            // Seed Courses
            var courses = new List<Course>
            {
                new Course
                {
                    Id = 1,
                    Title = "Complete C# Programming Bootcamp",
                    Description = "Master C# programming from basics to advanced topics including OOP, LINQ, and async programming.",
                    Rating = 5,
                    Price = 99.99m,
                    CategoryId = 1,
                    InstructorId = 1,
                    CoverPictureUrl = "images/courses/photo-1517077304055-6e89abbf09b0.jpeg",
                    Level = CourseLevels.Advenced,
                    CreatedAt = new DateTimeOffset(2024, 8, 4, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 4, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 2,
                    Title = "Data Science with Python",
                    Description = "Learn data analysis, visualization, and machine learning using Python, pandas, and scikit-learn.",
                    Rating = 4,
                    Price = 129.99m,
                    CategoryId = 2,
                    InstructorId = 2,
                    CoverPictureUrl = "images/courses/photo-1551288049-bebda4e38f71.jpeg",
                    Level = CourseLevels.Intermediate,
                    CreatedAt = new DateTimeOffset(2024, 8, 6, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 6, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 3,
                    Title = "Modern React Development",
                    Description = "Build dynamic web applications using React, Redux, and modern JavaScript ES6+ features.",
                    Rating = 5,
                    Price = 89.99m,
                    CategoryId = 3,
                    InstructorId = 3,
                    CoverPictureUrl = "images/courses/photo-1633356122544-f134324a6cee.jpeg",
                    Level = CourseLevels.Intermediate,
                    CreatedAt = new DateTimeOffset(2024, 8, 8, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 8, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 4,
                    Title = "iOS App Development with Swift",
                    Description = "Create professional iOS applications using Swift and SwiftUI. Publish your first app to the App Store.",
                    Rating = 4,
                    Price = 149.99m,
                    CategoryId = 4,
                    InstructorId = 4,
                    CoverPictureUrl = "images/courses/photo-1512941937669-90a1b58e7e9c.jpeg",
                    Level = CourseLevels.Advenced,
                    CreatedAt = new DateTimeOffset(2024, 8, 10, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 10, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 5,
                    Title = "Machine Learning Fundamentals",
                    Description = "Introduction to machine learning algorithms, neural networks, and practical implementation.",
                    Rating = 5,
                    Price = 179.99m,
                    CategoryId = 5,
                    InstructorId = 5,
                    CoverPictureUrl = "images/courses/photo-1555949963-aa79dcee981c.jpeg",
                    Level = CourseLevels.Advenced,
                    CreatedAt = new DateTimeOffset(2024, 8, 12, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 12, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 6,
                    Title = "Docker and Kubernetes Mastery",
                    Description = "Learn containerization and orchestration for modern application deployment and scaling.",
                    Rating = 4,
                    Price = 139.99m,
                    CategoryId = 6,
                    InstructorId = 6,
                    CoverPictureUrl = "images/courses/photo-1618401471353-b98afee0b2eb.jpeg",
                    Level = CourseLevels.Advenced,
                    CreatedAt = new DateTimeOffset(2024, 8, 14, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 14, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 7,
                    Title = "ASP.NET Core Web API Development",
                    Description = "Build robust RESTful APIs using ASP.NET Core, Entity Framework, and clean architecture principles.",
                    Rating = 5,
                    Price = 119.99m,
                    CategoryId = 1,
                    InstructorId = 7,
                    CoverPictureUrl = "images/courses/photo-1461749280684-dccba630e2f6.jpeg",
                    Level = CourseLevels.Intermediate,
                    CreatedAt = new DateTimeOffset(2024, 8, 16, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 16, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 8,
                    Title = "Android Development with Kotlin",
                    Description = "Create native Android applications using Kotlin, Android Jetpack, and Material Design.",
                    Rating = 4,
                    Price = 134.99m,
                    CategoryId = 4,
                    InstructorId = 4,
                    CoverPictureUrl = "images/instructors/photo-1607252650355-f7fd0460ccdb.jpeg",
                    Level = CourseLevels.Advenced,
                    CreatedAt = new DateTimeOffset(2024, 8, 18, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 18, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 9,
                    Title = "Vue.js Complete Guide",
                    Description = "Master Vue.js 3 with Composition API, Vuex, Vue Router, and build modern single-page applications.",
                    Rating = 4,
                    Price = 94.99m,
                    CategoryId = 3,
                    InstructorId = 3,
                    CoverPictureUrl = "images/instructors/photo-1627398242454-45a1465c2479.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 20, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 20, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 10,
                    Title = "Deep Learning with TensorFlow",
                    Description = "Advanced machine learning course covering neural networks, CNNs, RNNs, and practical AI applications.",
                    Rating = 5,
                    Price = 199.99m,
                    CategoryId = 5,
                    InstructorId = 5,
                    CoverPictureUrl = "images/instructors/photo-1620712943543-bcc4688e7485.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 22, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 22, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 11,
                    Title = "Cloud Architecture on AWS",
                    Description = "Design and deploy scalable cloud solutions using AWS services, serverless architecture, and best practices.",
                    Rating = 4,
                    Price = 159.99m,
                    CategoryId = 6,
                    InstructorId = 6,
                    CoverPictureUrl = "images/instructors/photo-1451187580459-43490279c0fa.jpeg",
                    Level = CourseLevels.Intermediate,
                    CreatedAt = new DateTimeOffset(2024, 8, 24, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 24, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 12,
                    Title = "Full Stack JavaScript Development",
                    Description = "End-to-end web development using Node.js, Express, React, and MongoDB (MERN stack).",
                    Rating = 5,
                    Price = 144.99m,
                    CategoryId = 3,
                    InstructorId = 8,
                    CoverPictureUrl = "images/instructors/photo-1579468118864-1b9ea3c0db4a.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 8, 26, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 26, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 13,
                    Title = "Advanced Python Programming",
                    Description = "Deep dive into Python advanced concepts including decorators, metaclasses, async programming, and performance optimization.",
                    Rating = 4,
                    Price = 109.99m,
                    CategoryId = 1,
                    InstructorId = 1,
                    CoverPictureUrl = "images/instructors/photo-1526379095098-d400fd0bf935.jpeg",
                    Level = CourseLevels.Advenced,
                    CreatedAt = new DateTimeOffset(2024, 8, 28, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 28, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 14,
                    Title = "UI/UX Design Masterclass",
                    Description = "Complete course on user interface and user experience design principles, tools, and methodologies.",
                    Rating = 5,
                    Price = 124.99m,
                    CategoryId = 7,
                    InstructorId = 9,
                    CoverPictureUrl = "images/instructors/photo-1541701494587-cb58502866ab.jpeg",
                    Level = CourseLevels.Advenced,
                    CreatedAt = new DateTimeOffset(2024, 8, 30, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 30, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 15,
                    Title = "Business Analysis and Process Optimization",
                    Description = "Learn business analysis techniques, process mapping, and optimization strategies for digital transformation.",
                    Rating = 4,
                    Price = 114.99m,
                    CategoryId = 8,
                    InstructorId = 10,
                    CoverPictureUrl = "images/instructors/photo-1507003211169-0a1dd7228f2d.jpeg",
                    Level = CourseLevels.Advenced,
                    CreatedAt = new DateTimeOffset(2024, 9, 1, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 1, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 16,
                    Title = "Digital Marketing and Growth Hacking",
                    Description = "Master digital marketing strategies, SEO, social media marketing, and growth hacking techniques.",
                    Rating = 5,
                    Price = 99.99m,
                    CategoryId = 9,
                    InstructorId = 11,
                    CoverPictureUrl = "images/instructors/photo-1460925895917-afdab827c52f.jpeg",
                    Level = CourseLevels.Advenced,
                    CreatedAt = new DateTimeOffset(2024, 9, 3, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 3, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 17,
                    Title = "Cybersecurity Fundamentals",
                    Description = "Introduction to cybersecurity principles, ethical hacking, penetration testing, and security best practices.",
                    Rating = 4,
                    Price = 149.99m,
                    CategoryId = 10,
                    InstructorId = 12,
                    CoverPictureUrl = "images/instructors/photo-1550751827-4bd374c3f58b.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 9, 5, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 5, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 18,
                    Title = "Advanced Cybersecurity and Ethical Hacking",
                    Description = "Advanced penetration testing techniques, vulnerability assessment, and incident response strategies.",
                    Rating = 5,
                    Price = 189.99m,
                    CategoryId = 10,
                    InstructorId = 12,
                    CoverPictureUrl = "images/instructors/photo-1563013544-824ae1b704d3.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 9, 7, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 7, 10, 0, 0, TimeSpan.Zero)
                },
                new Course
                {
                    Id = 19,
                    Title = "Figma for Product Design",
                    Description = "Master Figma for creating professional product designs, prototypes, and design systems.",
                    Rating = 4,
                    Price = 89.99m,
                    CategoryId = 7,
                    InstructorId = 9,
                    CoverPictureUrl = "images/instructors/photo-1627398242454-45a1465c2479.jpeg",
                    CreatedAt = new DateTimeOffset(2024, 9, 9, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 9, 10, 0, 0, TimeSpan.Zero)
                }
            };

            modelBuilder.Entity<Course>().HasData(courses);

            // Seed Course Contents
            var courseContents = new List<CourseContent>
            {
                // Course 1: Complete C# Programming Bootcamp
                new CourseContent
                {
                    Id = 1,
                    Name = "Introduction to C# and .NET",
                    LecturesCount = 8,
                    DurationInHours = 3,
                    CourseId = 1,
                    CreatedAt = new DateTimeOffset(2024, 8, 4, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 4, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 2,
                    Name = "C# Basics and Syntax",
                    LecturesCount = 12,
                    DurationInHours = 5,
                    CourseId = 1,
                    CreatedAt = new DateTimeOffset(2024, 8, 4, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 4, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 2: Data Science with Python
                new CourseContent
                {
                    Id = 6,
                    Name = "Python Fundamentals for Data Science",
                    LecturesCount = 10,
                    DurationInHours = 4,
                    CourseId = 2,
                    CreatedAt = new DateTimeOffset(2024, 8, 6, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 6, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 7,
                    Name = "NumPy and Data Manipulation",
                    LecturesCount = 12,
                    DurationInHours = 5,
                    CourseId = 2,
                    CreatedAt = new DateTimeOffset(2024, 8, 6, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 6, 10, 0, 0, TimeSpan.Zero)
                },

                // Course 3: Modern React Development
                new CourseContent
                {
                    Id = 11,
                    Name = "React Fundamentals and JSX",
                    LecturesCount = 9,
                    DurationInHours = 4,
                    CourseId = 3,
                    CreatedAt = new DateTimeOffset(2024, 8, 8, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 8, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 12,
                    Name = "React Hooks and State Management",
                    LecturesCount = 13,
                    DurationInHours = 5,
                    CourseId = 3,
                    CreatedAt = new DateTimeOffset(2024, 8, 8, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 8, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 4: iOS App Development with Swift
                new CourseContent
                {
                    Id = 16,
                    Name = "Swift Programming Basics",
                    LecturesCount = 11,
                    DurationInHours = 5,
                    CourseId = 4,
                    CreatedAt = new DateTimeOffset(2024, 8, 10, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 10, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 17,
                    Name = "SwiftUI Fundamentals",
                    LecturesCount = 14,
                    DurationInHours = 6,
                    CourseId = 4,
                    CreatedAt = new DateTimeOffset(2024, 8, 10, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 10, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 5: Machine Learning Fundamentals
                new CourseContent
                {
                    Id = 21,
                    Name = "Introduction to Machine Learning",
                    LecturesCount = 8,
                    DurationInHours = 3,
                    CourseId = 5,
                    CreatedAt = new DateTimeOffset(2024, 8, 12, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 12, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 22,
                    Name = "Supervised Learning Algorithms",
                    LecturesCount = 15,
                    DurationInHours = 6,
                    CourseId = 5,
                    CreatedAt = new DateTimeOffset(2024, 8, 12, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 12, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 6: Docker and Kubernetes Mastery
                new CourseContent
                {
                    Id = 26,
                    Name = "Docker Fundamentals",
                    LecturesCount = 10,
                    DurationInHours = 4,
                    CourseId = 6,
                    CreatedAt = new DateTimeOffset(2024, 8, 14, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 14, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 27,
                    Name = "Container Images and Dockerfiles",
                    LecturesCount = 11,
                    DurationInHours = 5,
                    CourseId = 6,
                    CreatedAt = new DateTimeOffset(2024, 8, 14, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 14, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 7: ASP.NET Core Web API Development
                new CourseContent
                {
                    Id = 31,
                    Name = "ASP.NET Core Fundamentals",
                    LecturesCount = 9,
                    DurationInHours = 4,
                    CourseId = 7,
                    CreatedAt = new DateTimeOffset(2024, 8, 16, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 16, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 32,
                    Name = "RESTful API Design Principles",
                    LecturesCount = 8,
                    DurationInHours = 3,
                    CourseId = 7,
                    CreatedAt = new DateTimeOffset(2024, 8, 16, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 16, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 8: Android Development with Kotlin
                new CourseContent
                {
                    Id = 36,
                    Name = "Kotlin Programming Essentials",
                    LecturesCount = 12,
                    DurationInHours = 5,
                    CourseId = 8,
                    CreatedAt = new DateTimeOffset(2024, 8, 18, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 18, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 37,
                    Name = "Android Studio and Development Environment",
                    LecturesCount = 7,
                    DurationInHours = 3,
                    CourseId = 8,
                    CreatedAt = new DateTimeOffset(2024, 8, 18, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 18, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 9: Vue.js Complete Guide
                new CourseContent
                {
                    Id = 41,
                    Name = "Vue.js 3 Fundamentals",
                    LecturesCount = 10,
                    DurationInHours = 4,
                    CourseId = 9,
                    CreatedAt = new DateTimeOffset(2024, 8, 20, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 20, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 42,
                    Name = "Composition API Deep Dive",
                    LecturesCount = 12,
                    DurationInHours = 5,
                    CourseId = 9,
                    CreatedAt = new DateTimeOffset(2024, 8, 20, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 20, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 10: Deep Learning with TensorFlow
                new CourseContent
                {
                    Id = 46,
                    Name = "TensorFlow Fundamentals",
                    LecturesCount = 10,
                    DurationInHours = 4,
                    CourseId = 10,
                    CreatedAt = new DateTimeOffset(2024, 8, 22, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 22, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 47,
                    Name = "Deep Neural Networks",
                    LecturesCount = 14,
                    DurationInHours = 6,
                    CourseId = 10,
                    CreatedAt = new DateTimeOffset(2024, 8, 22, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 22, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 48,
                    Name = "Convolutional Neural Networks (CNNs)",
                    LecturesCount = 16,
                    DurationInHours = 7,
                    CourseId = 10,
                    CreatedAt = new DateTimeOffset(2024, 8, 22, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 22, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 11: Cloud Architecture on AWS
                new CourseContent
                {
                    Id = 51,
                    Name = "AWS Fundamentals and Core Services",
                    LecturesCount = 11,
                    DurationInHours = 5,
                    CourseId = 11,
                    CreatedAt = new DateTimeOffset(2024, 8, 24, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 24, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 52,
                    Name = "EC2 and Compute Services",
                    LecturesCount = 12,
                    DurationInHours = 5,
                    CourseId = 11,
                    CreatedAt = new DateTimeOffset(2024, 8, 24, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 24, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 12: Full Stack JavaScript Development
                new CourseContent
                {
                    Id = 56,
                    Name = "Modern JavaScript (ES6+)",
                    LecturesCount = 10,
                    DurationInHours = 4,
                    CourseId = 12,
                    CreatedAt = new DateTimeOffset(2024, 8, 26, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 26, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 57,
                    Name = "Node.js and Express Backend",
                    LecturesCount = 14,
                    DurationInHours = 6,
                    CourseId = 12,
                    CreatedAt = new DateTimeOffset(2024, 8, 26, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 26, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 13: Advanced Python Programming
                new CourseContent
                {
                    Id = 61,
                    Name = "Python Advanced Syntax and Features",
                    LecturesCount = 11,
                    DurationInHours = 5,
                    CourseId = 13,
                    CreatedAt = new DateTimeOffset(2024, 8, 28, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 28, 10,0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 62,
                    Name = "Decorators and Context Managers",
                    LecturesCount = 9,
                    DurationInHours = 4,
                    CourseId = 13,
                    CreatedAt = new DateTimeOffset(2024, 8, 28, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 28, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 14: UI/UX Design Masterclass
                new CourseContent
                {
                    Id = 66,
                    Name = "Design Thinking and User Research",
                    LecturesCount = 10,
                    DurationInHours = 4,
                    CourseId = 14,
                    CreatedAt = new DateTimeOffset(2024, 8, 30, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 30, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 67,
                    Name = "UI Design Principles and Typography",
                    LecturesCount = 12,
                    DurationInHours = 5,
                    CourseId = 14,
                    CreatedAt = new DateTimeOffset(2024, 8, 30, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 30, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 15: Business Analysis and Process Optimization
                new CourseContent
                {
                    Id = 71,
                    Name = "Business Analysis Fundamentals",
                    LecturesCount = 9,
                    DurationInHours = 4,
                    CourseId = 15,
                    CreatedAt = new DateTimeOffset(2024, 9, 1, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 1, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 72,
                    Name = "Requirements Gathering and Documentation",
                    LecturesCount = 11,
                    DurationInHours = 5,
                    CourseId = 15,
                    CreatedAt = new DateTimeOffset(2024, 9, 1, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 1, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 16: Digital Marketing and Growth Hacking
                new CourseContent
                {
                    Id = 76,
                    Name = "Digital Marketing Foundations",
                    LecturesCount = 10,
                    DurationInHours = 4,
                    CourseId = 16,
                    CreatedAt = new DateTimeOffset(2024, 9, 3, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 3, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 77,
                    Name = "SEO and Content Marketing",
                    LecturesCount = 13,
                    DurationInHours = 5,
                    CourseId = 16,
                    CreatedAt = new DateTimeOffset(2024, 9, 3, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 3, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 17: Cybersecurity Fundamentals
                new CourseContent
                {
                    Id = 81,
                    Name = "Introduction to Cybersecurity",
                    LecturesCount = 8,
                    DurationInHours = 3,
                    CourseId = 17,
                    CreatedAt = new DateTimeOffset(2024, 9, 5, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 5, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 82,
                    Name = "Network Security and Protocols",
                    LecturesCount = 12,
                    DurationInHours = 5,
                    CourseId = 17,
                    CreatedAt = new DateTimeOffset(2024, 9, 5, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 5, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 18: Advanced Cybersecurity and Ethical Hacking
                new CourseContent
                {
                    Id = 86,
                    Name = "Advanced Penetration Testing",
                    LecturesCount = 15,
                    DurationInHours = 7,
                    CourseId = 18,
                    CreatedAt = new DateTimeOffset(2024, 9, 7, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 7, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 87,
                    Name = "Web Application Security Testing",
                    LecturesCount = 13,
                    DurationInHours = 6,
                    CourseId = 18,
                    CreatedAt = new DateTimeOffset(2024, 9, 7, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 7, 10, 0, 0, TimeSpan.Zero)
                },
                
                // Course 19: Figma for Product Design
                new CourseContent
                {
                    Id = 91,
                    Name = "Figma Interface and Basics",
                    LecturesCount = 8,
                    DurationInHours = 3,
                    CourseId = 19,
                    CreatedAt = new DateTimeOffset(2024, 9, 9, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 9, 10, 0, 0, TimeSpan.Zero)
                },
                new CourseContent
                {
                    Id = 92,
                    Name = "Components and Auto Layout",
                    LecturesCount = 11,
                    DurationInHours = 5,
                    CourseId = 19,
                    CreatedAt = new DateTimeOffset(2024, 9, 9, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 9, 10, 0, 0, TimeSpan.Zero)
                },
                
            };

            modelBuilder.Entity<CourseContent>().HasData(courseContents);
        }



        public static async Task SeedIdentityDataAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!userManager.Users.Any())
            {
                if (!roleManager.Roles.Any())
                {
                    var adminRole = new IdentityRole("Admin");
                    await roleManager.CreateAsync(adminRole);

                    var userRole = new IdentityRole("User");
                    await roleManager.CreateAsync(userRole);
                }
                else
                {
                    Console.WriteLine($"\n{string.Join(", ", roleManager.Roles.Select(r => r.Name))}\n");
                }

                var user = new ApplicationUser()
                {
                    FirstName = "Muhammad",
                    LastName = "Kamal",
                    UserName = "admin_Muhammad",
                    Email = "admin@byway.com",


                };

                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, "Admin");
            }
            
        }
    }
}
