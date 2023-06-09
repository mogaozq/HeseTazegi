using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Domain.Entities
{
    public class FoodNutritionFact
    {
        public int FoodId { get; set; }
        public int NutrientId { get; set; }
        public int NutrientValue { get; set; }

        public FoodNutritionFact(int foodId, int nutrientId, int nutrientValue)
        {
            FoodId = foodId;
            NutrientId = nutrientId;
            NutrientValue = nutrientValue;
        }

        public Food Food { get; set; }
        public Nutrient Nutrient { get; set; }
    }
}
