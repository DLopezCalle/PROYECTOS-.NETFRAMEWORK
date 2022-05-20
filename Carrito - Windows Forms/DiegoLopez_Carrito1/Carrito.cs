using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoLopez_Carrito1
{
    internal class Carrito : Articulo
    {
        private int _cantidad;
        public Carrito(int codigo, string descripcion, double precio, string categoria, int cantidad) : base(codigo, descripcion, precio, categoria)
        {
            _cantidad = cantidad;
        }

        public int Cantidad { get => _cantidad; set => _cantidad = value; }

        public override string ToString()
        {
            return ($"{_cantidad}ud..........{Descripcion}...............P.U: {Precio} euros.................Subtotal: {Precio * Cantidad}\n");
        }
    }
}
