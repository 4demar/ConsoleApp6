
using Dominio.Enum;

namespace Dominio.Models
{
    public class ConfigRelatorio
    {
        public string NomeMetodo { get; set; } = string.Empty;
        public string EnderecoEmail { get; set; } = string.Empty;
        public string UrlTeams { get; set; } = string.Empty;
        public List<AgendadorRelatorio> AgendadorRelatorio { get; set; } = new List<AgendadorRelatorio>();
        public StatusNotificacao StatusNotificacao { get; set; }
    }
}
