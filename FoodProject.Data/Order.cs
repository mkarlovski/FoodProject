using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FoodProject.Data
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string OrderCode { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public decimal FullPrice { get; set; }
        public List<RecipeOrder> RecipeOrders { get; set; }


    }
}
