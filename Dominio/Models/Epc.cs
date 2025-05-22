
namespace Domain.Models
{
    public class Epc
    {
        public string Hex { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public DateTime DataRegistro { get; set; }
        public bool ItemComAlerta { get; set; }
        public bool FalsoPositivo { get; set; }
    }
}