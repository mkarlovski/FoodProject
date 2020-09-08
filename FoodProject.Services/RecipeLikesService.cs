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
    }
}
