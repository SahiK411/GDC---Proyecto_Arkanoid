using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDC_Proyecto
{
    class UnableToConnectException : Exception
    {
        public UnableToConnectException(string message) : base(message)
        {
            //Excepcion general sobre dificultades de conexion a la base de datos
        }
    }
}
