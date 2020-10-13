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
    }
}
