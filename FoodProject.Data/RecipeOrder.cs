using System;
using System.Collections.Generic;
using System.Text;

namespace FoodProject.Data
{
    public class RecipeOrder
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
