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

            if(string.IsNullOrEmpty(categoria))
            {
                pizzas = _pizzaRepository.Pizzas.OrderBy(p => p.PizzaId);
                categoriaAtual = "Todas as pizzas";
            }
            else
            {
                if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    pizzas = _pizzaRepository.Pizzas
                        .Where(p => p.Categoria.CategoriaNome.Equals("Normal"))
                        .OrderBy(p => p.Nome);
                }
                else
                {
                    pizzas = _pizzaRepository.Pizzas
                        .Where(p => p.Categoria.CategoriaNome.Equals("Doce"))
                        .OrderBy(p => p.Nome);
                }
                categoriaAtual = categoria;
            }

            var pizzasListViewModel = new PizzaListViewModel
            {
                Pizzas = pizzas,
                CategoriaAtual = categoriaAtual
            };

            return View(pizzasListViewModel);
        }


    }
}