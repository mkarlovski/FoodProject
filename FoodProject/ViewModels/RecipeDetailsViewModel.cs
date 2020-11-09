using FoodProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.ViewModels
{
    public class RecipeDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public byte[] RecipeImage { get; set; }
        public string Description { get; set; }

        public string Preparation { get; set; }
        public int Views { get; set; }
        public int Price { get; set; }

        public int Rating { get; set; }

        public DateTime DateCreated { get; set; }
        public List<string> Ingredients { get; set; }
        public List<RecipeLikeModel> RecipeLikes { get; set; }
        public List<RecipeCommentModel> RecipeComments { get; set; }



    }

}
