using ConsoleApp6.AppClasseGenericaPaginacao.Repo;
using Domain.Entidades;
using Domain.Interfaces.Repositorio;
using Domain.Models;

namespace Banco.Repositorio
{
    public class ProdutoRepositorio : BasePaginacao<Produto>, IProdutoRepositorio
    {
        public List<Produto> MontaListaProdutos()
        {
            var random = new Random();

            var qtdRegistro = 50;
            List<Produto> listaProduto = [];
            var produtosCadastrados = RetornaListaProdutos();
            for (int i = 1; i <= qtdRegistro; i++)
            {
                int index = random.Next(produtosCadastrados.Count);
                var produto = produtosCadastrados[index];

                produto.Data = DateTime.Now.AddHours(-index).AddMinutes(-i);

                var novoProduto = new Produto(produto.Codigo, produto.Nome, produto.Valor, produto.Data);

                listaProduto.Add(novoProduto);
            }

            return listaProduto;
        }

        private static List<Produto> RetornaListaProdutos()
        {
            List<Produto> listaProduto =
            [
                new() { Codigo = 1,  Nome = "Camiseta",  Valor = 10.00M },
                new() { Codigo = 2,  Nome = "TV",  Valor = 20.00M },
                new() { Codigo = 3,  Nome = "Chocolate",  Valor = 30.00M },
                new() { Codigo = 4,  Nome = "Feijão",  Valor = 4.99M },
                new() { Codigo = 5,  Nome = "Biscoito",  Valor = 2.46M},
                new() { Codigo = 6,  Nome = "Arroz",  Valor = 11.50M },
                new() { Codigo = 7,  Nome = "Refrigerante",  Valor = 7.00M },
                new() { Codigo = 8,  Nome = "Banana",  Valor = 9.52M},
                new() { Codigo = 9,  Nome = "Doce de leite",  Valor = 00.00M},
                new() { Codigo = 10, Nome = "Cafe",  Valor = 10.00M }
            ];

            return listaProduto;
        }

        public ResultModelPagination<Produto> BuscarPaginacaoProduto(int pagina, int quantidade)
        {
            InserirProdutos();

            return BuscarPaginaDados(pagina, quantidade);
        }

        public void InserirProdutos()
        {
            AddRange(
            [
                new () { Id = 1, Nome = "Product A", Valor = 10.99m },
                new () { Id = 2, Nome = "Product B", Valor = 15.49m },
                new () { Id = 3, Nome = "Product C", Valor = 20.00m },
                new () { Id = 4, Nome = "Product D", Valor = 5.75m },
                new () { Id = 5, Nome = "Product E", Valor = 7.25m },
            ]);
        }
    }
}
