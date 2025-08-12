using Dominio.Enum;

namespace Dominio.Entidade
{
    public class ConfigRelatorio
    {
        public string NomeMetodo { get; set; } = string.Empty;
        public List<string> ListaEnderecoEmail { get; set; } = new();
        public string UrlTeams { get; set; } = string.Empty;
        public List<AgendadorRelatorio> AgendadorRelatorio { get; set; } = new();
        public StatusNotificacao StatusNotificacao { get; set; }
    }
}
