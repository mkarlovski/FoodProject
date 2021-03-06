﻿using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
using FoodProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace FoodProject.Services
{
    public class RecipeService: IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly IConfiguration configuration;

        public RecipeService(IRecipeRepository recipeRepository,IConfiguration configuration)
        {
            this.recipeRepository = recipeRepository;
            this.configuration = configuration;
        }

        public void Create(Recipe recipeToDb, List<Ingredient> ingredientsDB,string userId)
        {
            //da se dostavi proverka dali postoi vo baza

            var newRecipe = new Recipe()
            {
                Title = recipeToDb.Title,
                Description = recipeToDb.Description,
                Preparation = recipeToDb.Preparation,
                DateCreated = DateTime.Now,
                Price=recipeToDb.Price,
                UserId = userId
            };
            
            recipeRepository.Create(newRecipe);
            var newRecipeFromDb = recipeRepository.GetByTitle(recipeToDb.Title);

            var recipeIngredients = new List<RecipeIngredient>();
            foreach(var ingredient in ingredientsDB)
            {
                var ing = new RecipeIngredient()
                {
                    RecipeId=newRecipeFromDb.Id,
                    IngredientId = ingredient.Id
                };
                recipeIngredients.Add(ing);
            }
            newRecipeFromDb.RecipeIngredients = recipeIngredients;
            recipeRepository.Update(newRecipeFromDb);

        }

        public void Delete(Recipe recipe)
        {
            recipeRepository.Delete(recipe);
        }

        public void EditRecipe(Recipe recipeDb, List<Ingredient> ingredientsDB)
        {

            var recipeIngredients = new List<RecipeIngredient>();
            foreach (var ingredient in ingredientsDB)
            {
                var ing = new RecipeIngredient()
                {
                    RecipeId = recipeDb.Id,
                    IngredientId = ingredient.Id
                };
                recipeIngredients.Add(ing);
            }
            recipeDb.RecipeIngredients = recipeIngredients;
            recipeRepository.Update(recipeDb);
        }

        public List<Recipe> GetAll()
        {
            return recipeRepository.GetAll();
        }

        public Recipe GetById(int id)
        {
            return recipeRepository.GetById(id);
        }

        public List<Recipe> GetByTitleOrIngredient(string searchRecipe)
        {
            return recipeRepository.GetByTitleOrIngredient(searchRecipe);
        }

        public Recipe GetRecipeDetails(int id)
        {
            var recipe = recipeRepository.GetById(id);
            recipe.Views += 1;
            recipeRepository.Update(recipe);
            return recipe;
            
        }

        public void Update(Recipe recipeToDb)
        {
            recipeRepository.Update(recipeToDb);
        }
    }
}
