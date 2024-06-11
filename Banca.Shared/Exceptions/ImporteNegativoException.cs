namespace Banca.Shared.Exceptions
{
    public class ImporteNegativoException : Exception
    {
        public ImporteNegativoException() : base("El importe no puede ser negativo") { }
    }
}
