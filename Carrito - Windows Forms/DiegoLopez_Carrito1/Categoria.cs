using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoLopez_Carrito1
{
    internal class Categoria
    {
        // Atributos
        protected string _categoria;

        // Constructor vacío
        public Categoria()
        {
        }

        // Constructor
        public Categoria(string categoria)
        {
            this._categoria = categoria;
        }

        public string _Categoria { get => _categoria; set => _categoria = value; }

        // ========== Métodos ==========

        public override string ToString()
        {
            return ($"{_categoria}");
        }
    }
}
