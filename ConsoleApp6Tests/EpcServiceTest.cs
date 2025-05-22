using Domain.Entidades;
using Domain.Exception;
using ProjetoBaseApi.Tests.Service.mock;
using Service;
using Xunit;

namespace ServiceTest
{
    public class EpcServiceTest : EpcServiceMock
    {
        [Fact]
        public void MontaListaPassagemLeitura_DeveAgruparQuandoTempoMenorQueIntervalo()
        {
            var baseTime = DateTime.Now;
            var lista = new List<LeituraEpc>
            {
                new() { Hex = "0001", DataRegistro = baseTime },
                new() { Hex = "0002", DataRegistro = baseTime.AddSeconds(-2) }, // mesmo grupo
                new() { Hex = "0001", DataRegistro = baseTime.AddSeconds(-10) } // novo grupo
            };

            var resultado = EpcService.MontaListaPassagemLeitura(lista);

            Assert.Equal(2, resultado.Count); // Espera 2 grupos
            Assert.Equal(2, resultado[1].Itens.Count); // Primeiro grupo com 2
            Assert.Single(resultado[0].Itens); // Segundo grupo com 1
        }

        [Fact]
        public void MontaListaPassagemLeitura_DeveRetornarUmGrupoSeTodosProximos()
        {
            var baseTime = DateTime.Now;
            var lista = new List<LeituraEpc>
            {
                new() { Hex = "0001", DataRegistro = baseTime },
                new() { Hex = "0002", DataRegistro = baseTime.AddSeconds(-1) },
                new() { Hex = "0003", DataRegistro = baseTime.AddSeconds(-2) },
                new() { Hex = "0001", DataRegistro = baseTime.AddSeconds(-5) }, //Item proximo e igual ao primeiro
            };

            var resultado = EpcService.MontaListaPassagemLeitura(lista);

            Assert.Single(resultado); // Apenas um grupo
            Assert.Equal(3, resultado[0].Itens.Count); // Todos os EPCs no mesmo grupo
        }

        [Fact]
        public void MontaListaPassagemLeitura_DeveRetornarGruposSeparadosQuandoIntervaloExcedido()
        {
            var baseTime = DateTime.Now;
            var lista = new List<LeituraEpc>
            {
                new() { DataRegistro = baseTime },
                new() { DataRegistro = baseTime.AddSeconds(-6) },
                new() { DataRegistro = baseTime.AddSeconds(-12) },
            };

            var resultado = EpcService.MontaListaPassagemLeitura(lista);

            // Resultado 3 grupos
            Assert.Equal(3, resultado.Count);
        }

        [Fact]
        public void MontaListaPassagemLeitura_DataDivergente()
        {
            var baseTime = DateTime.Now;
            var lista = new List<LeituraEpc>
            {
                new() { Hex = "000001", DataRegistro = baseTime },
                new() { Hex = "000002", DataRegistro = default }, // mesmo grupo
                new() { Hex = "000003", DataRegistro = baseTime.AddSeconds(10) } // novo grupo
            };

            var resultado = EpcService.MontaListaPassagemLeitura(lista);

            Assert.Equal(3, resultado.Count); // Espera 3 grupos
            Assert.Single(resultado[0].Itens); // Primeiro grupo com 1
        }

        [Fact]
        public void MontaListaPassagemLeitura_ListaEpcVazia()
        {
            List<LeituraEpc> lista = [];

            var ex = Assert.Throws<AplicacaoException>(() => EpcService.MontaListaPassagemLeitura(lista));
            Assert.Equal("Lista de epc vazia", ex.Message);
        }

        [Fact]
        public void MontaListaPassagemLeitura_ListaEpcNull()
        {
            List<LeituraEpc> lista = null;

            var ex = Assert.Throws<AplicacaoException>(() => EpcService.MontaListaPassagemLeitura(lista));
            Assert.Equal("Lista de epc vazia", ex.Message);
        }

        [Fact]
        public void IntervaloFalsoPositivo_RetornoRepositorioNull()
        {
            List<LeituraEpc> listaEsperada = null;
            EpcRepositoryMock.Setup(repo => repo.ListaEpcs())
                .Returns(listaEsperada);

            var ex = Assert.Throws<AplicacaoException>(() => EpcService.IntervaloFalsoPositivo());
            Assert.Equal("Lista de passgaem null", ex.Message);
        }
    }
}