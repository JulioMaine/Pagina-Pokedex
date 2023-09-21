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
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        public bool clickBorrar = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtbID.ReadOnly = true;

            try
            {
                // Configuración si estamos agregando un pokemon.
                if (!IsPostBack)
                {
                    ElementoNegocio elementoNegocio = new ElementoNegocio();
                    ddlTipo.DataSource = elementoNegocio.listar();
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    ddlDebilidad.DataSource = elementoNegocio.listar();
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();

                    btnEliminar.Visible = false;
                    btnDesactivar.Visible = false;
                }

                // Configuración si estamos modificando un pokemon.

                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    btnEliminar.Visible = true;
                    btnDesactivar.Visible = true;


                    PokemonNegocio pokemonNegocio = new PokemonNegocio();
                    Pokemon pokemonSeleccionado = pokemonNegocio.listar(id)[0];

                    txtbID.Text = id.ToString();
                    txtbDescripcion.Text = pokemonSeleccionado.Descripcion;
                    txtbNombre.Text = pokemonSeleccionado.Nombre;
                    txtbNumero.Text = pokemonSeleccionado.Numero.ToString();
                    txtbUrlImagen.Text = pokemonSeleccionado.UrlImagen;
                    ddlDebilidad.SelectedValue = pokemonSeleccionado.Debilidad.Id.ToString();
                    ddlTipo.SelectedValue = pokemonSeleccionado.Tipo.Id.ToString();

                    imgPokemon.ImageUrl = txtbUrlImagen.Text;

                    // Configuración para reactivar pokemon.

                    if (pokemonSeleccionado.Activo)
                        btnDesactivar.Text = "Desactivar";
                    else
                        btnDesactivar.Text = "Reactivar";

                    Session.Add("pokemonSeleccionado", pokemonSeleccionado);


                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void txtbUrlImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                imgPokemon.ImageUrl = txtbUrlImagen.Text;
            }
            catch (Exception)
            {
                imgPokemon.ImageUrl = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon pokemon = new Pokemon();
                PokemonNegocio pokemonNegocio = new PokemonNegocio();

                pokemon.Numero = int.Parse(txtbNumero.Text);
                pokemon.Nombre = txtbNombre.Text;
                pokemon.UrlImagen = txtbUrlImagen.Text;
                pokemon.Descripcion = txtbDescripcion.Text;

                pokemon.Tipo = new Elemento();
                pokemon.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                pokemon.Debilidad = new Elemento();
                pokemon.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {
                    pokemon.Id = int.Parse(txtbID.Text);
                    pokemonNegocio.modificarConSP(pokemon);
                }
                else
                    pokemonNegocio.agregarConSP(pokemon);

                Response.Redirect("TablaPokemons.aspx");


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            clickBorrar = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            if (ckbEliminar.Checked)
            {
                PokemonNegocio pokemonNegocio = new PokemonNegocio();
                pokemonNegocio.eliminar(int.Parse(Request.QueryString["Id"]));
                Response.Redirect("TablaPokemons.aspx");
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio pokemonNegocio = new PokemonNegocio();
                Pokemon pokemonSeleccionado = (Pokemon)Session["pokemonSeleccionado"];
                
                pokemonNegocio.eliminarLogico(pokemonSeleccionado.Id, !pokemonSeleccionado.Activo);

                Response.Redirect("TablaPokemons.aspx");


                //  TAMBIEN SE PODRIA HACER ASÍ:    
                //    if(btnDesactivar.Text == "Desactivar")
                //        pokemonNegocio.eliminarLogico(int.Parse(Request.QueryString["Id"]));
                //    else
                //        pokemonNegocio.eliminarLogico(int.Parse(Request.QueryString["Id"]), true);
                //    Response.Redirect("TablaPokemons.aspx");
                //
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}