using DrinkWebApp.Interfaces;
using DrinkWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;

        public HomeController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredDrinks = _drinkRepository.PreferredDrinks
            };
            return View(homeViewModel);
        }

        public IActionResult About()
        {
            TempData["alert"] = "No about info";
            return View();
            
        }
    }
}