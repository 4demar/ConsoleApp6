using Service;
using Xunit;

namespace ProjetoBaseApi.Tests.Service
{
    public class CalculadoraTest
    {
        [Fact]
        public void Somar()
        {
            Assert.Equal(20, Calculadora.Somar(10, 10));
        }

        [Fact]
        public void Subtrair()
        {
            Assert.Equal(0, Calculadora.Subtrair(10, 10));
        }

        [Fact]
        public void Multiplicar()
        {
            Assert.Equal(100, Calculadora.Multiplicar(10, 10));
        }

        [Fact]
        public void Multiplicar_PorNumeroNegativo()
        {
            Assert.Equal(-1, Calculadora.Multiplicar(-1, 1));
        }

        [Fact]
        public void Dividir()
        {
            Assert.Equal(1, Calculadora.Dividir(10, 10));
        }

        [Fact]
        public void Dividir_PorZero()
        {
            var ex = Assert.Throws<ArgumentException>(() => Calculadora.Dividir(10, 0));
            Assert.Equal("Denominador não pode ser zero.", ex.Message);
        }

        [Fact]
        public void Dividir_NumerosQuebrados()
        {
            Assert.Equal(1.625, Calculadora.Dividir(6.5, 4));
        }
    }
}
