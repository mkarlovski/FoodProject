using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.ViewModels
{
    public class RecipeCommentModel
    {
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
    }
}
