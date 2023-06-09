using HeseTazegi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<FoodNutritionFact> FoodNutritionFacts { get; set; }
        public DbSet<FoodIngredient> FoodIngredients{ get; set; }
        public DbSet<FoodEquipment> FoodEquipments { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAllergicIngredient> UserAllergicIngredients { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
