using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<product>
    {
        public void Configure(EntityTypeBuilder<product> builder)
        {
           builder.Property(p => p.id).IsRequired();
           builder.Property(p =>p.name).IsRequired().HasMaxLength(100);
           builder.Property(p =>p.Description).IsRequired().HasMaxLength(180);
           builder.Property(p =>p.pictureurl).IsRequired();
           builder.Property(p =>p.price).HasColumnType("decimal(18,2)");
           builder.HasOne(b =>b.producttype).WithMany().HasForeignKey(p =>p.producttypeId);
           builder.HasOne(t =>t.productbrand).WithMany().HasForeignKey(p=>p.productbrandId);
        }
    }
}