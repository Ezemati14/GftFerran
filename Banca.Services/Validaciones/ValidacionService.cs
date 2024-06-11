using Banca.Shared.Exceptions;

namespace Banca.Services.Validaciones
{
    public class ValidacionService : IValidacionService
    {
        private const int LONGITUD_DNI = 9;

        public ValidacionService() { }

        /// <summary>
        /// Función para validar el DNI
        /// </summary>
        /// <param name="dni">DNI a validar</param>
        /// <exception cref="DniNoEncontradoException">Excepción en caso de no encontrar DNI</exception>
        /// <exception cref="DniLongitudErroneaException">Excepción en caso de que el DNI tenga longitud incorrecta</exception>
        /// <exception cref="DniNumerosErroneosException">Excepción en caso que los números del DNI no sean correctos/validos</exception>
        /// <exception cref="DniLetraIncorrectaException">Excepción en caso que la letra del DNI no sea correcta</exception>
        public void ValidarDNI(string dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                throw new DniNoEncontradoException();
            }

            if(dni.Length < LONGITUD_DNI)
            {
                throw new DniLongitudErroneaException();
            }

            string numeros = dni.Substring(0, dni.Length - 1);
            string letra = dni.Substring(dni.Length - 1, 1);
            var numerosValidos = int.TryParse(numeros, out int dniInteger);
            if (!numerosValidos)
            {
                throw new DniNumerosErroneosException();
            }

            if (CalcularLetraDNI(dniInteger) != letra)
            {
                throw new DniLetraIncorrectaException();
            }
        }

        /// <summary>
        /// Función para validar que el importe es correcto
        /// </summary>
        /// <param name="importe">Importe a evaluar</param>
        /// <exception cref="ImporteNegativoException">Excepción en caso de importe negativo</exception>
        public void ValidarImporte(double importe)
        {
            if (importe < 0)
            {
                throw new ImporteNegativoException();
            }
        }

        private string CalcularLetraDNI(int dniNumbers)
        {
            //Cargamos los digitos de control
            string[] control = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            var mod = dniNumbers % 23;
            return control[mod];
        }
    }
}
