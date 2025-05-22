using Domain.Entidades;
using Domain.Interfaces.Repositorio;
using Domain.Models;
using Moq;
using Service;
using Xunit;

namespace ProjetoBaseApi.Tests.Service
{
    public class ProdutoServiceTest
    {
        private readonly Mock<IProdutoRepositorio> _produtoRepositorioMock;
        private readonly ProdutoServico _produtoService;

        public ProdutoServiceTest()
        {
            _produtoRepositorioMock = new Mock<IProdutoRepositorio>();

            // Instancia a classe real com o mock no construtor
            _produtoService = new ProdutoServico(_produtoRepositorioMock.Object);
        }

        [Fact]
        public void CadastroVendaProduto()
        {
            string arquivoVendaProdutos = "C:\\Users\\121097\\Desktop\\VendaProdutos.csv";

            var listaDeProduto = new List<Produto>
            {
                new(){Id = 1, Codigo = 1, Data = DateTime.Now.AddMinutes(-1), Nome = "Café", Valor = 15.90M},
                new(){Id = 1, Codigo = 1, Data = DateTime.Now.AddMinutes(-2), Nome = "Pão", Valor = 6.50M},
                new(){Id = 1, Codigo = 1, Data = DateTime.Now.AddMinutes(-3), Nome = "Leite", Valor = 4.90M}
            };

            var produtoCadastro = new EntradaVendaProduto
            {
                IdVenda = 1,
                ListaProduto = listaDeProduto
            };

            Assert.True(_produtoService.CadastroVendaProduto(arquivoVendaProdutos, produtoCadastro));
        }

        [Fact]
        public void BuscarProdutoPorData()
        {
            // Arrange
            var data = new DateTime(2024, 05, 10);

            List<Produto> listaProduto =
            [
                new() { Codigo = 1,  Nome = "Camiseta",  Valor = 10.00M, Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() { Codigo = 2,  Nome = "TV",  Valor = 20.00M , Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() { Codigo = 3,  Nome = "Chocolate",  Valor = 30.00M , Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() { Codigo = 4,  Nome = "Feijão",  Valor = 4.99M , Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() { Codigo = 5,  Nome = "Biscoito",  Valor = 2.46M, Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() { Codigo = 6,  Nome = "Arroz",  Valor = 11.50M , Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() { Codigo = 7,  Nome = "Refrigerante",  Valor = 7.00M , Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() { Codigo = 8,  Nome = "Banana",  Valor = 9.52M, Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() { Codigo = 9,  Nome = "Doce de leite",  Valor = 00.00M, Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() { Codigo = 10, Nome = "Cafe",  Valor = 10.00M, Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
            ];

            _produtoRepositorioMock.Setup(r => r.MontaListaProdutos()).Returns(listaProduto);

            // Act
            var resultado = _produtoService.BuscarProdutosPorData(data);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(10, resultado.Count);
        }

        [Fact]
        public void BuscarProdutoPorData_VerificaItensEmLista()
        {
            // Arrange
            var data = new DateTime(2024, 05, 10);

            List<Produto> listaProduto =
            [
                new() {Id = 1, Codigo = 1,  Nome = "Camiseta",  Valor = 10.00M, Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() {Id = 2,  Codigo = 2,  Nome = "TV",  Valor = 20.00M , Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() {Id = 3,  Codigo = 3,  Nome = "Chocolate",  Valor = 30.00M , Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() {Id = 4,  Codigo = 4,  Nome = "Feijão",  Valor = 4.99M , Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() {Id = 5,  Codigo = 5,  Nome = "Biscoito",  Valor = 2.46M, Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() {Id = 6,  Codigo = 6,  Nome = "Arroz",  Valor = 11.50M , Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() {Id = 7,  Codigo = 7,  Nome = "Refrigerante",  Valor = 7.00M , Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() {Id = 8,  Codigo = 8,  Nome = "Banana",  Valor = 9.52M, Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() {Id = 9,  Codigo = 9,  Nome = "Doce de leite",  Valor = 7.00M, Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
                new() {Id = 10,  Codigo = 10, Nome = "Cafe",  Valor = 10.00M, Data = DateTime.Now.AddHours(-1).AddMinutes(-1) },
            ];

            //aqui faz o mock do renorno da consulta em repositorio abaixo!!
            _produtoRepositorioMock.Setup(r => r.MontaListaProdutos()).Returns(listaProduto);

            var listaProdutos = _produtoService.BuscarProdutosPorData(data);

            Assert.All(listaProdutos, item =>
            {
                Assert.True(item.Id > 0);
                Assert.True(item.Valor > 0);
                Assert.True(item.Codigo > 0);
                Assert.NotEqual(default, item.Data);
                Assert.False(string.IsNullOrEmpty(item.Nome));
            });

        }

    }
}
