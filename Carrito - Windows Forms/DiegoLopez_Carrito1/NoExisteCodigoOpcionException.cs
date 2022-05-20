using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoLopez_Carrito1
{
    internal class NoExisteCodigoOpcionException : Exception
    {
        public override string ToString()
        {
            return "\nERROR: Por favor escoja una de las opciones disponibles";
        }
    }
}
