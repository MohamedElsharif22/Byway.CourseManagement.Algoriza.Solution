using Byway.Domain.Entities;
using Byway.Domain.Entities.Checkout;
using Byway.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Infrastructure._Data
{
    public class BywayDbContext(DbContextOptions<BywayDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BywayDbContext).Assembly);

            BywayContextSeed.SeedDatabase(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(builder =>
            {
                builder.HasMany(u => u.EnrolledCourses)
                       .WithOne()
                       .HasForeignKey(bc => bc.UserId);
            });

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<BoughtCourse> BoughtCourses { get; set; }

    }
}

