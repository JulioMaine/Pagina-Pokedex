using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Pokedex_web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngreso_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio traineeNegocio = new TraineeNegocio();
            try
            {
            trainee.Email = txtEmail.Text;
            trainee.Password = txtPassword.Text;
            
                if (traineeNegocio.login(trainee))
                {
                    Session.Add("trainee", trainee);
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "La usuario no existe, o la contraseña es incorrecta.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {


                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}