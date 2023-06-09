using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Domain.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Ingredient(string name)
        {
            Name = name;
        }

        public ICollection<FoodIngredient> FoodIngredients { get; set; }
        public ICollection<UserAllergicIngredient> UserAllergicIngredients { get; set; }
    }
}
