using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FoodProject.Data
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
