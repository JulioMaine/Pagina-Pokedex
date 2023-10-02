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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["trainee"]))
            {
                TraineeNegocio negocio = new TraineeNegocio();
                Trainee trainee = (Trainee)Session["trainee"];
                txtEmail.Text = trainee.Email;
                txtEmail.ReadOnly = true;
                txtNombre.Text = trainee.Nombre;
                txtApellido.Text = trainee.Apellido;

                if (!string.IsNullOrEmpty(trainee.Imagen))
                {
                    imgPerfil.ImageUrl = "~/Images/" + trainee.Imagen;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Server.MapPath("./Images/");
                Trainee trainee = (Trainee)Session["trainee"];
                TraineeNegocio negocio = new TraineeNegocio();
                txtImage.PostedFile.SaveAs(ruta + "Perfil-" + trainee.Id + ".jpg");
                trainee.Imagen = "Perfil-" + trainee.Id + ".jpg";
               
                trainee.Nombre = txtNombre.Text;
                trainee.Apellido = txtApellido.Text;
                trainee.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                imgPerfil.ImageUrl = "~/Images/" + trainee.Imagen;


                negocio.actualizar(trainee);
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void txtImage_onchange (object sender, EventArgs e)
        {
            Trainee trainee = (Trainee)Session["trainee"];
            imgPerfil.ImageUrl = "~/Images/" + trainee.Imagen;
        }



    }
}