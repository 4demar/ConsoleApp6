
namespace Domain.Entidades
{
    public class LeituraEpc
    {
        public string Hex { get; set; } = string.Empty;
        public DateTime DataRegistro { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public string CodigoProduto { get; set; } = string.Empty;
        public string CodigoBarras { get; set; } = string.Empty;
        public int CodigoVariacao { get; set; }
        public string CodigoHierarquia { get; set; } = string.Empty;
        public string CodigoFamilia { get; set; } = string.Empty;
        public bool FalsoPositivo { get; set; }
        public bool Alerta { get; set; }
    }
}
