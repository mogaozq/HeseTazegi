using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Domain.Entities
{
    public class FoodIngredient
    {
        public int FoodId { get; set; }
        public int IngredientId { get; set; }

        public FoodIngredient(int foodId, int ingredientId)
        {
            FoodId = foodId;
            IngredientId = ingredientId;
        }

        public Food Food { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
