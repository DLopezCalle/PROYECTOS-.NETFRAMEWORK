using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VideoClub.Models;

namespace VideoClub.Formularios
{
    public partial class Estadisticas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VideoClubEntities BBDD = new VideoClubEntities();
            // Película más vista

            // Película menos vista

            // Película recomendada: La idea sería segun que peliculas ha alquila el usuario, se le recomendaría una u otra
        }
    }
}