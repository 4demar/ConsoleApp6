using System.Net;

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
