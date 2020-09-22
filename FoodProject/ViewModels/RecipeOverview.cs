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
        [Required]
        public byte[] RecipeImg { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }


        public List<RecipeLikeModel> RecipeLikes { get; set; }
        public RecipeLikeStatus LikeStatus { get; set; }
        public string CurrentUserId { get; set; }
    }
}
