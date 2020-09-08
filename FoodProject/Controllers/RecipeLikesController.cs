using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Services.Interfaces;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}