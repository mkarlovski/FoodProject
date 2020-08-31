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

        public void Create(Ingredient ingredient)
        {
            var exists = ingredientsRepository.GetByName(ingredient.Name);
            if (exists == null)
            {
                var ing = new Ingredient();
                ing.Name = ingredient.Name;

                ingredientsRepository.Create(ing);
            }
        }

        public List<Ingredient> GetAll()
        {
            return ingredientsRepository.GetAll();
        }

        public Ingredient GetById(int id)
        {
            return ingredientsRepository.GetById(id);
        }

        public void Update(Ingredient ingDb)
        {

            var ingredient = ingredientsRepository.GetById(ingDb.Id);
            if (ingredient != null) 
            {
                ingredient.Name = ingDb.Name;
            }
            ingredientsRepository.Update(ingredient);
        }
    }
}
