using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Data
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        //public List<string> Ingredients { get; set; }
        public string Preparation { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }


    }
}
