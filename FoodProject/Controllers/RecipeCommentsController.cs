﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    public class RecipeCommentsController : Controller
    {
        private readonly IRecipeCommentsService recipeComments;

        public RecipeCommentsController(IRecipeCommentsService recipeCommentsService)
        {
            this.recipeComments = recipeCommentsService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}