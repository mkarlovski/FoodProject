using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.ViewModels
{
    public class RecipeOverview
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        
        //public string ImageURL { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
