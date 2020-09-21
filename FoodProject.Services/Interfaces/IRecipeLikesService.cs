using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Services.Interfaces
{
    public interface IRecipeLikesService
    {
        void AddLike(int recipeId, string userId);
        void RemoveLike(int recipeId, string userId);
    }
}
