namespace Banca.Shared.Exceptions
{
    public class SaldoNoEncontradoException : Exception
    {
        public SaldoNoEncontradoException() : base("No se ha encontrado ningún DNI con saldo a devolver") { }
    }
}
