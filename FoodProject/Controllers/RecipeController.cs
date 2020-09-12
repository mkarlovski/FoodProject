using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Common;
using FoodProject.Data;
using FoodProject.Services.Interfaces;
using FoodProject.ViewModels;
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

        public RecipeController(IRecipeService recipeService,IIngredientsService ingredientsService,IConfiguration configuration,UserManager<IdentityUser> userManager)
        {
            this.recipeService = recipeService;
            this.ingredientsService = ingredientsService;
            this.configuration = configuration;
            this.userManager = userManager;
        }
        public IActionResult Overview()
        {
            var recipesDb = recipeService.GetAll();
            var recipes = recipesDb.Select(x => x.ToRecipeOverview()).ToList();
            return View(recipes);
        }

        public IActionResult CreateTest()
        {
            var recipe = new RecipeCreateView();
            return View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult>  CreateTest([FromBody]RecipeCreateView recipe)
        {
            if (ModelState.IsValid)
            {
                var ingredients = ingredientsService.GetAllByName(recipe.Ingredients).Select(x=>x.Name).ToList();
                if (recipe.Ingredients.Count != ingredients.Count)
                {
                    var diff = recipe.Ingredients.Except(ingredients).ToList();

                    foreach(var ing in diff)
                    {
                        var newIng = new Ingredient();
                        newIng.Name = ing;

                        ingredientsService.Create(newIng);
                    }                
                }
                var ingredientsDB = ingredientsService.GetAllByName(recipe.Ingredients);
                var recipeToDb = recipe.ToRecipeCreate();
                
                var currentUser = await userManager.GetUserAsync(User);

                recipeService.Create(recipeToDb, ingredientsDB,currentUser.Id);
                return RedirectToAction("Overview","Recipe");
            }

            return View(recipe);
        }

        public IActionResult ManageRecipes()
        {
            var recipes = recipeService.GetAll();
            var recipeManageView = recipes.Select(x => x.ToManageOverview()).OrderByDescending(x=>x.DateCreated).ToList();
            return View(recipeManageView);
        }


        public IActionResult Details(int id)
        {
            var recipeDb = recipeService.GetById(id);
            //da se dovrsi



            return View();
        }




       




     
    }
}
