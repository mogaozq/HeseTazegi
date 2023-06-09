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
    public class UserAllergicIngredientConfiguration : IEntityTypeConfiguration<UserAllergicIngredient>
    {
        public void Configure(EntityTypeBuilder<UserAllergicIngredient> builder)
        {
            builder.HasKey(e => new {e.UserId,e.IngredientId});

            builder
                .HasOne(e => e.User)
                .WithMany(e=>e.UserAllergicIngredients)
                .HasForeignKey(e => e.UserId);

            builder
                .HasOne(e => e.Ingredient)
                .WithMany(e=>e.UserAllergicIngredients)
                .HasForeignKey(e => e.IngredientId);
        }
    }
}
