using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VideoClub.Models;

namespace VideoClub.Formularios
{
    public partial class Alquilar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null || Request["idPelicula"] == null)
                Response.Redirect("Inicio.aspx");

            int idUsuario = Int32.Parse($"{Session["idUsuario"]}");
            int idPelicula = Int32.Parse(Request["idPelicula"]);
            VideoClubEntities BBDD = new VideoClubEntities();

            int numAlquileres = BBDD.Alquileres.Where(alquiler => alquiler.idUsuario == idUsuario).Count();
            if (numAlquileres >= 5)
                Response.Redirect("Inicio.aspx?mensaje=ERROR: Ya tiene más de 5 películas alquiladas.");
            BBDD.Alquileres.Add(new Alquilere { idUsuario = idUsuario, idPelicula = idPelicula, devuelto = false });
            BBDD.SaveChanges();
            Response.Redirect("Inicio.aspx?mensaje=Ha alquilado la pelicula con éxito.");
        }
    }
}