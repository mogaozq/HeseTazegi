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
    public class FoodEquipmentConfiguration : IEntityTypeConfiguration<FoodEquipment>
    {
        public void Configure(EntityTypeBuilder<FoodEquipment> builder)
        {
            builder.HasKey(e => new {e.FoodId,e.EquipmentId});

            builder
                .HasOne(e => e.Food)
                .WithMany(e=>e.FoodEquipments)
                .HasForeignKey(e => e.FoodId);

            builder
                .HasOne(e => e.Equipment)
                .WithMany(e=>e.FoodEquipments)
                .HasForeignKey(e => e.EquipmentId);
        }
    }
}
