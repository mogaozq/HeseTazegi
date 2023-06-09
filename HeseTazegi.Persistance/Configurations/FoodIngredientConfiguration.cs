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
    public class FoodIngredientConfiguration : IEntityTypeConfiguration<FoodIngredient>
    {
        public void Configure(EntityTypeBuilder<FoodIngredient> builder)
        {
            builder.HasKey(e => new {e.FoodId,e.IngredientId});

            builder
                .HasOne(e => e.Food)
                .WithMany(e=>e.FoodIngredients)
                .HasForeignKey(e => e.FoodId);

            builder
                .HasOne(e => e.Ingredient)
                .WithMany(e=>e.FoodIngredients)
                .HasForeignKey(e => e.IngredientId);
        }
    }
}
