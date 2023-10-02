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
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["trainee"]))
                    {
                        Trainee trainee = (Trainee)Session["trainee"];
                        txtEmail.Text = trainee.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = trainee.Nombre;
                        txtApellido.Text = trainee.Apellido;
                        txtFechaNacimiento.Text = trainee.FechaNacimiento.ToString("yyyy-MM-dd");

                        if (!string.IsNullOrEmpty(trainee.Imagen))
                        {
                            imgPerfil.ImageUrl = "~/Images/" + trainee.Imagen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Server.MapPath("./Images/");
                Trainee trainee = (Trainee)Session["trainee"];
                TraineeNegocio negocio = new TraineeNegocio();

                if (txtImage.PostedFile.FileName != "")
                {
                    txtImage.PostedFile.SaveAs(ruta + "Perfil-" + trainee.Id + ".jpg");
                    trainee.Imagen = "Perfil-" + trainee.Id + ".jpg";
                    imgPerfil.ImageUrl = "~/Images/" + trainee.Imagen;
                }

                trainee.Nombre = txtNombre.Text;
                trainee.Apellido = txtApellido.Text;
                trainee.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);



                negocio.actualizar(trainee);
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void txtImage_onchange(object sender, EventArgs e)
        {
            Trainee trainee = (Trainee)Session["trainee"];
            imgPerfil.ImageUrl = "~/Images/" + trainee.Imagen;
        }



    }
}