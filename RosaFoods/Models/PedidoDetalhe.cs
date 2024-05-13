using System.ComponentModel.DataAnnotations.Schema;

namespace RosaFoods.Models
{
    public class PedidoDetalhe
    {
        public int PedidoDetalheId { get; set; }
        public int PedidoId { get; set; }
        public int PizzaId { get; set; }
        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
