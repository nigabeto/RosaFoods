using RosaFoods.Models;

namespace RosaFoods.ViewModels
{
    public class PizzaListViewModel
    {
        public IEnumerable<Pizza> Pizzas { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
