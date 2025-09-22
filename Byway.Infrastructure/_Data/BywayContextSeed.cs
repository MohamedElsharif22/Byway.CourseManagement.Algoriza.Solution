using Byway.Domain.Entities;
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
                new Category { Id = 1, Name = "Programming", CreatedAt = new DateTimeOffset(2024, 8, 1, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 2, Name = "Data Science", CreatedAt = new DateTimeOffset(2024, 8, 6, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 3, Name = "Web Development", CreatedAt = new DateTimeOffset(2024, 8, 11, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 4, Name = "Mobile Development", CreatedAt = new DateTimeOffset(2024, 8, 16, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 5, Name = "Machine Learning", CreatedAt = new DateTimeOffset(2024, 8, 21, 10, 0, 0, TimeSpan.Zero) },
                new Category { Id = 6, Name = "DevOps", CreatedAt = new DateTimeOffset(2024, 8, 26, 10, 0, 0, TimeSpan.Zero) }
            };

            // Seed Instructors
            var instructors = new List<Instructor>
            {
                new Instructor
                {
                    Id = 1,
                    Name = "John Smith",
                    jopTitle = "Senior Software Engineer",
                    About = "Experienced full-stack developer with 10+ years in the industry. Passionate about teaching clean code and best practices.",
                    CreatedAt = new DateTimeOffset(2024, 8, 3, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 2,
                    Name = "Sarah Johnson",
                    jopTitle = "Data Scientist",
                    About = "PhD in Statistics with expertise in machine learning and data visualization. Former researcher at Google AI.",
                    CreatedAt = new DateTimeOffset(2024, 8, 5, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 3,
                    Name = "Mike Chen",
                    jopTitle = "Frontend Developer",
                    About = "React and Vue.js specialist with a keen eye for UI/UX design. Previously worked at Netflix and Spotify.",
                    CreatedAt = new DateTimeOffset(2024, 8, 7, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 4,
                    Name = "Emily Rodriguez",
                    jopTitle = "Mobile App Developer",
                    About = "iOS and Android development expert. Published 15+ apps on app stores with millions of downloads.",
                    CreatedAt = new DateTimeOffset(2024, 8, 9, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 5,
                    Name = "David Kumar",
                    jopTitle = "Machine Learning Engineer",
                    About = "AI researcher and engineer specializing in deep learning and computer vision. Author of 'ML in Practice'.",
                    CreatedAt = new DateTimeOffset(2024, 8, 11, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 6,
                    Name = "Lisa Thompson",
                    jopTitle = "DevOps Engineer",
                    About = "Cloud infrastructure expert with AWS and Azure certifications. Specializes in CI/CD and containerization.",
                    CreatedAt = new DateTimeOffset(2024, 8, 13, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 7,
                    Name = "Alex Morgan",
                    jopTitle = "Backend Developer",
                    About = "Microservices architecture specialist with expertise in .NET, Node.js, and distributed systems.",
                    CreatedAt = new DateTimeOffset(2024, 8, 15, 10, 0, 0, TimeSpan.Zero)
                },
                new Instructor
                {
                    Id = 8,
                    Name = "Maria Garcia",
                    jopTitle = "Full Stack Developer",
                    About = "MERN stack expert with 8 years of experience building scalable web applications for startups.",
                    CreatedAt = new DateTimeOffset(2024, 8, 17, 10, 0, 0, TimeSpan.Zero)
                }
            };

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
                    CoverPictureUrl = "https://images.unsplash.com/photo-1517077304055-6e89abbf09b0?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 4, 10, 0, 0, TimeSpan.Zero)
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
                    CoverPictureUrl = "https://images.unsplash.com/photo-1551288049-bebda4e38f71?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 6, 10, 0, 0, TimeSpan.Zero)
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
                    CoverPictureUrl = "https://images.unsplash.com/photo-1633356122544-f134324a6cee?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 8, 10, 0, 0, TimeSpan.Zero)
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
                    CoverPictureUrl = "https://images.unsplash.com/photo-1512941937669-90a1b58e7e9c?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 10, 10, 0, 0, TimeSpan.Zero)
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
                    CoverPictureUrl = "https://images.unsplash.com/photo-1555949963-aa79dcee981c?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 12, 10, 0, 0, TimeSpan.Zero)
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
                    CoverPictureUrl = "https://images.unsplash.com/photo-1618401471353-b98afee0b2eb?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 14, 10, 0, 0, TimeSpan.Zero)
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
                    CoverPictureUrl = "https://images.unsplash.com/photo-1461749280684-dccba630e2f6?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 16, 10, 0, 0, TimeSpan.Zero)
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
                    CoverPictureUrl = "https://images.unsplash.com/photo-1607252650355-f7fd0460ccdb?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 18, 10, 0, 0, TimeSpan.Zero)
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
                    CoverPictureUrl = "https://images.unsplash.com/photo-1627398242454-45a1465c2479?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 20, 10, 0, 0, TimeSpan.Zero)
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
                    CoverPictureUrl = "https://images.unsplash.com/photo-1620712943543-bcc4688e7485?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 22, 10, 0, 0, TimeSpan.Zero)
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
                    CoverPictureUrl = "https://images.unsplash.com/photo-1451187580459-43490279c0fa?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 24, 10, 0, 0, TimeSpan.Zero)
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
                    CoverPictureUrl = "https://images.unsplash.com/photo-1579468118864-1b9ea3c0db4a?w=800&h=600&fit=crop&crop=center",
                    CreatedAt = new DateTimeOffset(2024, 8, 26, 10, 0, 0, TimeSpan.Zero)
                }
            };

            // Seed the data using ModelBuilder
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Instructor>().HasData(instructors);
            modelBuilder.Entity<Course>().HasData(courses);
        }
        public static async Task SeedDatabaseAsync(DbContext context)
        {
            // Check if data already exists
            if (await context.Set<Category>().AnyAsync())
                return; // Data already seeded

            // Add Categories
            var categories = new List<Category>
            {
                new Category { Name = "Programming" },
                new Category { Name = "Data Science" },
                new Category { Name = "Web Development" },
                new Category { Name = "Mobile Development" },
                new Category { Name = "Machine Learning" },
                new Category { Name = "DevOps" }
            };

            await context.Set<Category>().AddRangeAsync(categories);
            await context.SaveChangesAsync();

            // Add Instructors
            var instructors = new List<Instructor>
            {
                new Instructor
                {
                    Name = "John Smith",
                    jopTitle = "Senior Software Engineer",
                    About = "Experienced full-stack developer with 10+ years in the industry."
                },
                new Instructor
                {
                    Name = "Sarah Johnson",
                    jopTitle = "Data Scientist",
                    About = "PhD in Statistics with expertise in machine learning and data visualization."
                },
                new Instructor
                {
                    Name = "Mike Chen",
                    jopTitle = "Frontend Developer",
                    About = "React and Vue.js specialist with a keen eye for UI/UX design."
                },
                new Instructor
                {
                    Name = "Emily Rodriguez",
                    jopTitle = "Mobile App Developer",
                    About = "iOS and Android development expert with 15+ published apps."
                },
                new Instructor
                {
                    Name = "David Kumar",
                    jopTitle = "Machine Learning Engineer",
                    About = "AI researcher and engineer specializing in deep learning and computer vision."
                },
                new Instructor
                {
                    Name = "Lisa Thompson",
                    jopTitle = "DevOps Engineer",
                    About = "Cloud infrastructure expert with AWS and Azure certifications."
                },
                new Instructor
                {
                    Name = "Alex Morgan",
                    jopTitle = "Backend Developer",
                    About = "Microservices architecture specialist with expertise in .NET and Node.js."
                },
                new Instructor
                {
                    Name = "Maria Garcia",
                    jopTitle = "Full Stack Developer",
                    About = "MERN stack expert with 8 years of experience building scalable web applications."
                }
            };

            await context.Set<Instructor>().AddRangeAsync(instructors);
            await context.SaveChangesAsync();

            // Add Courses (after categories and instructors are saved to get their IDs)
            var programmingCategory = await context.Set<Category>().FirstAsync(c => c.Name == "Programming");
            var dataScienceCategory = await context.Set<Category>().FirstAsync(c => c.Name == "Data Science");
            var webDevCategory = await context.Set<Category>().FirstAsync(c => c.Name == "Web Development");
            var mobileCategory = await context.Set<Category>().FirstAsync(c => c.Name == "Mobile Development");
            var machineLearningCategory = await context.Set<Category>().FirstAsync(c => c.Name == "Machine Learning");
            var devOpsCategory = await context.Set<Category>().FirstAsync(c => c.Name == "DevOps");

            var johnInstructor = await context.Set<Instructor>().FirstAsync(i => i.Name == "John Smith");
            var sarahInstructor = await context.Set<Instructor>().FirstAsync(i => i.Name == "Sarah Johnson");
            var mikeInstructor = await context.Set<Instructor>().FirstAsync(i => i.Name == "Mike Chen");
            var emilyInstructor = await context.Set<Instructor>().FirstAsync(i => i.Name == "Emily Rodriguez");
            var davidInstructor = await context.Set<Instructor>().FirstAsync(i => i.Name == "David Kumar");
            var lisaInstructor = await context.Set<Instructor>().FirstAsync(i => i.Name == "Lisa Thompson");
            var alexInstructor = await context.Set<Instructor>().FirstAsync(i => i.Name == "Alex Morgan");
            var mariaInstructor = await context.Set<Instructor>().FirstAsync(i => i.Name == "Maria Garcia");

            var courses = new List<Course>
            {
                new Course
                {
                    Title = "Complete C# Programming Bootcamp",
                    Description = "Master C# programming from basics to advanced topics including OOP, LINQ, and async programming.",
                    Rating = 5,
                    Price = 99.99m,
                    CategoryId = programmingCategory.Id,
                    InstructorId = johnInstructor.Id,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1517077304055-6e89abbf09b0?w=800&h=600&fit=crop&crop=center"
                },
                new Course
                {
                    Title = "Data Science with Python",
                    Description = "Learn data analysis, visualization, and machine learning using Python, pandas, and scikit-learn.",
                    Rating = 4,
                    Price = 129.99m,
                    CategoryId = dataScienceCategory.Id,
                    InstructorId = sarahInstructor.Id,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1551288049-bebda4e38f71?w=800&h=600&fit=crop&crop=center"
                },
                new Course
                {
                    Title = "Modern React Development",
                    Description = "Build dynamic web applications using React, Redux, and modern JavaScript ES6+ features.",
                    Rating = 5,
                    Price = 89.99m,
                    CategoryId = webDevCategory.Id,
                    InstructorId = mikeInstructor.Id,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1633356122544-f134324a6cee?w=800&h=600&fit=crop&crop=center"
                },
                new Course
                {
                    Title = "iOS App Development with Swift",
                    Description = "Create professional iOS applications using Swift and SwiftUI. Publish your first app to the App Store.",
                    Rating = 4,
                    Price = 149.99m,
                    CategoryId = mobileCategory.Id,
                    InstructorId = emilyInstructor.Id,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1512941937669-90a1b58e7e9c?w=800&h=600&fit=crop&crop=center"
                },
                new Course
                {
                    Title = "Machine Learning Fundamentals",
                    Description = "Introduction to machine learning algorithms, neural networks, and practical implementation.",
                    Rating = 5,
                    Price = 179.99m,
                    CategoryId = machineLearningCategory.Id,
                    InstructorId = davidInstructor.Id,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1555949963-aa79dcee981c?w=800&h=600&fit=crop&crop=center"
                },
                new Course
                {
                    Title = "Docker and Kubernetes Mastery",
                    Description = "Learn containerization and orchestration for modern application deployment and scaling.",
                    Rating = 4,
                    Price = 139.99m,
                    CategoryId = devOpsCategory.Id,
                    InstructorId = lisaInstructor.Id,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1618401471353-b98afee0b2eb?w=800&h=600&fit=crop&crop=center"
                },
                new Course
                {
                    Title = "ASP.NET Core Web API Development",
                    Description = "Build robust RESTful APIs using ASP.NET Core, Entity Framework, and clean architecture principles.",
                    Rating = 5,
                    Price = 119.99m,
                    CategoryId = programmingCategory.Id,
                    InstructorId = alexInstructor.Id,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1461749280684-dccba630e2f6?w=800&h=600&fit=crop&crop=center"
                },
                new Course
                {
                    Title = "Android Development with Kotlin",
                    Description = "Create native Android applications using Kotlin, Android Jetpack, and Material Design.",
                    Rating = 4,
                    Price = 134.99m,
                    CategoryId = mobileCategory.Id,
                    InstructorId = emilyInstructor.Id,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1607252650355-f7fd0460ccdb?w=800&h=600&fit=crop&crop=center"
                },
                new Course
                {
                    Title = "Vue.js Complete Guide",
                    Description = "Master Vue.js 3 with Composition API, Vuex, Vue Router, and build modern single-page applications.",
                    Rating = 4,
                    Price = 94.99m,
                    CategoryId = webDevCategory.Id,
                    InstructorId = mikeInstructor.Id,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1627398242454-45a1465c2479?w=800&h=600&fit=crop&crop=center"
                },
                new Course
                {
                    Title = "Deep Learning with TensorFlow",
                    Description = "Advanced machine learning course covering neural networks, CNNs, RNNs, and practical AI applications.",
                    Rating = 5,
                    Price = 199.99m,
                    CategoryId = machineLearningCategory.Id,
                    InstructorId = davidInstructor.Id,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1620712943543-bcc4688e7485?w=800&h=600&fit=crop&crop=center"
                },
                new Course
                {
                    Title = "Cloud Architecture on AWS",
                    Description = "Design and deploy scalable cloud solutions using AWS services, serverless architecture, and best practices.",
                    Rating = 4,
                    Price = 159.99m,
                    CategoryId = devOpsCategory.Id,
                    InstructorId = lisaInstructor.Id,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1451187580459-43490279c0fa?w=800&h=600&fit=crop&crop=center"
                },
                new Course
                {
                    Title = "Full Stack JavaScript Development",
                    Description = "End-to-end web development using Node.js, Express, React, and MongoDB (MERN stack).",
                    Rating = 5,
                    Price = 144.99m,
                    CategoryId = webDevCategory.Id,
                    InstructorId = mariaInstructor.Id,
                    CoverPictureUrl = "https://images.unsplash.com/photo-1579468118864-1b9ea3c0db4a?w=800&h=600&fit=crop&crop=center"
                }
            };

            await context.Set<Course>().AddRangeAsync(courses);
            await context.SaveChangesAsync();
        }
    }
}
