using RosaFoods.Models;

namespace RosaFoods.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria>Categorias { get; }
    }
}
