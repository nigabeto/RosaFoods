using RosaFoods.Context;
using RosaFoods.Models;
using RosaFoods.Repositories.Interfaces;

namespace RosaFoods.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
