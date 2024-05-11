using Microsoft.AspNetCore.Mvc;
using RosaFoods.Repositories.Interfaces;

namespace RosaFoods.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IActionResult List()
        {
            //ViewData["Titulo"] = "Todas as pizzas";
            //ViewData["Data"] = DateTime.Now;

            var pizzas = _pizzaRepository.Pizzas;
            //var totalPizzas = pizzas.Count();

            //ViewBag.Total = "Total de pizzas: ";
            //ViewBag.TotalPizzas = totalPizzas;

            return View(pizzas);
        }
    }
}
