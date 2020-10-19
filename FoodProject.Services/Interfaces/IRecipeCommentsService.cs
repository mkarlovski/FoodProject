using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Services.Interfaces
{
    public interface IRecipeCommentsService
    {
        void Add(string comment, int recipeId, string userId);
    }
}
