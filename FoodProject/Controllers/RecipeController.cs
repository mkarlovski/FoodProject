using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Common;
using FoodProject.Data;
using FoodProject.Services.Interfaces;
using FoodProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
//using FoodProject.Models;

namespace FoodProject.Controllers
{

    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;
        private readonly IIngredientsService ingredientsService;
        private readonly IConfiguration configuration;
        private readonly UserManager<IdentityUser> userManager;

        public RecipeController(IRecipeService recipeService, IIngredientsService ingredientsService, IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            this.recipeService = recipeService;
            this.ingredientsService = ingredientsService;
            this.configuration = configuration;
            this.userManager = userManager;
           
        }
        public async Task<IActionResult>  Overview(string searchRecipe)
        {
            var recipesDb = recipeService.GetByTitleOrIngredient(searchRecipe);
            var recipes = recipesDb.Select(x => x.ToRecipeOverview()).ToList();

            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await userManager.GetUserAsync(User);
                foreach(var entity in recipes)
                {
                    entity.CurrentUserId = currentUser.Id;
                }
                
            }


            return View(recipes);
        }

        public IActionResult CreateTest()
        {
            var recipe = new RecipeCreateView();
            return View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest([FromBody]RecipeCreateView recipe)
        {
            if (ModelState.IsValid)
            {
                var ingredients = ingredientsService.GetAllByName(recipe.Ingredients).Select(x => x.Name).ToList();
                if (recipe.Ingredients.Count != ingredients.Count)
                {
                    var diff = recipe.Ingredients.Except(ingredients).ToList();

                    foreach (var ing in diff)
                    {
                        var newIng = new Ingredient();
                        newIng.Name = ing;

                        ingredientsService.Create(newIng);
                    }
                }
                var ingredientsDB = ingredientsService.GetAllByName(recipe.Ingredients);
                var recipeToDb = recipe.ToRecipeCreate();

                var currentUser = await userManager.GetUserAsync(User);

                recipeService.Create(recipeToDb, ingredientsDB, currentUser.Id);
                
                return Ok();
            }

            return View(recipe);
        }
        [Authorize]
        public async Task<IActionResult>  ManageRecipes()
        {
            var recipes =new List<Recipe>();
            var currentUser = await userManager.GetUserAsync(User);
            if (await userManager.IsInRoleAsync(currentUser, "administrator")){
                recipes = recipeService.GetAll();
            }
            var recipeManageView = recipes.Select(x => x.ToManageOverview()).ToList();
            return View(recipeManageView.OrderByDescending(x => x.DateCreated));
        }

        public IActionResult AddImage(int recipeId)
        {
            var recipe = recipeService.GetById(recipeId);
            var recipeAddImageModel = recipe.ToAddImageView();
            return View(recipeAddImageModel);
        }

        [HttpPost]
        public async Task<IActionResult>  AddImage(RecipeAddImageView recipe, List<IFormFile> recipeImage)
        {
            if (ModelState.IsValid)
            {
                byte[] image = await ByteArrayConverter.ConvertImageToByteArrayAsync(recipeImage);
                
                var recipeDb = recipeService.GetById(recipe.Id);
                recipeDb.RecipeImage = image;

                recipeService.Update(recipeDb);
            }

            return View(recipe);
        }

        public IActionResult Delete(int recipeId)
        {
            var recipe = recipeService.GetById(recipeId);
            recipeService.Delete(recipe);

            return RedirectToAction("ManageRecipes");
        }


       



        public IActionResult Details(int id)
        {
           
            var recipeDb = recipeService.GetRecipeDetails(id);
            var recipeDetailView = recipeDb.ToRecipeDetails();
            var ingredientsNames = recipeDb.RecipeIngredients.Select(x => x.Ingredient.Name).ToList();
            recipeDetailView.Ingredients = ingredientsNames;

            if (recipeDetailView.Views != 0)
            {
                recipeDetailView.Rating = recipeDetailView.RecipeLikes.Count * 100 / recipeDetailView.Views;
            }

            return View(recipeDetailView);
        }

        public IActionResult EditRecipeTest(int recipeId)
        {
            var recipeIngredient = recipeService.GetById(recipeId);

            var ingredientNames = recipeIngredient.RecipeIngredients.Select(x => x.Ingredient.Name).ToList();
            
            var recipeEditView = recipeIngredient.ToRecipeEditTest();
            recipeEditView.Ingredients = ingredientNames;

            return View(recipeEditView);
        }

        [HttpPost]
        public IActionResult EditRecipeTest([FromBody] RecipeEditTEST recipe)
        {
            if (ModelState.IsValid)
            {
                var ingredients = ingredientsService.GetAllByName(recipe.Ingredients).Select(x => x.Name).ToList();
                if (recipe.Ingredients.Count != ingredients.Count)
                {
                    var diff = recipe.Ingredients.Except(ingredients).ToList();
                    foreach (var ing in diff)
                    {
                        var newIng = new Ingredient();
                        newIng.Name = ing;

                        ingredientsService.Create(newIng);
                    }
                }
                var ingredientsDB = ingredientsService.GetAllByName(recipe.Ingredients);
                var recipeDb = recipeService.GetById(recipe.Id);
                recipeDb.Title = recipe.Title;
                recipeDb.Description = recipe.Description;
                recipeDb.Preparation = recipe.Preparation;
                recipeService.EditRecipe(recipeDb, ingredientsDB);

                return Ok();
            }

            return View(recipe);
        }
    }
}
