namespace ConsoleApp6.AppClasseGenericaPaginacao.Repo
{
    public class BaseRepositorio<T> where T : class, new()
    {
        private readonly List<T> _data;

        public BaseRepositorio()
        {
            _data = new List<T>();
        }

        // Método para obter dados paginados
        public BasePaginacao<T> BuscarPaginaDados(int page, int pageSize)
        {
            var total = _data.Count;
            var data = _data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return new BasePaginacao<T>(data, total);
        }

        // Método para adicionar um item
        public void Add(T item)
        {
            _data.Add(item);
        }

        // Método para adicionar uma lista de itens
        public void AddRange(IEnumerable<T> items)
        {
            _data.AddRange(items);
        }

        public void Remove(T items)
        {
            _data.Remove(items);
        }

    }

}
