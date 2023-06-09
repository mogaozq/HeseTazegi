using HeseTazegi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Persistance
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedCategoryAsync(ApplicationDbContext context)
        {
            if (context.Categories.Any())
                return;

            context.Categories.AddRange(new Category[]
            {
                new Category("پلو"),
                new Category("کباب"),
                new Category("پاستا"),
                new Category("پیتزا"),
                new Category("خوراک حبوبات"),
                new Category("آش"),
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedIngredientsAsync(ApplicationDbContext context)
        {
            if (context.Ingredients.Any())
                return;

            context.Ingredients.AddRange(new Ingredient[]
            {
                new Ingredient("گوجه"),
                new Ingredient("پیاز"),
                new Ingredient("سیب زمینی"),
                new Ingredient("نان"),
                new Ingredient("نخود"),
                new Ingredient("لوبیا"),
                new Ingredient("تخم مرغ"),
                new Ingredient("پنیر پیتزا"),
                new Ingredient("رب گوجه فرنگی"),
                new Ingredient("آرد"),
                new Ingredient("نمک"),
                new Ingredient("فلفل"),
                new Ingredient("فلفل دلمه ای"),
                new Ingredient("عدس"),
                new Ingredient("بادمجان"),
                new Ingredient("برنج"),
                new Ingredient("مرغ"),
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedEquipmentsAsync(ApplicationDbContext context)
        {
            if (context.Equipments.Any())
                return;

            context.Equipments.AddRange(new Equipment[]
            {
                new Equipment("چاقو"),
                new Equipment("بشقاب"),
                new Equipment("ماهیتابه"),
                new Equipment("آبکش"),
                new Equipment("قابلمه"),
                new Equipment("کفگیر"),
                new Equipment("پیمانه")
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedNutrientsAsync(ApplicationDbContext context)
        {
            if (context.Nutrients.Any())
                return;

            context.Nutrients.AddRange(new Nutrient[]
            {
                new Nutrient("انرژی"),
                new Nutrient("کربوهیدرات"),
                new Nutrient("فیبر"),
                new Nutrient("قند"),
                new Nutrient("پروتئین"),
                new Nutrient("سدیم"),
                new Nutrient("کلسترول"),
                new Nutrient("چربی"),
                new Nutrient("ویتامین سی"),
                new Nutrient("ویتامین آ"),
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedFoodsAsync(ApplicationDbContext context)
        {
            if (context.Foods.Any())
                return;

            var poloCategory = context.Categories.Single(c => c.Name == "پلو");
            var kababCategory = context.Categories.Single(c => c.Name == "کباب");
            var pitzaCategory = context.Categories.Single(c => c.Name == "پیتزا");
            var ashCategory = context.Categories.Single(c => c.Name == "آش");

            var energyNutrient = context.Nutrients.Single(c => c.Name == "انرژی");
            var carbohydrateNutrient = context.Nutrients.Single(c => c.Name == "کربوهیدرات");
            var fiberNutrient = context.Nutrients.Single(c => c.Name == "فیبر");
            var sugarNutrient = context.Nutrients.Single(c => c.Name == "قند");
            var proteinNutrient = context.Nutrients.Single(c => c.Name == "پروتئین");
            var vitaminCNutrient = context.Nutrients.Single(c => c.Name == "ویتامین سی");
            var vitaminANutrient = context.Nutrients.Single(c => c.Name == "ویتامین آ");


            context.Foods.AddRange(new Food[]
            {
                new Food("استامبولی","توضیحات مربوط به استامبولی")
                {
                    Category = poloCategory,
                },
                new Food("آفریکانو","توضیحات مربوط به آفریکانو")
                {
                    Category = pitzaCategory
                },
                new Food("آش سبزی","توضیحات مربوط به آش سبزی")
                {
                    Category = ashCategory
                },
                new Food("آش شله قلم کار","توضیحات مربوط به آش شله قلم کار")
                {
                    Category = ashCategory
                },
                new Food("آش رشته","توضیحات مربوط به آش رشته")
                {
                    Category = ashCategory
                }
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedFoodIngredientsAsync(ApplicationDbContext context)
        {
            if (context.FoodIngredients.Any())
                return;

            var estamboliFood = context.Foods.Single(c => c.Name == "استامبولی");
            var africanoFood = context.Foods.Single(c => c.Name == "آفریکانو");

            var saltIngredient = context.Ingredients.Single(c => c.Name == "نمک");
            var pepperIngredient = context.Ingredients.Single(c => c.Name == "فلفل");
            var chickenIngredient = context.Ingredients.Single(c => c.Name == "مرغ");
            var ricejIngredient = context.Ingredients.Single(c => c.Name == "برنج");
            var potatoIngredient = context.Ingredients.Single(c => c.Name == "سیب زمینی");

            context.FoodIngredients.AddRange(new FoodIngredient[]
            {
                new FoodIngredient(estamboliFood.Id, saltIngredient.Id),
                new FoodIngredient(estamboliFood.Id, pepperIngredient.Id),
                new FoodIngredient(estamboliFood.Id, chickenIngredient.Id),
                new FoodIngredient(estamboliFood.Id, ricejIngredient.Id),
                new FoodIngredient(estamboliFood.Id, potatoIngredient.Id),

                new FoodIngredient(africanoFood.Id, saltIngredient.Id),
                new FoodIngredient(africanoFood.Id, chickenIngredient.Id),
                new FoodIngredient(africanoFood.Id, ricejIngredient.Id),
                new FoodIngredient(africanoFood.Id, potatoIngredient.Id),
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedFoodEquipmentsAsync(ApplicationDbContext context)
        {
            if (context.FoodEquipments.Any())
                return;

            var estamboliFood = context.Foods.Single(c => c.Name == "استامبولی");
            var africanoFood = context.Foods.Single(c => c.Name == "آفریکانو");

            var knifeEquipment = context.Equipments.Single(c => c.Name == "چاقو");
            var plateEquipment = context.Equipments.Single(c => c.Name == "بشقاب");
            var panEquipment = context.Equipments.Single(c => c.Name == "ماهیتابه");

            context.FoodEquipments.AddRange(new FoodEquipment[]
            {
                new FoodEquipment(estamboliFood.Id, knifeEquipment.Id),
                new FoodEquipment(estamboliFood.Id, plateEquipment.Id),
                new FoodEquipment(estamboliFood.Id, panEquipment.Id),

                new FoodEquipment(africanoFood.Id, knifeEquipment.Id),
                new FoodEquipment(africanoFood.Id, panEquipment.Id)
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedFoodNutritionFactsAsync(ApplicationDbContext context)
        {
            if (context.FoodNutritionFacts.Any())
                return;

            var estamboliFood = context.Foods.Single(c => c.Name == "استامبولی");
            var africanoFood = context.Foods.Single(c => c.Name == "آفریکانو");

            var energyNutrient = context.Nutrients.Single(c => c.Name == "انرژی");
            var carbohydrateNutrient = context.Nutrients.Single(c => c.Name == "کربوهیدرات");
            var fiberNutrient = context.Nutrients.Single(c => c.Name == "فیبر");
            var sugarNutrient = context.Nutrients.Single(c => c.Name == "قند");
            var proteinNutrient = context.Nutrients.Single(c => c.Name == "پروتئین");
            var vitaminCNutrient = context.Nutrients.Single(c => c.Name == "ویتامین سی");
            var vitaminANutrient = context.Nutrients.Single(c => c.Name == "ویتامین آ");

            context.FoodNutritionFacts.AddRange(new FoodNutritionFact[]
            {
                new FoodNutritionFact(estamboliFood.Id, energyNutrient.Id,1000),
                new FoodNutritionFact(estamboliFood.Id, carbohydrateNutrient.Id,50),
                new FoodNutritionFact(estamboliFood.Id, fiberNutrient.Id,60),
                new FoodNutritionFact(estamboliFood.Id, sugarNutrient.Id,45),
                new FoodNutritionFact(estamboliFood.Id, proteinNutrient.Id,22),
                new FoodNutritionFact(estamboliFood.Id, vitaminCNutrient.Id,700),

                new FoodNutritionFact(africanoFood.Id, energyNutrient.Id,200),
                new FoodNutritionFact(africanoFood.Id, fiberNutrient.Id,45),
                new FoodNutritionFact(africanoFood.Id, sugarNutrient.Id,200),
                new FoodNutritionFact(africanoFood.Id, proteinNutrient.Id,320),
                new FoodNutritionFact(africanoFood.Id, vitaminCNutrient.Id,21),
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedUsersAsync(ApplicationDbContext context)
        {
            if (context.Users.Any())
                return;

            var pepperIngredient = context.Ingredients.Single(c => c.Name == "فلفل");
            var eggPlantIngredient = context.Ingredients.Single(c => c.Name == "بادمجان");


            context.Users.AddRange(new User[]
            {
                new User
                {
                    FirstName = "محمد",
                    LastName = "بربست"
                },
                new User
                {
                    FirstName = "رضا",
                    LastName = "موسوی"
                }
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedUserAllergicIngredientsAsync(ApplicationDbContext context)
        {
            if (context.UserAllergicIngredients.Any())
                return;

            var barbastUser = context.Users.Single(u => u.FirstName == "محمد" && u.LastName== "بربست");
            var bahremandUser = context.Users.Single(u => u.FirstName == "رضا" && u.LastName== "موسوی");

            var pepperIngredient = context.Ingredients.Single(c => c.Name == "فلفل");
            var eggPlantIngredient = context.Ingredients.Single(c => c.Name == "بادمجان");

            context.UserAllergicIngredients.AddRange(new UserAllergicIngredient[]
            {
                new UserAllergicIngredient(barbastUser.Id,pepperIngredient.Id),
                new UserAllergicIngredient(barbastUser.Id,eggPlantIngredient.Id),

                new UserAllergicIngredient(bahremandUser.Id,pepperIngredient.Id),
            });

            await context.SaveChangesAsync();
        }
    }
}
