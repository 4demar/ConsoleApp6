using Domain.Entidades;
using FluentAssertions;
using Xunit;

namespace ConsoleApp6Tests
{
    public class CompararObjetoTest
    {
        [Fact]
        public void CompararProduto_Iguais()
        {
            var produtoEsperado = new Produto { Nome = "Banana", Codigo = 30 };
            var produtoObtido = new Produto { Nome = "Banana", Codigo = 30 };

            produtoObtido.Should().BeEquivalentTo(produtoEsperado);
            
            //não Utilizar para objeto iguais
            //produtoEsperado.Should().Be(produtoObtido);
        }

        [Fact]
        public void CompararlistaDeProduto_Desordenada()
        {
            var listaEsperada = new List<Produto>
            {
                new() { Nome = "Banana", Codigo = 25 },
                new() { Nome = "Pera", Codigo = 35 },
                 new() { Nome = "Goiaba", Codigo = 40 }
            };

            var listaObtida = new List<Produto>
            {
                new() { Nome = "Goiaba", Codigo = 40 },
                new() { Nome = "Banana", Codigo = 25 },
                 new() { Nome = "Pera", Codigo = 35 }
            };

            listaObtida.Should().BeEquivalentTo(listaEsperada);
            
            //Collections differ
            //Assert.Equal(listaEsperada, listaObtida); 
        }

        [Fact]
        public void CompararProduto_IgnorandoValorDiferente()
        {
            var produtoEsperado = new Produto { Nome = "Banana", Valor = 5.99m };
            var produtoObtido = new Produto { Nome = "Banana", Valor = 3.99m };

            produtoObtido.Should().BeEquivalentTo(produtoEsperado, options =>
                options.Excluding(p => p.Valor));
        }

        [Fact]
        public void CompararDatas_DevemSerIguais()
        {
            var baseTime = DateTime.Now;
            var dataEsperada = baseTime.AddMinutes(-10);
            var dataObtida = baseTime.AddMinutes(-10);

            dataObtida.Should().Be(dataEsperada);
            Assert.Equal(dataEsperada, dataObtida);
        }

        [Fact]
        public void CompararDatas_DeveIgnorarSegundos()
        {
            var baseTime = DateTime.Now;
            var dataEsperada = baseTime.AddMinutes(-10);
            var dataObtida = baseTime.AddMinutes(-10).AddMilliseconds(500);// meio segundo depois

            dataObtida.Should().BeCloseTo(dataEsperada, TimeSpan.FromSeconds(1)); // com tolerância de até 1 segundo.
        }
    }
}
