using HeseTazegi.Application.Categories.Dtos;
using HeseTazegi.Application.Equipments.Dtos;
using HeseTazegi.Application.Ingredients.Dtos;
using HeseTazegi.Application.Nutrients.Dtos;
using System.Collections.Generic;

namespace HeseTazegi.Application.Foods.Dtos
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CategoryDto Category { get; set; }
        public IEnumerable<IngredientDto> FoodIngredients { get; set; }
        public IEnumerable<EquipmentDto> FoodEquipments { get; set; }
        public IEnumerable<FoodNutritionFactDto> NutritionFacts { get; set; }

        //note: this is front-end bussness to label allergic foods based on user info by getting user allergic ingredients endpoint
        //because of that I left it unimplemented
        //public bool IsAllergicForCurrentUser  { get; set; }
    }
}