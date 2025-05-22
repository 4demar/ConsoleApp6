
namespace Domain.Models
{
    public class ListaProdutoDto
    {
        public ListaProdutoDto()
        {
            Pedidos = new List<ProdutosDto>();
        }
        public List<ProdutosDto> Pedidos { get; set; }
    }
}
