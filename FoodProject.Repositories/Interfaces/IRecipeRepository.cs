using FoodProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        List<Recipe> GetAll();
        void Create(Recipe newRecipe);
        Recipe GetByTitle(string title);
        void Update(Recipe newRecipeFromDb);
        Recipe GetById(int id);
        void Delete(Recipe recipe);
    }
}
