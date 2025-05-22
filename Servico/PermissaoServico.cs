using Domain.Interfaces.Repositorio;
using Domain.Interfaces.Service;

namespace Service
{
    public class PermissaoServico(IPermissaoRepositorio permissaoUsuario) : IPermissaoServico
    {

        public List<string> GetPerfilUsuario(int codUsuario)
        {
            var listaPerfil = permissaoUsuario.ListaPermissaoUsuario();
            var resultado = listaPerfil.Where(x => x.Codigo == codUsuario).Select(x => x.IdTela).ToList();

            return resultado;
        }
    }
}
