using Domain.Models;

namespace Infra.Banco.Repositorio.BaseRepositorio
{
    public class BasePaginacao<T> where T : class, new()
    {
        private readonly List<T> _data;

        public BasePaginacao()
        {
            _data = [];
        }

        // Método para obter dados paginados
        public ResultModelPagination<T> BuscarPaginaDados(int page, int pageSize)
        {
            var total = _data.Count;
            var data = _data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return new ResultModelPagination<T>(data, total);
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
