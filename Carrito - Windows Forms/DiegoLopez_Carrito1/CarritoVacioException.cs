using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoLopez_Carrito1
{
    internal class CarritoVacioException : Exception
    {
        public override string ToString()
        {
            return "\nERROR: Problemas al finalizar la compra, el carrito está vacío";
        }
    }
}
