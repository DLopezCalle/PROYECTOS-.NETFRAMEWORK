using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VideoClub.Models;

namespace VideoClub.Formularios
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            VideoClubEntities BBDD = new VideoClubEntities();
            string user = inputUser.Value.ToString();
            string pass = inputPass.Value.ToString();

            if (user.Equals("") || pass.Equals(""))
                icono.Attributes["style"] += "color: red;";
            else
            {
                List<Usuario> usuario = BBDD.Usuarios.Where(u => u.usu.Equals(user)).ToList();
                if (usuario.Count > 0)
                {
                    icono.Attributes["style"] += "color: red;";
                }
                else
                {
                    BBDD.Usuarios.Add(new Usuario { usu = user, pass = pass });
                    BBDD.SaveChanges();
                    Response.Redirect("Default.aspx?mensaje=¡Te has registrado con éxito!");
                }
            }
        }
    }
}