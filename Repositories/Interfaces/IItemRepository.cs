using BurgerPlace2.Models;

namespace BurgerPlace2.Repositories.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> Itens{get;}
        IEnumerable<Item> ItensEmDestaque{get;}
        Item GetItemById(int itemId);
    }
}