using Domain.Models;
using Xunit;

namespace ProjetoBaseApi.Tests.Service
{
    public class VendaSeguraTest
    {
        private readonly VendaProdutoSeguro servico = new();

        [Fact]
        public void Aplicar_Desconto_Para_Cliente_Vip()
        {
            var clienteVip = true;
            var resultado = servico.CalcularDesconto(100m, clienteVip);
            Assert.Equal(90m, resultado);
            Assert.Equal(0.1m, servico.ObterUltimoDesconto());
        }

        [Fact]
        public void Aplicar_Desconto_Para_Cliente_Comum()
        {
            var clienteVip = false;
            var resultado = servico.CalcularDesconto(100m, clienteVip);
            Assert.Equal(100m, resultado);
            Assert.Equal(0m, servico.ObterUltimoDesconto());
        }

        [Fact]
        public void ObterUltimoDesconto()
        {
            var resultado = servico.ObterUltimoDesconto();
            Assert.Equal(0m, resultado);
        }
    }

}
