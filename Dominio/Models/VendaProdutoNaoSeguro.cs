using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class VendaProdutoNaoSeguro
    {
        // Estado compartilhado errado, não garante em teste paralelo!!
        public static decimal UltimoDesconto { get; private set; }

        public decimal CalcularDesconto(decimal valor, bool clienteVip)
        {
            if (clienteVip)
                UltimoDesconto = 0.1m;
            else
                UltimoDesconto = 0m;

            return valor * (1 - UltimoDesconto);
        }
    }

}
