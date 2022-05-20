using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Control3_DiegoLopez.Models;

namespace Control3_DiegoLopez.Controllers
{
    public class HomeController : Controller
    {
        // ========== Index ==========
        public ActionResult Index()
        {
            ShopEntities BBDD = new ShopEntities();
            ViewData["Categorias"] = BBDD.Categorias.Where(categoria => categoria.Articulos.Any(articulo => articulo.stock > 0)).ToList();
            return View(BBDD.Articulos.Where(articulo => articulo.stock > 0).ToList());
        }

        [HttpPost]
        // ========== Index ==========
        public ActionResult Index(FormCollection f)
        {
            ShopEntities BBDD = new ShopEntities();
            ViewData["Categorias"] = BBDD.Categorias.Where(categoria => categoria.Articulos.Any(articulo => articulo.stock > 0)).ToList();
            int idCategoria = Int32.Parse(f["idCategoria"]);
            ViewBag.idCategoria = idCategoria;
            return View(BBDD.Articulos.Where(articulo => articulo.idCategoria == idCategoria && articulo.stock > 0).ToList());
        }

        // ========== AddCarrito ==========
        public ActionResult AddCarrito(FormCollection f)
        {
            ShopEntities BBDD = new ShopEntities();
            int idArticulo = Int32.Parse(f["id"].ToString());
            int cantidad = Int32.Parse(f["cantidad"].ToString());            

            if (BBDD.Articulos.Where(articulo => articulo.id == idArticulo && articulo.stock >= cantidad).ToList().Count == 0)
            {
                Session["Mensaje"] = "El artículo seleccionado no existe o no hay suficiente stock.";
                return RedirectToAction("Index");
            }

            int stock = BBDD.Articulos.Where(articulo => articulo.id == idArticulo && articulo.stock >= cantidad).ToList()[0].stock;

            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new List<LineasPedido>();
            }

            List<LineasPedido> carrito = (List<LineasPedido>)(Session["Carrito"]);
            if (carrito.Where(c => c.idArticulo == idArticulo && c.cantidad + cantidad > stock).ToList().Count == 1)
            {
                Session["Mensaje"] = "El artículo seleccionado no tiene suficiente stock, comprueba tu carrito de la compra.";
                return RedirectToAction("Index");
            }

            if (carrito.Where(c => c.idArticulo == idArticulo).ToList().Count == 1)
            {
                foreach (LineasPedido linea in carrito)
                {
                    if (linea.idArticulo == idArticulo)
                    {
                        linea.cantidad += cantidad;
                    }
                }
            }
            else
            {
                carrito.Add(new LineasPedido { idArticulo = idArticulo, cantidad = cantidad });
            }

            Console.WriteLine("Llega al final");
            Session["Carrito"] = carrito;
            Session["Mensaje"] = "¡El artículo se añadió al carrito correctamente!";
            return RedirectToAction("Index");
        }

        // ========== Carrito ==========
        public ActionResult Carrito()
        {
            ShopEntities BBDD = new ShopEntities();
            if (Session["Carrito"] == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = BBDD.Categorias.Where(categoria => categoria.Articulos.Any(articulo => articulo.stock > 0)).ToList();
            ViewData["Articulos"] = BBDD.Articulos.ToList();
            return View();
        }

        // ========== Comprar ==========
        public ActionResult Comprar()
        {
            ShopEntities BBDD = new ShopEntities();

            if (Session["idUsuario"] == null)
            {
                Session["Mensaje"] = "Para finalizar la compra. Primero debes iniciar sesión.";
                return RedirectToAction("LogIn");
            }
            if (Session["Carrito"] == null)
            {
                Session["Mensaje"] = "No tienes ningún artículo en el carrito. Primero añade un artículo al carrito.";
                return RedirectToAction("Index");
            }

            int idUsuario = Int32.Parse($"{Session["idUsuario"]}");
            List<LineasPedido> carrito = (List<LineasPedido>)(Session["Carrito"]);

            BBDD.Pedidos.Add(new Pedido { idUsuario = idUsuario, fecha = DateTime.Now });
            BBDD.SaveChanges();
            List<Pedido> pedidos = BBDD.Pedidos.OrderBy(pedido => pedido.id).ToList();
            int idPedido = Int32.Parse($"{ pedidos[0].id}");
            foreach (var linea in carrito)
            {
                BBDD.LineasPedidos.Add(new LineasPedido { idPedido = idPedido, idArticulo = linea.idArticulo, cantidad = linea.cantidad });
                foreach (var articulo in BBDD.Articulos.ToList())
                {
                    if (articulo.id == linea.idArticulo)
                    {
                        if (articulo.stock >= linea.cantidad)
                        {
                            articulo.stock -= (int)linea.cantidad;
                        }
                        else
                        {
                            Session["Mensaje"] = $"Se agotó parte de nuestro stock en el artículo {articulo.nombre}. Por favor reduzca la cantidad a pedir.";
                            return RedirectToAction("Index");
                        }
                    }
                    
                }
            }
            BBDD.SaveChanges();
            Session["Carrito"] = null;
            return RedirectToAction("Index");
        }

        // ========== LogIn ==========
        public ActionResult LogIn()
        {
            ShopEntities BBDD = new ShopEntities();
            ViewData["Categorias"] = BBDD.Categorias.Where(categoria => categoria.Articulos.Any(articulo => articulo.stock > 0)).ToList();
            return View();
        }

        [HttpPost]
        // ========== LogIn ==========
        public ActionResult LogIn(FormCollection f)
        {
            string usu = f["usuario"];
            string pass = f["pass"];
            if (usu.Equals("") || pass.Equals(""))
            {
                Session["Mensaje"] = "Debes rellenar todos los campos del formulario.";
                return RedirectToAction("LogIn");
            }

            ShopEntities BBDD = new ShopEntities();
            List<Usuario> usuario = BBDD.Usuarios.Where(u => u.usuario1 == usu && u.pass == pass).ToList();
            if (usuario.Count != 1)
            {
                Session["Mensaje"] = "El usuario o la contraseña son incorrectas. Por favor intentalo de nuevo.";
                return RedirectToAction("LogIn");
            }

            Session["idUsuario"] = usuario[0].id;
            return RedirectToAction("Carrito");
        }

        // ========== LogOut ==========
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session["Mensaje"] = "¡La sesión se cerró correctamente!";
            return RedirectToAction("Index");
        }

        // ========== LogUp ==========
        public ActionResult LogUp()
        {
            ShopEntities BBDD = new ShopEntities();
            ViewData["Categorias"] = BBDD.Categorias.Where(categoria => categoria.Articulos.Any(articulo => articulo.stock > 0)).ToList();
            return View();
        }

        [HttpPost]
        // ========== LogUp ==========
        public ActionResult LogUp(FormCollection f)
        {
            string usu = f["usuario"];
            string pass = f["pass"];
            if (usu.Equals("") || pass.Equals(""))
            {
                Session["Mensaje"] = "Debes rellenar todos los campos del formulario.";
                return RedirectToAction("LogIn");
            }

            ShopEntities BBDD = new ShopEntities();
            List<Usuario> usuario = BBDD.Usuarios.Where(u => u.usuario1 == usu).ToList();
            if (usuario.Count != 0)
            {
                Session["Mensaje"] = $"Ya existe el usuario '{usu}'. Prueba a iniciar sesión.";
                return RedirectToAction("LogUp");
            }
            BBDD.Usuarios.Add(new Usuario { usuario1 = usu, pass = pass });
            BBDD.SaveChanges();
            return RedirectToAction("LogIn");
        }

        // ========== DeadCarrito ==========
        public ActionResult DeadCarrito()
        {
            Session["Carrito"] = null;
            return RedirectToAction("Index");
        }

        [HttpPost]
        // ========== BorrarCarrito ==========
        public ActionResult BorrarCarrito(FormCollection f)
        {
            int idArticulo = Int32.Parse(f["idArticulo"].ToString());
            int cantidad = Int32.Parse(f["cantidad"].ToString());

            if (cantidad <= 0)
            {
                Session["Mensaje"] = "Imagina querer borrar 0 unidades...";
                return RedirectToAction("Carrito");
            }

            List<LineasPedido> carrito = (List<LineasPedido>)(Session["Carrito"]);
            LineasPedido aux = new LineasPedido();
            foreach (var linea in (List<LineasPedido>)(Session["Carrito"]))
            { 
                if (linea.idArticulo == idArticulo)
                {
                    linea.cantidad -= cantidad;
                }
                if (linea.cantidad <= 0)
                {
                    aux = linea;
                }
            }
            carrito.Remove(aux);
            Session["Mensaje"] = $"¡Se borraron con éxito las unidades ({cantidad}) del artículo!";
            if (carrito.Count == 0)
                Session["Carrito"] = null;
            else
                Session["Carrito"] = carrito;
            return RedirectToAction("Carrito");
        }
    }
}