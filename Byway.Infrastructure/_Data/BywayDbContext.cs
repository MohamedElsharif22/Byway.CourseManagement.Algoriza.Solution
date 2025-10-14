using Byway.Domain.Entities;
using Byway.Domain.Entities.Checkout;
using Byway.Domain.Entities.Course_;
using Byway.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Infrastructure._Data
{
    public class BywayDbContext(DbContextOptions<BywayDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTimeOffset.UtcNow;
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                    entry.Entity.UpdatedAt = now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;
                }
                else if(entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.UpdatedAt = now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            SetGlobalQueryFilter<BaseEntity>(modelBuilder, e => !e.IsDeleted);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BywayDbContext).Assembly);

            BywayContextSeed.SeedDatabase(modelBuilder);
        }

        private void SetGlobalQueryFilter<TBase>(ModelBuilder modelBuilder, Expression<Func<TBase, bool>> filter)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(TBase).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(filter.Parameters[0], parameter, filter.Body);
                    var lambda = Expression.Lambda(body, parameter);

                    entityType.SetQueryFilter(lambda);
                }
            }
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseContent> CoursesContents { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Enrollment> BoughtCourses { get; set; }

    }
}

