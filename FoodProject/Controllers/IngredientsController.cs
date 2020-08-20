using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Common;
using FoodProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    [Authorize(Roles ="Admin")]
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
    }
}