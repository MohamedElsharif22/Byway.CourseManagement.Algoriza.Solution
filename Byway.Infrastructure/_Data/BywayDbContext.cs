using Byway.Domain.Entities;
using Byway.Domain.Entities.Checkout;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Infrastructure._Data
{
    public class BywayDbContext(DbContextOptions<BywayDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BywayDbContext).Assembly);

            BywayContextSeed.SeedDatabase(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
    }
}

