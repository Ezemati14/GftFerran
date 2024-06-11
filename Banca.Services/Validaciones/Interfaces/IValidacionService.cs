namespace Banca.Services.Validaciones
{
    public interface IValidacionService
    {
        void ValidarDNI(string dni);
        void ValidarImporte(double importe);
    }
}
