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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["mensaje"] == null)
                divAlerta.Attributes["style"] = "display: none;";
            else
                divAlerta.InnerHtml += Request["mensaje"];
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            VideoClubEntities BBDD = new VideoClubEntities();
            string user = inputUser.Value.ToString();
            string pass = inputPass.Value.ToString();

            List<Usuario> usuario = BBDD.Usuarios.Where(u => u.usu.Equals(user) && u.pass.Equals(pass)).ToList();
            if (usuario.Count > 0)
            {
                Session["idUsuario"] = usuario[0].id;
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                icono.Attributes["style"] += "color: red;";
            }
        }
    }
}