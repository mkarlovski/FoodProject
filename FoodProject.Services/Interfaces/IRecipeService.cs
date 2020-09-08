using FoodProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Services.Interfaces
{
    public interface IRecipeService
    {
        List<Recipe> GetAll();
        void Create(Recipe recipeToDb, List<Ingredient> ingredientsDB);
        Recipe GetById(int id);
    }
}
