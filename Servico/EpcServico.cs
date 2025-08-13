using Domain.Constantes;
using Domain.Entidades;
using Domain.Enum;
using Domain.Exception;
using Domain.Interfaces.Repositorio;
using Domain.Interfaces.Service;
using Domain.Models;

namespace Service
{
    public class EpcServico(IEpcRepositorio epcRepositorio) : IEpcServico
    {
        public QueryResultModelPassagem GetPassagensPorFiltro()
        {
            var resultado = new QueryResultModelPassagem();
            var ResultadoLeituraEpc = epcRepositorio.ListaEpcs();
            var passagensEpc = MontaListaPassagemLeitura(ResultadoLeituraEpc);

            resultado.Data = passagensEpc;
            resultado.TotalCount = passagensEpc.Count;

            return resultado;
        }

        public List<Passagem> MontaListaPassagemLeitura(List<LeituraEpc> listaEpcs)
        {
            List<Passagem> passagens = [];
            List<LeituraEpc> epcsDaPassagem = [];

            if (listaEpcs == null || listaEpcs.Count == 0) throw new AplicacaoException("Lista de epc vazia", TipoErroAplicacao.ParametroInvalido);
            var listordernada = listaEpcs.OrderBy(x => x.DataRegistro);

            int contadorPassagemEpc = 1;

            DateTime? ultimaLeitura = null;

            foreach (var item in listordernada)
            {
                if (ultimaLeitura == null)
                {
                    ultimaLeitura = item.DataRegistro;
                }

                var dataLimite = ultimaLeitura.Value.AddSeconds(ConstantesApp.IntervaloPassagem);

                if (item.DataRegistro > dataLimite) //Se o intervalo for maior que o configurado, ele salva o que já existe e limpa a lista
                {
                    CriaPassagem(passagens, epcsDaPassagem, contadorPassagemEpc);
                    contadorPassagemEpc += 1;
                    epcsDaPassagem = [];
                }

                epcsDaPassagem.Add(item);
                ultimaLeitura = item.DataRegistro;
            }
            CriaPassagem(passagens, epcsDaPassagem, contadorPassagemEpc);

            return passagens;
        }

        private static void CriaPassagem(List<Passagem> novaListaPassagemEpc, List<LeituraEpc> epcsDaPassagem, int contadorPassagemEpc)
        {
            novaListaPassagemEpc.Add(new Passagem
            {
                Id = contadorPassagemEpc,
                Itens = epcsDaPassagem.DistinctBy(x => x.Hex).ToList(),
            });
        }

        public List<LeituraEpc> IntervaloFalsoPositivo()
        {
            var listaEpc = epcRepositorio.ListaEpcs() ?? throw new AplicacaoException("Lista de passgaem null", TipoErroAplicacao.ParametroInvalido);

            foreach (var itemEpc in listaEpc)
            {
                    var itensRepetidosNoIntervalo = listaEpc
                        .Where(i => i.Hex == itemEpc.Hex && i != itemEpc)
                        .Any(i => Math.Abs((i.DataRegistro - itemEpc.DataRegistro).TotalMinutes) < ConstantesApp.IntervaloMinimoFalsoPositivo);

                    if (itensRepetidosNoIntervalo)
                        itemEpc.Alerta = false;
            }

            return listaEpc;
        }
    }
}
