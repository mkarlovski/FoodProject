using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.ViewModels
{
    public class IngredientCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}
