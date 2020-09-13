﻿using FoodProject.Data;
using FoodProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Common
{
    public static class ModelConverter
    {
        public static IngredientOverviewModel ToOverview(this Ingredient ingredient)
        {
            return new IngredientOverviewModel 
            {
                Id=ingredient.Id,
                Name=ingredient.Name
            };
        }

        public static Ingredient ToIngredientModel(this IngredientOverviewModel ingredient)
        {
            return new Ingredient 
            {
                Id=ingredient.Id,
                Name=ingredient.Name 
            };
        }

        public static Ingredient ToIngredientCreate(this IngredientCreateModel ingredient)
        {
            return new Ingredient 
            {
                Name = ingredient.Name
            };
        }

        public static RecipeOverview ToRecipeOverview(this Recipe recipe)
        {
            return new RecipeOverview 
            {
                Id=recipe.Id,
                Title=recipe.Title,
                RecipeImg = recipe.RecipeImage,
                Description =recipe.Description,
                DateCreated=recipe.DateCreated
            };
        }

        public static Recipe ToRecipeCreate(this RecipeCreateView recipe)
        {
            return new Recipe 
            {
                Title=recipe.Title,
                Description=recipe.Description,
                Preparation=recipe.Preparation,
                
            };
        }

        public static RecipeManageOverview ToManageOverview(this Recipe recipe)
        {
            return new RecipeManageOverview
            {
                Id=recipe.Id,
                Title=recipe.Title,
                DateCreated=recipe.DateCreated,
                CreatedBy = recipe.User.UserName
            };
        }

        public static RecipeAddImageView ToAddImageView(this Recipe recipe)
        {
            return new RecipeAddImageView 
            {
                Id=recipe.Id,
                RecipeImage=recipe.RecipeImage
            };
        }

        public static Recipe FromRecipeAddImage(this RecipeAddImageView recipe)
        {
            return new Recipe 
            {
            Id=recipe.Id,
            RecipeImage=recipe.RecipeImage
            };
        }




    }
}
