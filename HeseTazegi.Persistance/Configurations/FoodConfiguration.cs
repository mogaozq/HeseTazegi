using HeseTazegi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Persistance.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).HasMaxLength(60).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(250).IsRequired();

            builder.HasOne(e => e.Category)
              .WithMany(e => e.Foods)
              .IsRequired();

        }
    }
}
