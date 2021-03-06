﻿using FoodProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Services.Interfaces
{
    public interface IIngredientsService
    {
        List<Ingredient> GetAll();
        Ingredient GetById(int id);
        void Update(Ingredient ingDb);
        void Create(Ingredient ingredient);
        void Remove(Ingredient ingDb);
        List<Ingredient> GetAllByName(List<string> ingredients);
        //List<string> GetIngredientsForRecipe(int recipeId);
    }
}
