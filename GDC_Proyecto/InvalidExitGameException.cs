using System;

namespace GDC_Proyecto
{
    class InvalidExitGameException : Exception
    {
        public InvalidExitGameException(string message) : base(message)
        {
            //Excepción sobre cierre de juego antes de acabar partida
        }
    }
}
