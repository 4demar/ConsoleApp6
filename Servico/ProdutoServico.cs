using Domain.Entidades;
using Domain.Enum;
using Domain.Exception;
using Domain.Interfaces.Repositorio;
using Domain.Interfaces.Service;
using Domain.Models;

namespace Service
{
    public class ProdutoServico(IProdutoRepositorio produtosRepositorio) : IProdutoServico
    {
        public bool CadastroVendaProduto(string urlArquivo, EntradaVendaProduto model)
        {
            try
            {
                if (File.Exists(urlArquivo))
                {
                    using StreamWriter sw = File.AppendText(urlArquivo);
                    sw.Write("\nCodigoVenda;IdProduto;NomeProduto");

                    foreach (var item in model.ListaProduto)
                    {
                        var key = model.IdVenda;
                        sw.Write("\n{0};{1};{2}", key, item.Id, item.Nome);
                    }
                    sw.Write("\n");
                    sw.Close();
                }
                else
                {
                    using StreamWriter sw = File.CreateText(urlArquivo);
                    sw.Write("\nCodigoVenda;IdProduto,NomeProduto");

                    foreach (var item in model.ListaProduto)
                    {
                        var key = model.IdVenda;
                        sw.Write("\n{0};{1};{2}", key, item.Id, item.Nome);
                    }
                    sw.Write("\n");
                    sw.Close();
                }
                Console.WriteLine("Venda: " + model.IdVenda + ", salva com sucesso!");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Produto> BuscarProdutosPorData(DateTime dataInicioPeriodo)
        {
            try
            {
                List<Produto> listaProduto = produtosRepositorio.MontaListaProdutos() ?? throw new AplicacaoException("Lista de produtos vazia", TipoErroAplicacao.NaoEncontrado);

                var filtro = new FiltroData
                {
                    DataInicio = dataInicioPeriodo,
                    DataFim = DateTime.Now
                };

                var novaListaPedido = listaProduto.Where(x => x.FiltrarProduto(filtro)).ToList();

                return novaListaPedido;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public bool BuscarPaginacaoProduto()
        {
            // Obtendo a primeira página com 2 produtos por página
            var pagedProducts = produtosRepositorio.BuscarPaginacaoProduto(pagina: 1, quantidade: 2);

            // Exibindo os resultados
            Console.WriteLine($"Total Produtos: {pagedProducts.TotalCount}");
            foreach (var product in pagedProducts.Data)
            {
                Console.WriteLine($"Id: {product.Id}, Nome: {product.Nome}, Valor: {product.Valor:C}");
            }

            return true;
        }
    }
}
