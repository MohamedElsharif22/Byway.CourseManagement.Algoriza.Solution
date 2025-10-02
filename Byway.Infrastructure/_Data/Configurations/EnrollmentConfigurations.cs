using Byway.Domain.Entities.Checkout;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Infrastructure._Data.Configurations
{
    public class EnrollmentConfigurations : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.Property(e => e.PricePaid)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(e => e.Status)
                   .IsRequired()
                   .HasConversion<string>();

            builder.HasOne(e => e.Course)
                   .WithMany(c => c.Enrollments)
                   .HasForeignKey(e => e.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.User)
                   .WithMany(u => u.EnrolledCourses)
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Checkout)
                   .WithMany(c => c.PurchasedCourses)
                   .HasForeignKey(e => e.CheckoutId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
