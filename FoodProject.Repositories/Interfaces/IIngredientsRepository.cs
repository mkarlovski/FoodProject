using FoodProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Repositories.Interfaces
{
    public interface IIngredientsRepository
    {
        List<Ingredient> GetAll();
        Ingredient GetById(int id);
        void Update(Ingredient ingredient);
        Ingredient GetByName(string name);
        void Create(Ingredient ing);
    }
}
