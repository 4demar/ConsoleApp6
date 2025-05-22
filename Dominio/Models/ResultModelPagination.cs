

namespace Domain.Models
{
    public class ResultModelPagination<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int? TotalCount { get; set; }

        public ResultModelPagination(IEnumerable<T> data, int? totalCount = 0)
        {
            Data = data;
            if (totalCount != 0)
                TotalCount = totalCount;
        }
    }

    public class QueryResultModelPassagem
    {
        public List<Passagem>? Data { get; set; }
        public int? TotalCount { get; set; }
        public QueryResultModelPassagem() { }
        public QueryResultModelPassagem(List<Passagem> data, int? totalCount = 0)
        {
            Data = data;
            if (totalCount != 0)
                TotalCount = totalCount;
        }
    }
}