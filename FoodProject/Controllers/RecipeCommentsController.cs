using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    public class RecipeCommentsController : Controller
    {
        private readonly IRecipeCommentsService recipeComments;
        private readonly UserManager<IdentityUser> userManager;

        public RecipeCommentsController(IRecipeCommentsService recipeCommentsService, UserManager<IdentityUser> userManager)
        {
            this.recipeComments = recipeCommentsService;
            this.userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Add(string comment, int recipeId)
        {
            if (!String.IsNullOrEmpty(comment))
            {
                //var userId = Convert.ToInt32(User.FindFirst("Id").Value);

                var currentUser = await userManager.GetUserAsync(User);
                recipeComments.Add(comment, recipeId, currentUser.Id);
            }
            return RedirectToAction("Details", "Recipe", new { id = recipeId });
        }
    }
}