using System;

namespace GDC_Proyecto
{
    class InvalidLengthException : Exception
    {
        public InvalidLengthException(string message) : base(message)
        {
            //Excepcion general sobre tamaño máximo y mínimo del nickname del usuario
        }
    }
}
