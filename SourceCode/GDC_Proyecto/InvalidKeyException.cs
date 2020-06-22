using System;

namespace GDC_Proyecto
{
    class InvalidKeyException : Exception
    {
        public InvalidKeyException(string message) : base(message)
        {
            //Excepción sobre presionar teclas no correspondientes para iniciar el juego
        }
    }
}
