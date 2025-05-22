using Domain.Entidades;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IProdutoServico
    {
        bool BuscarPaginacaoProduto();
        bool CadastroVendaProduto(string urlArquivo, EntradaVendaProduto model);
        List<Produto> BuscarProdutosPorData(DateTime dataInicioPeriodo);
    }
}