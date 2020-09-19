using FoodProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Services.Interfaces
{
    public interface IRecipeService
    {
        List<Recipe> GetAll();
        void Create(Recipe recipeToDb, List<Ingredient> ingredientsDB,string userId);
        Recipe GetById(int id);
        void Update(Recipe recipeToDb);
        void Delete(Recipe recipe);
        List<Recipe> GetByTitleOrIngredient(string searchRecipe);
        void EditRecipe(Recipe recipeDb, List<Ingredient> ingredientsDB);
        
    }
}
