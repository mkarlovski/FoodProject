using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.ViewModels
{
    public class RecipeIngredientEditViewModel
    {
        public int RecipeId { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
