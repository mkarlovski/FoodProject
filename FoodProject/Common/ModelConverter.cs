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
    }
}
