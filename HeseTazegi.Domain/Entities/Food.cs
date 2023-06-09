using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Domain.Entities
{
    public class Food
    {
        public Food()
        {

        }
        public Food(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category Category { get; set; }
        public ICollection<FoodIngredient> FoodIngredients { get; set; }
        public ICollection<FoodEquipment> FoodEquipments { get; set; }
        public ICollection<FoodNutritionFact> NutritionFacts { get; set; }
    }
}
