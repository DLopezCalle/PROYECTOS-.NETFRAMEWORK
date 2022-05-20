using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoLopez_Carrito1
{
    internal class Program
    {
        private static List<Articulo> GenerarArticulos()
        {
            List<Articulo> lista_articulos = new List<Articulo>();

            lista_articulos.Add(new Articulo(1, "Aceite", 2.10, "Comida"));
            lista_articulos.Add(new Articulo(2, "Agua", 1.50, "Comida"));
            lista_articulos.Add(new Articulo(3, "Cereales", 3.30, "Comida"));

            lista_articulos.Add(new Articulo(4, "Zapatillas Nike", 29.99, "Ropa"));
            lista_articulos.Add(new Articulo(5, "Camiseta Adidas", 24.59, "Ropa"));
            lista_articulos.Add(new Articulo(6, "Gorra Gucci", 150.00, "Ropa"));

            lista_articulos.Add(new Articulo(7, "Monopoly clásico", 49.89, "Juguetes"));
            lista_articulos.Add(new Articulo(8, "Club", 15.22, "Juguetes"));
            lista_articulos.Add(new Articulo(9, "Jenga", 9.99, "Juguetes"));

            return lista_articulos;
        }

        private static List<Categoria> GenerarCategorias()
        {
            return new List<Categoria> { new Categoria("Comida"), new Categoria("Ropa"), new Categoria("Juguetes") };
        }

        private static List<Articulo> GenerarArticulosCategorias(string categoria, List<Articulo> lista_articulos)
        {
            List<Articulo> lista = new List<Articulo>();
            foreach (Articulo articulo in lista_articulos)
            {
                if (articulo._Categoria.Equals(categoria))
                    lista.Add(articulo);
            }
            return lista;
        }

        private static string MenuInicio()
        {
            string opcion = "0";
            bool error = true;

            while (error == true)
            {
                Console.WriteLine("\n===================================\n");
                Console.WriteLine("Introduzca el valor de la opción que desea: ");
                Console.WriteLine("\n===================================\n");
                Console.WriteLine("0. Salir");
                Console.WriteLine("A. Ver todos los artículos");
                Console.WriteLine("B. Ver por categoría");
                Console.WriteLine("C. Finalizar compra");

                Console.Write("\nOpcion: ");

                try
                {
                    opcion = Console.ReadLine();
                    if (char.Parse(opcion) == '0' || char.Parse(opcion) == 'A' || char.Parse(opcion) == 'B' || char.Parse(opcion) == 'C')
                        error = false;
                    else
                        throw new NoExisteCodigoOpcionException();
                }
                catch (NoExisteCodigoOpcionException e)
                {
                    Console.WriteLine(e.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
            }            
            // Console.WriteLine("Z. Volver");
            return opcion;
        }

        private static string MenuTodosArticulos(List<Articulo> lista_articulos)
        {
            string opcion = "";
            bool error = true;

            while (error == true)
            {
                Console.WriteLine("\n===================================\n");
                Console.WriteLine("Introduzca el número del artículo que desea: ");
                Console.WriteLine("\n===================================\n");
                Console.WriteLine("0. Salir");
                foreach (Articulo articulo in lista_articulos)
                    Console.WriteLine(articulo.ToString());
                Console.WriteLine("\nZ. Volver");

                Console.Write("\nOpcion: ");

                try
                {
                    opcion = Console.ReadLine();
                    if (char.Parse(opcion) == '0' || char.Parse(opcion) == 'Z')
                        error = false;
                    // En caso de que el usuario introduzca un número que no corresponda a un artículo
                    else if (int.Parse(opcion) > 0)
                        foreach (Articulo articulo in lista_articulos)
                        {
                            if (articulo.Codigo == int.Parse(opcion))
                                error = false;
                        }
                    else
                        throw new NoExisteCodigoOpcionException();
                }
                catch (NoExisteCodigoOpcionException e)
                {
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return opcion;
        }

        private static string MenuTodasCategorias(List<Categoria> lista_categorias)
        {
            string opcion = "";
            bool error = true;

            while (error == true)
            {
                int i = 1;

                Console.WriteLine("\n===================================\n");
                Console.WriteLine("Introduzca el número del categoría que desea: ");
                Console.WriteLine("\n===================================\n");
                Console.WriteLine("0. Salir");
                foreach (Categoria categoria in lista_categorias)
                {
                    Console.WriteLine($"{i}. {categoria.ToString()}");
                    i++;
                }                    
                Console.WriteLine("\nZ. Volver");

                Console.Write("\nOpcion: ");

                try
                {
                    opcion = Console.ReadLine();
                    if (char.Parse(opcion) == '0' || char.Parse(opcion) == 'Z')
                        error = false;
                    else if (int.Parse(opcion) > 0 && int.Parse(opcion) <= lista_categorias.Count)
                        error = false;
                    else
                        throw new NoExisteCodigoOpcionException();
                }
                catch (NoExisteCodigoOpcionException e)
                {
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return opcion;
        }

        private static string MenuCantidad(string descripcion)
        {
            string opcion = "";
            bool error = true;

            while (error == true)
            {
                Console.WriteLine("\n===================================\n");
                Console.WriteLine($"Introduzca la cantidad que desea comprar de {descripcion}: ");
                Console.WriteLine("\n===================================\n");
                Console.WriteLine("0. Salir");
                Console.WriteLine("\nZ. Volver");
                Console.WriteLine();
                Console.Write("Cantidad u opcion: ");

                try
                {
                    opcion = Console.ReadLine();
                    if (char.Parse(opcion) == '0' || char.Parse(opcion) == 'Z' || int.Parse(opcion) > 0)
                        error = false;
                    else
                        throw new NoExisteCodigoOpcionException();
                }
                catch (NoExisteCodigoOpcionException e)
                {
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
            }
            return opcion;
        }

        private static void FinalizarCompra(List<Carrito> lista_carrito)
        {
            try
            {
                if (lista_carrito.Count == 0)
                    throw new CarritoVacioException();
            }
            catch (CarritoVacioException e)
            {
                Console.WriteLine(e);
            }

            double total = 0;

            Console.WriteLine("\n===================================\n");
            Console.WriteLine("Muchas gracias por su compra");
            Console.WriteLine("\n===================================\n");

            Console.WriteLine("========== FACTURA ==========\n");

            foreach (Carrito articulo in lista_carrito)
            {
                total += articulo.Precio * articulo.Cantidad;
                Console.WriteLine(articulo.ToString());
            }
            Console.WriteLine($"Total factura........................................................................{total} Euros");
        }

        static void Main(string[] args)
        {
            string opcion = "Z";

            // Listas donde se guardarán todos los artículos y categorias
            List<Articulo> lista_articulos = new List<Articulo>();
            List<Categoria> lista_categorias = new List<Categoria>();
            List<Carrito> lista_carrito = new List<Carrito>();

            // Diccionario para buscar rápido un artículo en concreto
            Dictionary<int, Articulo> dic_articulos = new Dictionary<int, Articulo>();
            Dictionary<int, string> dic_categorias = new Dictionary<int, string>();

            lista_articulos = GenerarArticulos();
            lista_categorias = GenerarCategorias();

            // Guardar en los diccionarios todos los productos y categorias
            foreach (Articulo articulo in lista_articulos)
                dic_articulos.Add(articulo.Codigo, articulo);
            for (int i = 0; i < lista_categorias.Count; i++)
                dic_categorias.Add(i + 1, lista_categorias[i]._Categoria);

            while (opcion != "0")
            {                
                while (opcion == "Z")
                {
                    opcion = MenuInicio();
                    if (opcion == "A") // Ver todos los artículos
                    {
                        opcion = MenuTodosArticulos(lista_articulos);
                        if (opcion != "Z")
                        {
                            Articulo articulo = dic_articulos[int.Parse(opcion)];
                            opcion = MenuCantidad(articulo.Descripcion);

                            if (opcion != "0" && opcion != "Z") // Agregar el articulo con la cantidad a la lista de carrito
                            {
                                bool repetido = false;
                                int i = 0;
                                // Comprobar que no se agregó el mismo artículo anteriormente
                                while (i <= lista_carrito.Count - 1 && repetido == false)
                                {
                                    if (lista_carrito[i].Codigo == articulo.Codigo)
                                        repetido = true;
                                    i++;
                                }

                                if (repetido)
                                    lista_carrito[i - 1].Cantidad += int.Parse(opcion);
                                else
                                    lista_carrito.Add(new Carrito(articulo.Codigo, articulo.Descripcion, articulo.Precio, articulo._Categoria, int.Parse(opcion)));
                                opcion = "Z";
                            }
                        }
                    }
                    else if (opcion == "B") // Ver todas las categorias
                    {
                        opcion = MenuTodasCategorias(lista_categorias);
                        if (opcion != "Z" && opcion != "0")
                        {
                            List<Articulo> lista_articulos_categoria = GenerarArticulosCategorias(dic_categorias[int.Parse(opcion)], lista_articulos);
                            opcion = MenuTodosArticulos(lista_articulos_categoria);

                            if (opcion != "Z")
                            {
                                Articulo articulo = dic_articulos[int.Parse(opcion)];
                                opcion = MenuCantidad(articulo.Descripcion);

                                if (opcion != "0" && opcion != "Z") // Agregar el articulo con la cantidad a la lista de carrito
                                {
                                    bool repetido = false;
                                    int i = 0;
                                    // Comprobar que no se agregó el mismo artículo anteriormente
                                    while (i <= lista_carrito.Count - 1 && repetido == false)
                                    {
                                        if (lista_carrito[i].Codigo == articulo.Codigo)
                                            repetido = true;
                                        i++;
                                    }

                                    if (repetido)
                                        lista_carrito[i - 1].Cantidad += int.Parse(opcion);
                                    else
                                        lista_carrito.Add(new Carrito(articulo.Codigo, articulo.Descripcion, articulo.Precio, articulo._Categoria, int.Parse(opcion)));
                                    opcion = "Z";
                                }
                            }
                        }                            
                    }
                    else if (opcion == "C") // Ver factura
                    {
                        FinalizarCompra(lista_carrito);
                        opcion = "0";
                    }
                }
                    
            }
            Console.WriteLine("Saliendo...");
            Console.ReadKey();
        }
    }
}
