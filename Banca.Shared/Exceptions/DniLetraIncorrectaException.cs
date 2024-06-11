namespace Banca.Shared.Exceptions
{
    public class DniLetraIncorrectaException : Exception
    {
        public DniLetraIncorrectaException() : base("La letra del DNI es incorrecta") { }
    }
}
