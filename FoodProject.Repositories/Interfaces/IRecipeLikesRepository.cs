using FoodProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Repositories.Interfaces
{
    public interface IRecipeLikesRepository
    {
        RecipeLike Get(int recipeId, string userId);
        void Update(RecipeLike currentLike);
        void Add(RecipeLike newLike);
        void Remove(RecipeLike like);
    }
}
