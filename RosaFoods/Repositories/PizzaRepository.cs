using Microsoft.EntityFrameworkCore;
using RosaFoods.Context;
using RosaFoods.Models;
using RosaFoods.Repositories.Interfaces;

namespace RosaFoods.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly AppDbContext _context;
        public PizzaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Pizza> Pizzas => _context.Pizzas.Include(c=>c.Categoria);

        public IEnumerable<Pizza> PizzaFavorita => _context.Pizzas.Where(l=>l.IsPizzaFavorita).Include(c=>c.Categoria);

        public Pizza GetPizzaById(int PizzaId)
        {
            return _context.Pizzas.FirstOrDefault(l=>l.PizzaId == PizzaId);
        }
    }
}
