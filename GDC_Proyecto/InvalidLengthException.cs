using System;

namespace GDC_Proyecto
{
    class InvalidLengthException : Exception
    {
        public InvalidLengthException(string message) : base(message)
        {
        }
    }
}
