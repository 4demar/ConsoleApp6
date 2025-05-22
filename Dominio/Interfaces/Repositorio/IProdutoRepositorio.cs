using Domain.Entidades;
using Domain.Models;

namespace Domain.Interfaces.Repositorio
{
    public interface IProdutoRepositorio
    {
        void InserirProdutos();
        List<Produto> MontaListaProdutos();
        ResultModelPagination<Produto> BuscarPaginacaoProduto(int pagina, int quantidade);
    }
}
