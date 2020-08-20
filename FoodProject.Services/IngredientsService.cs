using FoodProject.Data;
using FoodProject.Repositories.Interfaces;
using FoodProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Services
{
    public class IngredientsService: IIngredientsService
    {
        private readonly IIngredientsRepository ingredientsRepository;

        public IngredientsService(IIngredientsRepository ingredientsRepository)
        {
            this.ingredientsRepository = ingredientsRepository;
        }

        public List<Ingredient> GetAll()
        {
            return ingredientsRepository.GetAll();
        }
    }
}
