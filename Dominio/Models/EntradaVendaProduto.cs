using Domain.Entidades;

namespace Domain.Models
{
    public class EntradaVendaProduto
    {
        public int IdVenda { get; set; }
        public List<Produto> ListaProduto { get; set; } = new List<Produto>();
    }
}
