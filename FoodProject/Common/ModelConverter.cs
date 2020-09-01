using FoodProject.Data;
using FoodProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Common
{
    public static class ModelConverter
    {
        public static IngredientOverviewModel ToOverview(this Ingredient ingredient)
        {
            return new IngredientOverviewModel 
            {
                Id=ingredient.Id,
                Name=ingredient.Name
            };
        }

        public static Ingredient ToIngredientModel(this IngredientOverviewModel ingredient)
        {
            return new Ingredient {Id=ingredient.Id,Name=ingredient.Name };
        }

        public static Ingredient ToIngredientCreate(this IngredientCreateModel ingredient)
        {
            return new Ingredient { Name = ingredient.Name };
        }

        public static RecipeOverview ToRecipeOverview(this Recipe recipe)
        {
            return new RecipeOverview 
            {
                Id=recipe.Id,
                Title=recipe.Title,
                ImageURL=recipe.ImageURL,
                Description=recipe.Description
            };
        }
    }
}
