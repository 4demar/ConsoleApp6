using Dominio.Modelo;
using Dominio.Models;

namespace Dominio.Interface.Base
{
    public interface IBaseRelatorio<T>
    {
        List<Dictionary<CabecalhoRelatorio, TipoObjetoRelatorio>> PreencherInfoClasse(List<T> listaRelatorio);
    }
}
