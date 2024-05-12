using Microsoft.AspNetCore.Mvc;
using RosaFoods.Models;
using RosaFoods.Repositories.Interfaces;
using RosaFoods.ViewModels;

namespace RosaFoods.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IPizzaRepository pizzaRepository, CarrinhoCompra carrinhoCompra)
        {
            _pizzaRepository = pizzaRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        public IActionResult AdicionarItemNoCarrinhoCompra(int pizzaId)
        {
            var pizzaSelecionada = _pizzaRepository.Pizzas
                                    .FirstOrDefault(p=> p.PizzaId == pizzaId); 

            if(pizzaSelecionada != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(pizzaSelecionada);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoverItemDoCarrinhoCompra(int pizzaId)
        {
            var pizzaSelecionada = _pizzaRepository.Pizzas
                                    .FirstOrDefault(p => p.PizzaId == pizzaId);

            if (pizzaSelecionada != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(pizzaSelecionada);
            }
            return RedirectToAction("Index");
        }
    }
}
