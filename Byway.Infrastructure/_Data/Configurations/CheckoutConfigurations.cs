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
    public class CheckoutConfigurations : IEntityTypeConfiguration<Checkout>
    {
        public void Configure(EntityTypeBuilder<Checkout> builder)
        {
            builder.Property(c => c.SubTotal)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Tax)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(c => c.TotalPrice)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(c => c.PaymentMethod)
                   .HasMaxLength(50);

            builder.Property(c => c.PaymentTransactionId)
                   .HasMaxLength(200);

            builder.Property(c => c.Status)
                   .IsRequired()
                   .HasConversion<string>();

            builder.HasMany(c => c.PurchasedCourses)
                   .WithOne(e => e.Checkout)
                   .HasForeignKey(e => e.CheckoutId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

