using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Common;
using FoodProject.Services.Interfaces;
using FoodProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    //[Authorize(Roles ="Administrator")]
    public class IngredientsController : Controller
    {
        private readonly IIngredientsService ingredientsService;

        public IngredientsController(IIngredientsService ingredientsService)
        {
            this.ingredientsService = ingredientsService;
        }
        public IActionResult Overview()
        {
            var ingredientsDB = ingredientsService.GetAll();
            var ingredientViewModel = ingredientsDB.Select(x => x.ToOverview()).ToList();
            return View(ingredientViewModel);
        }

        public IActionResult Create()
        {
            var ingredient = new IngredientCreateModel();
            return View(ingredient);
        }

        [HttpPost]
        public IActionResult Create(IngredientCreateModel ingredient)
        {
            if (ModelState.IsValid)
            {
                var ingToDB = ingredient.ToIngredientCreate();
                ingredientsService.Create(ingToDB);
                return RedirectToAction("Overview");
            }

            return View(ingredient);
        }

        public IActionResult Edit(int id)
        {
            var ingDB = ingredientsService.GetById(id);
            var ingViewModel = ingDB.ToOverview();
            return View(ingViewModel);
        }

        [HttpPost]
        public IActionResult Edit(IngredientOverviewModel ingredient)
        {
            if (ModelState.IsValid)
            {
                var ingDb = ingredient.ToIngredientModel();
 
                ingredientsService.Update(ingDb);


                return RedirectToAction("Overview");
            }
            return View(ingredient);
            
        }



        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}