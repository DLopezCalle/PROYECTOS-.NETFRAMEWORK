using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using VideoClub.Models;

namespace VideoClub.Formularios
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
                Response.Redirect("Default.aspx?mensaje=ERROR: No tienes acceso a la web. Por favor inicia sesión");

            if (Request["mensaje"] == null)
                divAlerta.Attributes["style"] = "display: none;";
            else
                divAlerta.InnerHtml += Request["mensaje"];

            VideoClubEntities BBDD = new VideoClubEntities();
            lvPeliculas.DataSource = BBDD.Peliculas.Where(pelicula => !pelicula.Alquileres.Any(alquiler => alquiler.devuelto == false)).ToList();
            lvPeliculas.DataBind();
        }

        protected void lvPeliculas_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Pelicula pelicula = (Pelicula)e.Item.DataItem;
            ((HtmlImage)e.Item.FindControl("imgImagen")).Attributes["src"] = $"https://loremflickr.com/640/360/{pelicula.id}";
            ((Label)e.Item.FindControl("lblTitulo")).Text = pelicula.titulo;
            ((Label)e.Item.FindControl("lblSinopsis")).Text = pelicula.sinopsis;
            ((HtmlAnchor)e.Item.FindControl("btnAlquilar")).Attributes["href"] = $"Alquilar.aspx?idPelicula={pelicula.id}";
        }
    }
}