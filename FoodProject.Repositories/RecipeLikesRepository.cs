using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Repositories
{
    public class RecipeLikesRepository :IRecipeLikesRepository
    {
        private readonly ApplicationDbContext context;

        public RecipeLikesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
