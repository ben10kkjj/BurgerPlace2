using BurgerPlace2.Models;

namespace BurgerPlace2.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        public IEnumerable<Categoria> Categorias {get;}
    }
}