using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ListaProdutoDto
    {
        public ListaProdutoDto()
        {
            Pedidos = new List<ProdutosDto>();
        }
        public List<ProdutosDto> Pedidos { get; set; }
    }
}
