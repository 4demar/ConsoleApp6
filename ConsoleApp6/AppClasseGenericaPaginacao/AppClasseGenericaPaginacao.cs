using ConsoleApp6.AppClasseGenericaPaginacao.Repo;

namespace ConsoleApp6.AppClasseGenericaPaginacao
{
    public class AppClasseGenericaPaginacao
    {
        private readonly ProdutoRepositorio produtoRepositorio = new();

        public bool IniciarApp()
        {
            // Obtendo a primeira página com 2 produtos por página
            var pagedProducts = produtoRepositorio.BuscarPaginacaoProduto(pagina: 1, quantidade: 2);

            // Exibindo os resultados
            Console.WriteLine($"Total Products: {pagedProducts.TotalCount}");
            foreach (var product in pagedProducts.Data)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Preco:C}");
            }

            return true;
        }
    }
}
