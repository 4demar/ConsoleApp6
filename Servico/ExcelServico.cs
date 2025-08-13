using ClosedXML.Excel;
using Domain.Constantes;
using Dominio.Enum;
using Dominio.Interface.Service;
using Dominio.Modelo;
using Dominio.Models;
using System.Data;

namespace Servico
{
    public class ExcelServico : IExcelServico
    {
        private IXLPivotTable PivotTable { get; set; }
        private XLWorkbook LivroExcel { get; set; } = new();

        private List<CabecalhoRelatorio> CabecalhoRelatorio { get; set; } = new();

        public void GerarLivroExcel()
        {
            LivroExcel = new XLWorkbook();
        }

        public IXLWorksheet InserirTabela(string nomePaginaRelatorio, DataTable dadosRelatorio)
        {
            if (LivroExcel == null) GerarLivroExcel();
            var nomePagina = nomePaginaRelatorio.Length > 30 ? nomePaginaRelatorio[0..30] : nomePaginaRelatorio;
            var paginaRelatorio = LivroExcel!.Worksheets.Add(nomePagina);

            if (dadosRelatorio.Rows.Count > 0)
            {
                paginaRelatorio.Cell("A1").InsertTable(dadosRelatorio);

                ////---- CABECALHO
                var posicao = 0;
                foreach (DataColumn nomeColuna in dadosRelatorio.Columns)
                {
                    posicao++;
                    var cabecalho = new CabecalhoRelatorio
                    {
                        Nome = nomeColuna.ColumnName,    //pegar o nome
                        PosicaoColuna = posicao     //pegar a posição da coluna

                    };

                    CabecalhoRelatorio.Add(cabecalho);
                }
            }

            //Ajuste automatico de coluna
            paginaRelatorio.Columns().AdjustToContents();

            return paginaRelatorio;
        }

        public void InserirTabelaDinamica(IXLWorksheet dadosPagina, string nomePaginaDinamica)
        {
            if (dadosPagina.RowsUsed().Any() && !string.IsNullOrEmpty(nomePaginaDinamica))
            {
                var nomePagina = nomePaginaDinamica.Length > 30 ? nomePaginaDinamica[0..30] : nomePaginaDinamica;
                var tabelaDinamica = LivroExcel.Worksheets.Add(nomePagina);

                var range = dadosPagina.RangeUsed();

                PivotTable = tabelaDinamica.PivotTables.Add(nomePagina, tabelaDinamica.Cell(1, 1), range);

                PivotTable.SetShowGrandTotalsColumns(true);
            }
        }

        public void IncluiFiltrosAreaTabelaDinamica(string nomeColunaRelatorio)
        {
            int numeroColuna = RetornaNumeroColunaPorNome(nomeColunaRelatorio);
            var valorExistente = PivotTable.ReportFilters.Count(x => x.CustomName == nomeColunaRelatorio);
            if (numeroColuna >= 0 && valorExistente == 0)
                PivotTable.ReportFilters.Add(nomeColunaRelatorio);
        }

        public void IncluiColunasAreaTabelaDinamica(string nomeColunaRelatorio)
        {
            int numeroColuna = RetornaNumeroColunaPorNome(nomeColunaRelatorio);
            var valorExistente = PivotTable.ColumnLabels.Count(x => x.CustomName == nomeColunaRelatorio);
            if (numeroColuna >= 0 && valorExistente == 0)
                PivotTable.ColumnLabels.Add(nomeColunaRelatorio);
        }

        public void IncluiLinhasAreaTabelaDinamica(string nomeColunaRelatorio)
        {
            int numeroColuna = RetornaNumeroColunaPorNome(nomeColunaRelatorio);
            var valorExistente = PivotTable.RowLabels.Count(x => x.CustomName == nomeColunaRelatorio);
            if (numeroColuna >= 0 && valorExistente == 0)
                PivotTable.RowLabels.Add(nomeColunaRelatorio);
        }

        public void IncluiValoresAreaTabelaDinamica(string nomeColunaRelatorio, string nomeColunaPersonalizada, EnumTipoCalculo tipoCalculo)
        {
            int numeroColuna = RetornaNumeroColunaPorNome(nomeColunaRelatorio);
            var valorExistente = PivotTable.Values.Count(x => x.CustomName == nomeColunaPersonalizada);

            if (numeroColuna >= 0 && valorExistente == 0)
                PivotTable.Values.Add(nomeColunaRelatorio).SetSummaryFormula(NumeroParaTipoCalculo((int)tipoCalculo)).CustomName = nomeColunaPersonalizada;

        }

        public string GravarArquivoExcel(string nomeRelatorio)
        {
            var pathArquivoRelatorio = $"{ConstantesApp.DiretorioBaseRelatorio}\\{nomeRelatorio}.xlsx";

            LivroExcel.SaveAs(pathArquivoRelatorio);

            return pathArquivoRelatorio;
        }

        #region Metodos Privados
        private int RetornaNumeroColunaPorNome(string nomeColunaRelatorio)
        {
            return CabecalhoRelatorio.FirstOrDefault(x => x.Nome == nomeColunaRelatorio, new CabecalhoRelatorio()).PosicaoColuna;
        }

        private static XLPivotSummary NumeroParaTipoCalculo(int tipoCalculo)
        {
            return tipoCalculo switch
            {
                1 => XLPivotSummary.Count,
                2 => XLPivotSummary.CountNumbers,
                3 => XLPivotSummary.Minimum,
                4 => XLPivotSummary.Maximum,
                5 => XLPivotSummary.Average,
                _ => XLPivotSummary.Sum,
            };
        }

        #endregion
    }
}
