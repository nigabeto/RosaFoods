using RosaFoods.Models;

namespace RosaFoods.Repositories.Interfaces
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> Pizzas { get; }
        IEnumerable<Pizza> PizzaFavorita { get; }
        Pizza GetPizzaById(int PizzaId);
    }
}
