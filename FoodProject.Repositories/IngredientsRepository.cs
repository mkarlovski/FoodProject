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

        public void Create(Ingredient ing)
        {
            context.Ingredients.Add(ing);
            context.SaveChanges();
        }

        public List<Ingredient> GetAll()
        {
            return context.Ingredients.ToList();
        }

        public Ingredient GetById(int id)
        {
            return context.Ingredients.FirstOrDefault(x => x.Id == id);
        }

        public Ingredient GetByName(string name)
        {
            return context.Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(Ingredient ingDb)
        {         
            context.Ingredients.Remove(ingDb);
            context.SaveChanges();
           
        }

        public void Update(Ingredient ingredient)
        {
            context.Ingredients.Update(ingredient);
            context.SaveChanges();
        }


    }
}
