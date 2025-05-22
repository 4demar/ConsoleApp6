using Domain.Entidades;

namespace Domain.Models
{
    public class ProdutosDto : Produto
    {
        public bool Selecionado { get; set; }
        public bool PedidoParcial { get; set; }
    }
}
