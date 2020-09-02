using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Common;
using FoodProject.Services.Interfaces;
using FoodProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
//using FoodProject.Models;

namespace FoodProject.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }
        public IActionResult Overview()
        {
            var recipesDb = recipeService.GetAll();
            var recipes = recipesDb.Select(x => x.ToRecipeOverview()).ToList();
            return View(recipes);
        }

        public IActionResult Create()
        {
            var recipe = new RecipeCreateView();
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Create(RecipeCreateView recipe)
        {

            return View();
        }




       




     
    }
}
