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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Trainee nuevo = new Trainee();
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                EmailService email = new EmailService();
                
                nuevo.Email = txtEmail.Text;
                nuevo.Password = txtPassword.Text;
                nuevo.Id = traineeNegocio.InsertarNuevo(nuevo);
                Session.Add("trainee", nuevo);

                email.armarCorreo(nuevo.Email, "lallala", "¿Funcionara?");
                email.enviarEmail();
                Response.Redirect("Default.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}