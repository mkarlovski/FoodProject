using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
using FoodProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Services
{
    public class RecipeCommentsService: IRecipeCommentsService
    {
        private readonly IRecipeCommentsRepository recipeCommentsRepository;

        public RecipeCommentsService(IRecipeCommentsRepository recipeCommentsRepository)
        {
            this.recipeCommentsRepository = recipeCommentsRepository;
        }

        public void Add(string comment, int recipeId, string userId)
        {
            var recipeComment = new RecipeComment();
            recipeComment.Comment = comment;
            recipeComment.RecipeId = recipeId;
            recipeComment.UserId = userId;
            recipeComment.DateCreated = DateTime.Now;

            recipeCommentsRepository.Add(recipeComment);
        }
    }
}
