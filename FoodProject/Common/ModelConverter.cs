using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
using FoodProject.Services;
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
                DateCreated=recipe.DateCreated,
                RecipeLikes= recipe.RecipeLikes.Select(x => ConvertToRecipeLikesViewModel(x)).ToList()
            };
        }
        private static RecipeLikeModel ConvertToRecipeLikesViewModel(RecipeLike x)
        {
            return new RecipeLikeModel
            {
                Id = x.Id,
                DateCreated = x.DateCreated,
                Status = x.Status,
                UserId = x.UserId,
                RecipeId = x.RecipeId
            };
        }

        public static RecipeDetailsViewModel ToRecipeDetails(this Recipe recipe)
        {
            return new RecipeDetailsViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                RecipeImage = recipe.RecipeImage,
                Description = recipe.Description,
                DateCreated = recipe.DateCreated,
                Views=recipe.Views,
                Preparation=recipe.Preparation,               
                RecipeLikes = recipe.RecipeLikes.Select(x=>ConvertToRecipeLikesViewModel(x)).ToList()
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

        public static RecipeEditViewModel ToRecipeEdit(this Recipe recipe)
        {

            return new RecipeEditViewModel 
            {
                Id=recipe.Id,
                Title=recipe.Title,
                Preparation=recipe.Preparation,
                Description=recipe.Description
                
            
            };
        }

        public static Recipe FromRecipeEdit (this RecipeEditViewModel recipe)
        {
            return new Recipe 
            {
                Id=recipe.Id,
                Title=recipe.Title,
                Description=recipe.Description,
                Preparation=recipe.Preparation
                
            };
        }

        public static RecipeIngredientEditViewModel ToIngredientEdit(int recipeId,List<string> ingredients)
        {
            return new RecipeIngredientEditViewModel 
            {
                RecipeId=recipeId,
                Ingredients=ingredients
            };
        }

        public static RecipeEditTEST ToRecipeEditTest(this Recipe recipe)
        {
            return new RecipeEditTEST
            {
                Id = recipe.Id,
                Title =recipe.Title,
                Description = recipe.Description,
                Preparation=recipe.Preparation,
                
            };
        }


    }
}
