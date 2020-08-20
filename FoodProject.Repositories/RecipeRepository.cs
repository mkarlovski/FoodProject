using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
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
    }
}
