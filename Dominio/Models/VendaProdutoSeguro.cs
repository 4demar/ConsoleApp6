
namespace Domain.Models
{
    public class VendaProdutoSeguro
    {
        private decimal _ultimoDesconto;

        public decimal CalcularDesconto(decimal valor, bool clienteVip)
        {
            if (clienteVip)
                _ultimoDesconto = 0.1m;
            else
                _ultimoDesconto = 0m;

            return valor * (1 - _ultimoDesconto);
        }

        public decimal ObterUltimoDesconto() => _ultimoDesconto;
    }

}
