using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Common;
using FoodProject.Data;
using FoodProject.Services.Interfaces;
using FoodProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
//using FoodProject.Models;

namespace FoodProject.Controllers
{
    //[Route("[controller]")]
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;
        private readonly IIngredientsService ingredientsService;

        public RecipeController(IRecipeService recipeService,IIngredientsService ingredientsService)
        {
            this.recipeService = recipeService;
            this.ingredientsService = ingredientsService;
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
        public IActionResult CreateTest([FromBody]RecipeCreateView recipe)
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

                recipeService.Create(recipeToDb, ingredientsDB);

            }

            return View();
        }




       




     
    }
}
