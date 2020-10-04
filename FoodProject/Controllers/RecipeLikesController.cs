using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Services.Interfaces;
using FoodProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    public class RecipeLikesController : Controller
    {
        private readonly IRecipeLikesService recipeLikesService;
        private readonly UserManager<IdentityUser> userManager;

        public RecipeLikesController(IRecipeLikesService recipeLikesService, UserManager<IdentityUser> userManager)
        {
            this.recipeLikesService = recipeLikesService;
            this.userManager = userManager;
        }


        [HttpPost]
        public async Task<IActionResult> Like([FromBody] RecipeLikeRequestModel request)
        {
            var user = await userManager.GetUserAsync(User);          
            recipeLikesService.AddLike(request.RecipeId, user.Id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveLike([FromBody] RecipeLikeRequestModel request)
        {
            var user = await userManager.GetUserAsync(User);          
            recipeLikesService.RemoveLike(request.RecipeId, user.Id);
            return Ok();
        }
    }
}