using Domain.Entidades;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IEpcServico
    {
        QueryResultModelPassagem GetPassagensPorFiltro();
        public List<LeituraEpc> IntervaloFalsoPositivo();
        List<Passagem> MontaListaPassagemLeitura(List<LeituraEpc> listaEpcs);
    }
}
