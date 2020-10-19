using FoodProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Repositories.Interfaces
{
    public interface IRecipeCommentsRepository
    {
        void Add(RecipeComment recipeComment);
    }
}
