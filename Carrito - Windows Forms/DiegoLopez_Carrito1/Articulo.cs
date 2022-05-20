using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoLopez_Carrito1
{
    internal class Articulo : Categoria
    {
        private int _codigo;
        private string _descripcion;
        private double _precio;

        public Articulo(int codigo, string descripcion, double precio, string categoria) : base(categoria)
        {
            this._codigo = codigo;
            this._descripcion = descripcion;
            this._precio = precio;
        }

        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public double Precio { get => _precio; set => _precio = value; }

        public override string ToString()
        {
            return ($"{this._codigo}. {this._descripcion} ========== {this._precio} euros");
        }
    }
}
