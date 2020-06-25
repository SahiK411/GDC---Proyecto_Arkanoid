using System;

namespace GDC_Proyecto
{
    class InvalidSymbolsException : Exception
    {
        public InvalidSymbolsException (string message) : base(message)
        {
            //Excepción para invalidar símbolos en el nickname (#,$,%,&)
        }
    }
}
