using Domain.Entidades;

namespace Domain.Models
{
    public class Passagem
    {
        public int Id { get; set; }
        public List<LeituraEpc> Itens { get; set; }
    }
}
