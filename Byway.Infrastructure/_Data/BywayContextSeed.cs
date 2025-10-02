using Byway.Domain.Entities;
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
                    ProfilePictureUrl = "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=400&h=400&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 3, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 3, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 2,
                    Name = "Sarah Johnson",
                    JopTitle = JobTitles.DataScientist,
                    About = "PhD in Statistics with expertise in machine learning and data visualization. Former researcher at Google AI.",
                    ProfilePictureUrl = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=400&h=400&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 5, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 5, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 3,
                    Name = "Mike Chen",
                    JopTitle = JobTitles.Frontend_Developer,
                    About = "React and Vue.js specialist with a keen eye for UI/UX design. Previously worked at Netflix and Spotify.",
                    ProfilePictureUrl = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=400&h=400&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 7, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 7, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 4,
                    Name = "Emily Rodriguez",
                    JopTitle = JobTitles.MobileApp_Developer,
                    About = "iOS and Android development expert. Published 15+ apps on app stores with millions of downloads.",
                    ProfilePictureUrl = "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=400&h=400&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 9, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 9, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 5,
                    Name = "David Kumar",
                    JopTitle = JobTitles.MachineLearning_Engineer,
                    About = "AI researcher and engineer specializing in deep learning and computer vision. Author of 'ML in Practice'.",
                    ProfilePictureUrl = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=400&h=400&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 11, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 11, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 6,
                    Name = "Lisa Thompson",
                    JopTitle = JobTitles.DevOps_Engineer,
                    About = "Cloud infrastructure expert with AWS and Azure certifications. Specializes in CI/CD and containerization.",
                    ProfilePictureUrl = "https://images.unsplash.com/photo-1487412720507-e7ab37603c6f?w=400&h=400&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 13, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 13, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 7,
                    Name = "Alex Morgan",
                    JopTitle = JobTitles.Backend_Developer,
                    About = "Microservices architecture specialist with expertise in .NET, Node.js, and distributed systems.",
                    ProfilePictureUrl = "https://images.unsplash.com/photo-1519085360753-af0119f7cbe7?w=400&h=400&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 15, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 15, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 8,
                    Name = "Maria Garcia",
                    JopTitle = JobTitles.FullStack_Developer,
                    About = "MERN stack expert with 8 years of experience building scalable web applications for startups.",
                    ProfilePictureUrl = "https://images.unsplash.com/photo-1534528741775-53994a69daeb?w=400&h=400&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 17, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 17, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 9,
                    Name = "Robert Wilson",
                    JopTitle = JobTitles.UXUI_Designer,
                    About = "Award-winning designer specializing in user experience research and interface design. Former design lead at Adobe.",
                    ProfilePictureUrl = "https://images.unsplash.com/photo-1463453091185-61582044d556?w=400&h=400&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 19, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 19, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 10,
                    Name = "Jennifer Lee",
                    JopTitle = JobTitles.Business_Analyst,
                    About = "MBA from Stanford with 12 years in strategic consulting. Expert in business process optimization and digital transformation.",
                    ProfilePictureUrl = "https://images.unsplash.com/photo-1531123897727-8f129e1688ce?w=400&h=400&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 21, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 21, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 11,
                    Name = "Michael Torres",
                    JopTitle = JobTitles.DigitalMarketingStrategist,
                    About = "Former marketing director at Fortune 500 companies. Specialist in growth hacking and performance marketing.",
                    ProfilePictureUrl = "https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?w=400&h=400&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 23, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 8, 23, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 12,
                    Name = "Amanda Zhang",
                    JopTitle = JobTitles.CybersecurityExpert,
                    About = "Ethical hacker and security consultant with CISSP certification. Former security engineer at Microsoft.",
                    ProfilePictureUrl = "https://images.unsplash.com/photo-1489424731084-a5d8b219a5bb?w=400&h=400&fit=crop&crop=center",
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
                    LecturesCount = 145,
                    DurationInMinutes = 1200,
                    CategoryId = 1,
                    InstructorId = 1,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1517077304055-6e89abbf09b0?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 180,
                    DurationInMinutes = 1500,
                    CategoryId = 2,
                    InstructorId = 2,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1551288049-bebda4e38f71?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 120,
                    DurationInMinutes = 900,
                    CategoryId = 3,
                    InstructorId = 3,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1633356122544-f134324a6cee?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 165,
                    DurationInMinutes = 1350,
                    CategoryId = 4,
                    InstructorId = 4,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1512941937669-90a1b58e7e9c?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 200,
                    DurationInMinutes = 1800,
                    CategoryId = 5,
                    InstructorId = 5,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1555949963-aa79dcee981c?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 155,
                    DurationInMinutes = 1200,
                    CategoryId = 6,
                    InstructorId = 6,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1618401471353-b98afee0b2eb?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 135,
                    DurationInMinutes = 1050,
                    CategoryId = 1,
                    InstructorId = 7,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1461749280684-dccba630e2f6?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 150,
                    DurationInMinutes = 1250,
                    CategoryId = 4,
                    InstructorId = 4,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1607252650355-f7fd0460ccdb?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 110,
                    DurationInMinutes = 850,
                    CategoryId = 3,
                    InstructorId = 3,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1627398242454-45a1465c2479?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 220,
                    DurationInMinutes = 2000,
                    CategoryId = 5,
                    InstructorId = 5,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1620712943543-bcc4688e7485?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 175,
                    DurationInMinutes = 1400,
                    CategoryId = 6,
                    InstructorId = 6,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1451187580459-43490279c0fa?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 160,
                    DurationInMinutes = 1300,
                    CategoryId = 3,
                    InstructorId = 8,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1579468118864-1b9ea3c0db4a?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 125,
                    DurationInMinutes = 950,
                    CategoryId = 1,
                    InstructorId = 1,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1526379095098-d400fd0bf935?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 140,
                    DurationInMinutes = 1100,
                    CategoryId = 7,
                    InstructorId = 9,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1541701494587-cb58502866ab?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 130,
                    DurationInMinutes = 1000,
                    CategoryId = 8,
                    InstructorId = 10,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 115,
                    DurationInMinutes = 900,
                    CategoryId = 9,
                    InstructorId = 11,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1460925895917-afdab827c52f?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 170,
                    DurationInMinutes = 1400,
                    CategoryId = 10,
                    InstructorId = 12,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1550751827-4bd374c3f58b?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 190,
                    DurationInMinutes = 1650,
                    CategoryId = 10,
                    InstructorId = 12,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1563013544-824ae1b704d3?w=800&h=600&fit=crop&crop=center",
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
                    LecturesCount = 105,
                    DurationInMinutes = 800,
                    CategoryId = 7,
                    InstructorId = 9,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1609277205247-56d6e9eb9b85?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 9, 9, 10, 0, 0, TimeSpan.Zero),
                    UpdatedAt = new DateTimeOffset(2024, 9, 9, 10, 0, 0, TimeSpan.Zero)
                }
            };

            modelBuilder.Entity<Course>().HasData(courses);
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

                var user = new ApplicationUser()
                {
                    FirstName = "Muhammad",
                    LastName = "Kamal",
                    UserName = "admin_Muhammad",
                    Email = "admin@byway.com",


                };

                await userManager.CreateAsync(user, "P@ssw0rd");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
