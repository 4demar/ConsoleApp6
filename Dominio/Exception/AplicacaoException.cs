using Domain.Enum;

namespace Domain.Exception
{
    public class AplicacaoException(string mensagem, TipoErroAplicacao tipoErro) : ApplicationException(mensagem)
    {
        public TipoErroAplicacao TipoErro => tipoErro;
        public int StatusCode => MapearStatusCode(tipoErro);

        private static int MapearStatusCode(TipoErroAplicacao tipo) => tipo switch
        {
            TipoErroAplicacao.ParametroInvalido => 400,
            TipoErroAplicacao.NaoEncontrado => 404,
            TipoErroAplicacao.Conflito => 409,
            TipoErroAplicacao.ViolacaoDeRegra => 422,
            TipoErroAplicacao.FalhaAoAdicionar => 500,
            TipoErroAplicacao.FalhaAoAtualizar => 500,
            TipoErroAplicacao.FalhaAoDeletar => 500,
            _ => 500
        };
    }
}
