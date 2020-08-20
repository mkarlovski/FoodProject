using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodProject.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly ApplicationDbContext context;

        public IngredientsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Ingredient> GetAll()
        {
            return context.Ingredients.ToList();
        }
    }
}
