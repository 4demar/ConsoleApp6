using ConsoleApp6.AppClasseGenericaPaginacao.Model;

namespace ConsoleApp6.AppClasseGenericaPaginacao.Repo
{
    public class ProdutoRepositorio : BaseRepositorio<Produtos>
    {
        public BasePaginacao<Produtos> BuscarPaginacaoProduto(int pagina, int quantidade)
        {
            InserirProdutos();

            return BuscarPaginaDados(pagina, quantidade);
        }

        public void InserirProdutos()
        {
            AddRange(new List<Produtos>
            {
                new Produtos { Id = 1, Name = "Product A", Preco = 10.99m },
                new Produtos { Id = 2, Name = "Product B", Preco = 15.49m },
                new Produtos { Id = 3, Name = "Product C", Preco = 20.00m },
                new Produtos { Id = 4, Name = "Product D", Preco = 5.75m },
                new Produtos { Id = 5, Name = "Product E", Preco = 7.25m },
            });
        }
    }


}
