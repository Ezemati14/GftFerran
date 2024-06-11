using System.ComponentModel.DataAnnotations;

namespace Banca.Infrastructure.Modelos
{
    public class Deposito
    {
        [Key]
        public string DNI { get; set; }
        public double Saldo { get; set; }
        public string? Cuenta { get; set; }
        public string? CuentaAhorro { get; set; }
        public string? NombreTitular { get; set; }
        public string? ApellidosTitular { get; set;}
        public string? TelefonoTitular { get; set; }
        public DateTime? FechaUltimaTransaccion { get; set; }
    }
}
