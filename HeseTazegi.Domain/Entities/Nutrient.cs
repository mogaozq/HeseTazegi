using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Domain.Entities
{
    public class Nutrient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Nutrient(string name)
        {
            Name = name;
        }

        public ICollection<FoodNutritionFact> NutritionFacts { get; set; }

    }
}
