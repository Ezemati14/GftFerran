namespace Banca.Shared.Exceptions
{
    public class DniLongitudErroneaException : Exception
    {
        public DniLongitudErroneaException() : base("La longitud del DNI no puede ser inferior a 9") { }
    }
}
