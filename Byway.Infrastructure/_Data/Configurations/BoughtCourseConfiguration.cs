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
    internal class BoughtCourseConfiguration : IEntityTypeConfiguration<BoughtCourse>
    {
        public void Configure(EntityTypeBuilder<BoughtCourse> builder)
        {
            builder.HasOne(bc => bc.Course)
                   .WithMany()
                   .HasForeignKey(bc => bc.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(bc => bc.Checkout)
                   .WithMany(c => c.BoughtCourses)
                   .HasForeignKey(bc => bc.CheckoutId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
