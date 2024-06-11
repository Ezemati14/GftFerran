namespace Banca.Shared.Exceptions
{
    public class DniNumerosErroneosException : Exception
    {
        public DniNumerosErroneosException() : base("El valor de DNI introducido no es válido") { }
    }
}
