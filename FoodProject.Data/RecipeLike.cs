using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Data
{
    public class RecipeLike
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }


        public string UserId { get; set; }
        public IdentityUser User { get; set; }


    }
}
