using BurgerPlace2.Context;
using BurgerPlace2.Models;
using BurgerPlace2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BurgerPlace2.Repositories
{
    public class ItemRepository: IItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> Itens => _context.Itens.Include(c =>
        c.Categoria);
        public IEnumerable<Item> ItensEmDestaque =>
        _context.Itens.Where(m => m.Destaque).Include(c => c.Categoria);

       


        public Item GetItemById(int itemId)
        {
            return _context.Itens.FirstOrDefault(m => m.ItemId ==

            itemId);
        }
    }
}