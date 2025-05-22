using Domain.Models;

namespace Domain.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public Produto() { }

        public Produto(int codigo, string nome, decimal valor, DateTime data)
        {
            Codigo = codigo;
            Nome = nome;
            Valor = valor;
            Data = data;
        }

        public bool FiltrarProduto(FiltroData filtro)
        {
            return this.Data >= filtro.DataInicio && this.Data <= filtro.DataFim;
        }
    }
}
