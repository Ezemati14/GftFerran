namespace Banca.Domain.Models.Dto
{
    public class DepositoDto
    {
        public string DNI { get; set; }
        public double Saldo { get; set; }
        public string? Cuenta { get; set; }
        public string? CtaAhorro { get; set; }
        public string? NombreTitular { get; set; }
        public string? ApellidosTitular { get; set; }
        public string? TelefonoTitular { get; set; }
        public DateTime? FechaUltimaTransaccion { get; set; }
    }
}
