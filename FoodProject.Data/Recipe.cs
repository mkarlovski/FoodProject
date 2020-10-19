using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Data
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public byte[] RecipeImage { get; set; }
        public string Description { get; set; }
       
        public string Preparation { get; set; }
        public int Views { get; set; }

        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; }
        public List<RecipeLike> RecipeLikes { get; set; }
        public virtual List<RecipeComment> RecipeComments { get; set; }


    }
}
