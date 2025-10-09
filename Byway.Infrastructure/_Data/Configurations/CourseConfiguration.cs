using Byway.Domain.Entities.Course_;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Infrastructure._Data.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Level)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(100);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);
            builder.Property(c => c.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(c => c.CoverPictureUrl)
                .HasMaxLength(500);
            builder.HasOne(c => c.Category)
                   .WithMany(c => c.Courses)
                   .HasForeignKey(c => c.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Instructor)
                   .WithMany(i => i.Courses)
                   .HasForeignKey(c => c.InstructorId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Contents)
                   .WithOne(c => c.Course)
                   .HasForeignKey(c => c.CourseId);
                   
        }
    }
}
