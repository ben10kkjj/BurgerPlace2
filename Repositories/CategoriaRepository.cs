using BurgerPlace2.Context;
using BurgerPlace2.Models;
using BurgerPlace2.Repositories.Interfaces;


namespace BurgerPlace2.Repositories
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