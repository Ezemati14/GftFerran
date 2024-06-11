namespace Banca.Shared.Exceptions
{
    public class DniNoEncontradoException : Exception
    {
        public DniNoEncontradoException() : base("El DNI no puede ser nulo o vacío") { }
    }
}
