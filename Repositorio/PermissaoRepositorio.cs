using Domain.Entidades;
using Domain.Interfaces.Repositorio;

namespace Banco.Repositorio
{
    public class PermissaoRepositorio : IPermissaoRepositorio
    {
        public List<Usuario> ListaPermissaoUsuario()
        {
            return
            [
                new() { Codigo = 1,   Perfil = "Usuario",     IdTela = "AcompanhamentoAntenas" },

                new() { Codigo = 10,  Perfil = "TIII",        IdTela = "Dashboard" },

                new() { Codigo = 20,  Perfil = "Auditoria",   IdTela = "GraficosSuspeitaFurto" },
                new() { Codigo = 20,  Perfil = "Auditoria",   IdTela = "RegrasAntiFurto" },
                new() { Codigo = 20,  Perfil = "Auditoria",   IdTela = "PassagensEpc" },
                new() { Codigo = 20,  Perfil = "Auditoria",   IdTela = "Atendimento" },

                new() { Codigo = 30,  Perfil = "Infra",       IdTela = "ConfiguracaoSuspeitaFurto" },
                new() { Codigo = 30,  Perfil = "Infra",       IdTela = "Antena" },
                new() { Codigo = 30,  Perfil = "Infra",       IdTela = "Monitoramento" },
            ];
        }
    }
}
