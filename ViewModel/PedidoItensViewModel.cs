using BurgerPlace2.Models;

namespace BurgerPlace2.ViewModel
{
    public class PedidoItensViewModel
    {
        public Pedido Pedidos { get; set; }
        public IEnumerable<PedidoItem> PedidoItens { get; set; }
    }
}