using RosaFoods.Models;

namespace RosaFoods.ViewModels
{
    public class PedidoPizzaViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
