using AutoMapper;
using HeseTazegi.Application.Categories.Dtos;
using HeseTazegi.Application.Equipments.Dtos;
using HeseTazegi.Application.Foods.Dtos;
using HeseTazegi.Application.Ingredients.Dtos;
using HeseTazegi.Application.Nutrients.Dtos;
using HeseTazegi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Common.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Food, FoodDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<Nutrient, NutrientDto>();

            CreateMap<FoodNutritionFact, FoodNutritionFactDto>()
                .ForMember(d => d.NutrientName, c => c.MapFrom(s => s.Nutrient.Name));

            CreateMap<FoodIngredient, IngredientDto>()
                .ForMember(d => d.Id, c => c.MapFrom(s => s.IngredientId))
                .ForMember(d => d.Name, c => c.MapFrom(s => s.Ingredient.Name));

            CreateMap<FoodEquipment, EquipmentDto>()
                .ForMember(d => d.Id, c => c.MapFrom(s => s.EquipmentId))
                .ForMember(d => d.Name, c => c.MapFrom(s => s.Equipment.Name));
        }
    }
}
