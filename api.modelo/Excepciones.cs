using System;

namespace api.modelo
{
    public class Excepcion : Exception
    {
        public string tipo { get; set; }
        public string codigo { get; set; }
        public override string Message { get; }
        public Excepcion(string codigoError, string mensaje)
        {

            codigo = codigoError;
            Message = mensaje;

        }
    }


    public class ExcepcionVersionExiste : Exception
    {

        public string tipo { get; set; }
        public string codigo { get; set; }
        public override string Message { get; }
        public ExcepcionVersionExiste(string codigoError, string mensaje)
        {

            codigo = codigoError;
            Message = mensaje;

        }




    }
}
