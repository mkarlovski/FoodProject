using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Repositories
{
    public class RecipeCommentsRepository : IRecipeCommentsRepository
    {
        private readonly ApplicationDbContext context;

        public RecipeCommentsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(RecipeComment recipeComment)
        {
            context.RecipeComments.Add(recipeComment);
            context.SaveChanges();
        }
    }
}
