using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProdutosDto : Produto
    {
        public bool Selecionado { get; set; }
        public bool PedidoParcial { get; set; }
    }
}
