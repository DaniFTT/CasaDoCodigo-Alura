using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class ItemPedido : BaseModel
    {
        [Required]
        public Pedido Pedido { get; private set; }
        [Required]
        public Produto Produto { get; private set; }
        [Required]
        public int Quantidade { get; private set; }
        [Required]
        public decimal PrecoUnitario { get; private set; }

        public ItemPedido() {   }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public void IncrementaQuantidade()
        {
            this.Quantidade++;
        }
    }
}
