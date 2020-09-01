using FoodProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        List<Recipe> GetAll();
    }
}
