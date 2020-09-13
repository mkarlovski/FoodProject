using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodProject.Repositories
{
    public class RecipeRepository: IRecipeRepository
    {
        private readonly ApplicationDbContext context;

        public RecipeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Recipe newRecipe)
        {
            context.Recipes.Add(newRecipe);
            context.SaveChanges();
        }

        public List<Recipe> GetAll()
        {
            return context.Recipes.Include(x=>x.User).ToList();
        }

        public Recipe GetById(int id)
        {
            return context.Recipes.Include(x => x.RecipeIngredients).FirstOrDefault(x => x.Id == id);
        }

        public Recipe GetByTitle(string title)
        {
            return context.Recipes.FirstOrDefault(x=>x.Title==title);
        }

        public void Update(Recipe newRecipeFromDb)
        {
            context.Recipes.Update(newRecipeFromDb);
            context.SaveChanges();
        }
    }
}
