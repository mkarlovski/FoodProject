using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
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
            return context.Recipes.ToList();
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
