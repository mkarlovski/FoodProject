using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.ViewModels
{
    public class RecipeCreateView
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Preparation { get; set; }
        //public string ImageUrl { get; set; }
        public List<string> Ingredients { get; set; }

    }
}
