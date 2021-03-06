﻿using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodProject.Repositories
{
    public class RecipeRepository : IRecipeRepository
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

        public void Delete(Recipe recipe)
        {
            context.Recipes.Remove(recipe);
            context.SaveChanges();
        }

        public List<Recipe> GetAll()
        {
            return context.Recipes.Include(x => x.User).ToList();
        }

        public Recipe GetById(int id)
        {
            return context.Recipes.
                Include(x => x.RecipeIngredients)
                 .ThenInclude(y => y.Ingredient)
                    .Include(q => q.RecipeLikes).ThenInclude(z => z.User)
                        .Include(z=>z.RecipeComments).ThenInclude(z=>z.User)
                            .FirstOrDefault(x => x.Id == id);
        }

        public Recipe GetByTitle(string title)
        {
            return context.Recipes.FirstOrDefault(x => x.Title == title);
        }

        public List<Recipe> GetByTitleOrIngredient(string searchRecipe)
        {
            var recipes = context.Recipes
                .Include(x => x.RecipeIngredients)
                 .ThenInclude(y => y.Ingredient).Include(x=>x.RecipeLikes)
                 .AsQueryable();

            if (!String.IsNullOrEmpty(searchRecipe))
            {
                recipes = recipes.Where(x => x.Title.Contains(searchRecipe) || x.RecipeIngredients.Any(y => y.Ingredient.Name.Contains(searchRecipe)));
            }

            return recipes.ToList();
        }

        public void Update(Recipe newRecipeFromDb)
        {
           
            context.Recipes.Update(newRecipeFromDb);
            context.SaveChanges();
        }
    }
}
