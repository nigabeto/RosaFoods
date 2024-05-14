using Microsoft.AspNetCore.Mvc;
using RosaFoods.Models;
using RosaFoods.Repositories.Interfaces;
using RosaFoods.ViewModels;

namespace RosaFoods.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Pizza> pizzas;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                pizzas = _pizzaRepository.Pizzas.OrderBy(p => p.PizzaId);
                categoriaAtual = "Todas as pizzas";
            }
            else
            {
                //if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    pizzas = _pizzaRepository.Pizzas
                //        .Where(p => p.Categoria.CategoriaNome.Equals("Normal"))
                //        .OrderBy(p => p.Nome);
                //}
                //else
                //{
                //    pizzas = _pizzaRepository.Pizzas
                //        .Where(p => p.Categoria.CategoriaNome.Equals("Doce"))
                //        .OrderBy(p => p.Nome);
                //}
                pizzas = _pizzaRepository.Pizzas
                          .Where(p => p.Categoria.CategoriaNome.Equals(categoria))
                          .OrderBy(c => c.Nome);
                categoriaAtual = categoria;
            }

            var pizzasListViewModel = new PizzaListViewModel
            {
                Pizzas = pizzas,
                CategoriaAtual = categoriaAtual
            };

            return View(pizzasListViewModel);
        }

        public IActionResult Details(int pizzaId)
        {
            var pizza = _pizzaRepository.Pizzas.FirstOrDefault(p => p.PizzaId == pizzaId);
            return View(pizza);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Pizza> pizzas;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                pizzas = _pizzaRepository.Pizzas.OrderBy(p => p.PizzaId);
                categoriaAtual = "Todas as pizzas";
            }
            else
            {
                pizzas = _pizzaRepository.Pizzas
                          .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (pizzas.Any())
                    categoriaAtual = "Pizzas";
                else
                    categoriaAtual = "Nenhum produto foi encontrado";
            }

            return View("~/Views/Pizza/List.cshtml", new PizzaListViewModel
            {
                Pizzas = pizzas,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}