using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    public class RecipeLikesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}