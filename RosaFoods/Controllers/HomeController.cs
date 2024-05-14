using Microsoft.AspNetCore.Mvc;
using RosaFoods.Models;
using RosaFoods.Repositories.Interfaces;
using RosaFoods.ViewModels;
using System.Diagnostics;

namespace RosaFoods.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPizzaRepository _pizzaRepository;

        public HomeController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IActionResult Index()
        {

            var homeViewModel = new HomeViewModel
            {
                PizzasFavoritas = _pizzaRepository.PizzaFavorita
            };

            return View(homeViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
