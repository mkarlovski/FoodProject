using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FoodProject.Data
{
    public class RecipeComment
    {
        public int Id { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
