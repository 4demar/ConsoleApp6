using Domain.Models;
using Xunit;

namespace ProjetoBaseApi.Tests.Service
{
    [CollectionDefinition("Recurso Compartilhado", DisableParallelization = false)]
    public class VendaNaoSeguraTest
    {
        private readonly VendaProdutoNaoSeguro _servicoVenda = new ();

        [Fact]
        public void Aplicar_Desconto_Para_Cliente_Vip()
        {
            var clienteVip = true;
            var resultado = _servicoVenda.CalcularDesconto(100m, clienteVip);
            Assert.Equal(90m, resultado);
            Assert.Equal(0.1m, VendaProdutoNaoSeguro.UltimoDesconto);
        }

        [Fact]
        public void Aplicar_Desconto_Para_Cliente_Comum()
        {
            var clienteVip = false;
            var resultado = _servicoVenda.CalcularDesconto(100m, clienteVip);
            Assert.Equal(100m, resultado);
            Assert.Equal(0m, VendaProdutoNaoSeguro.UltimoDesconto);
        }       

        /// <summary>
        /// Resultado favoravel somente executando Todos os testes!!
        /// </summary>
        [Fact]
        public void ObterUltimoDesconto() 
        {
            var resultado = VendaProdutoNaoSeguro.UltimoDesconto;
            Assert.Equal(0.1m, resultado);
        }
    }

}
