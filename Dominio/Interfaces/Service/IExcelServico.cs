using ClosedXML.Excel;
using Dominio.Enum;
using Dominio.Modelo;
using System.Data;

namespace Dominio.Interface.Service
{
    public interface IExcelServico
    {
        void GerarLivroExcel();

        string GravarArquivoExcel(string nomeRelatorio);

        IXLWorksheet InserirTabela(string nomePaginaRelatorio, DataTable dadosRelatorio);

        void InserirTabelaDinamica(IXLWorksheet dadosPagina, string nomePaginaDinamica);

        void IncluiFiltrosAreaTabelaDinamica(string nomeColunaRelatorio);

        void IncluiColunasAreaTabelaDinamica(string nomeColunaRelatorio);

        void IncluiLinhasAreaTabelaDinamica(string nomeColunaRelatorio);

        void IncluiValoresAreaTabelaDinamica(string nomeColunaRelatorio, string nomeColunaPersonalizada, EnumTipoCalculo tipoCalculo);

    }
}
