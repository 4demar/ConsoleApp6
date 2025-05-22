namespace ConsoleApp6.AppClasseGenericaPaginacao.Repo
{
    public class BasePaginacao<T>
    {
        /// <summary>
        /// Lista de dados retornados.
        /// </summary>
        public List<T> Data { get; set; }

        /// <summary>
        /// Total de itens disponíveis.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public BasePaginacao()
        {
            Data = new List<T>();
        }

        /// <summary>
        /// Construtor com parâmetros.
        /// </summary>
        /// <param name="data">Lista de dados.</param>
        /// <param name="totalCount">Total de itens.</param>
        public BasePaginacao(List<T> data, int totalCount)
        {
            Data = new List<T>(data);
            TotalCount = totalCount;
        }

        //public IEnumerable<T> Data { get; set; }
        //public int? TotalCount { get; set; }

        //public QueryResultModelo(IEnumerable<T> data, int? totalCount = 0)
        //{
        //    Data = data;
        //    if (totalCount != 0)
        //        TotalCount = totalCount;
        //}
    }

}
