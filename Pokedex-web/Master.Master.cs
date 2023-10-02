using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Pokedex_web
{
    public partial class Master : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login) && !(Page is Default) && !(Page is Registro) && !(Page is Error))
            {
                if (!(Seguridad.sesionActiva(Session["trainee"])))
                    Response.Redirect("login.aspx");
            }

            if (Seguridad.sesionActiva(Session["trainee"]) && ((Trainee)Session["trainee"]).Imagen != null)
                imgAvatar.ImageUrl = "~/Images/" + ((Trainee)Session["trainee"]).Imagen;
            else
                imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";


        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Remove("Trainee");
            Response.Redirect("Default.aspx");

            
        }
    }
}