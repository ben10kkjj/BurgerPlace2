using BurgerPlace2.Models;

namespace BurgerPlace2.ViewModel
{
    public class ItemListViewModel
    {
        public IEnumerable<Item> Itens{get;set;}
        public string CategoriaAtual{get;set;}
    }
}