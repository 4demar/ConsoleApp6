using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RetornoRequisicao<T>
    {
        public T? Retorno { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool HasInconsistencia { get; set; } = false;

        public RetornoRequisicao()
        {
            Status = HttpStatusCode.OK;
        }

        public RetornoRequisicao(T obj) => Retorno = obj;
    }
}
