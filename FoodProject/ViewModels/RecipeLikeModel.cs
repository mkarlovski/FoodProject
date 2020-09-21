using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.ViewModels
{
    public class RecipeLikeModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
