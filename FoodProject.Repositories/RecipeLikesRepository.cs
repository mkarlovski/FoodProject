using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodProject.Repositories
{
    public class RecipeLikesRepository :IRecipeLikesRepository
    {
        private readonly ApplicationDbContext context;

        public RecipeLikesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(RecipeLike newLike)
        {
            context.RecipeLikes.Add(newLike);
            context.SaveChanges();
        }

        public RecipeLike Get(int recipeId, string userId)
        {
            return context.RecipeLikes.FirstOrDefault(x => x.RecipeId == recipeId && x.UserId == userId);
        }

        public void Remove(RecipeLike like)
        {
            context.RecipeLikes.Remove(like);
            context.SaveChanges();
        }

        public void Update(RecipeLike currentLike)
        {
            context.RecipeLikes.Update(currentLike);
            context.SaveChanges();
        }
    }
}
