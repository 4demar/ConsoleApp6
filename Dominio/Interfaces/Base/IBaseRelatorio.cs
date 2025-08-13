using Dominio.Modelo;
using Dominio.Models;
using System.Data;

namespace Dominio.Interface.Base
{
    public interface IBaseRelatorio
    {
        List<Dictionary<CabecalhoRelatorio, TipoObjetoRelatorio>> PreencherInfoClasse<T>(List<T> listaRelatorio);

        DataTable ConverterListParaDataTable<T>(List<T> listaDados);
    }
}
