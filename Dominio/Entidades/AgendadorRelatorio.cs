namespace Dominio.Entidade
{
    public class AgendadorRelatorio
    {
        public string NomeRelatorio { get; set; } = string.Empty;
        public string DiasSemana { get; set; } = string.Empty;
        public string Dia { get; set; } = string.Empty;
        public string Periodo { get; set; } = string.Empty;
        public int QtdPeriodo { get; set; }
    }
}