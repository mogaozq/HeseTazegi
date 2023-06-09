using HeseTazegi.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Persistance.Configurations
{
    public class FoodNutritionFactConfiguration : IEntityTypeConfiguration<FoodNutritionFact>
    {
        public void Configure(EntityTypeBuilder<FoodNutritionFact> builder)
        {
            builder.HasKey(e => new {e.FoodId,e.NutrientId});

            builder
                .HasOne(e => e.Food)
                .WithMany(e=>e.NutritionFacts)
                .HasForeignKey(e => e.FoodId);

            builder
                .HasOne(e => e.Nutrient)
                .WithMany(e=>e.NutritionFacts)
                .HasForeignKey(e => e.NutrientId);
        }
    }
}
