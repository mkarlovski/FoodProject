using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FoodProject.Data
{
    public class RecipeLike
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool Status { get; set; }

        public Recipe Recipe { get; set; }
        [Required]
        public int RecipeId { get; set; }

        public IdentityUser User { get; set; }
        [Required]
        public string UserId { get; set; }


    }
}
