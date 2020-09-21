using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
using FoodProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Services
{
    public class RecipeLikesService : IRecipeLikesService
    {
        private readonly IRecipeLikesRepository recipeLikesRepository;

        public RecipeLikesService(IRecipeLikesRepository recipeLikesRepository)
        {
            this.recipeLikesRepository = recipeLikesRepository;
        }

        public void AddLike(int recipeId, string userId)
        {
            var currentLike = recipeLikesRepository.Get(recipeId, userId);

            if (currentLike != null)
            {
                currentLike.Status = true;
                recipeLikesRepository.Update(currentLike);
            }
            else
            {
                var newLike = new RecipeLike
                {
                    UserId = userId,
                    RecipeId = recipeId,
                    DateCreated = DateTime.Now,
                    Status = true
                };

                recipeLikesRepository.Add(newLike);
            }
        }

        public void RemoveLike(int recipeId, string userId)
        {
            var like = recipeLikesRepository.Get(recipeId, userId);
            recipeLikesRepository.Remove(like);
        }
    }
}
