using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Services.Interfaces;
using FoodProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    public class RecipeLikesController : Controller
    {
        private readonly IRecipeLikesService recipeLikesService;

        public RecipeLikesController(IRecipeLikesService recipeLikesService)
        {
            this.recipeLikesService = recipeLikesService;
        }


        [HttpPost]
        public IActionResult Like([FromBody] RecipeLikeRequestModel request)
        {
            //var userId = User.FindFirst("Id").Value;
            //recipeLikesService.AddLike(request.RecipeId, userId);
            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveLike([FromBody] RecipeLikeRequestModel request)
        {
            var userId = User.FindFirst("Id").Value;
            recipeLikesService.RemoveLike(request.RecipeId, userId);
            return Ok();
        }
    }
}