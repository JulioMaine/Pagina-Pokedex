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
    public partial class TablaPokemons : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = ckbFiltroAvanzado.Checked;
            
            if (Session["listaFiltradaAvanzada"] != null)
            {
                dgvPokemons.DataSource = Session["listaFiltradaAvazada"];
                dgvPokemons.DataBind();
                btnBuscar_Click(sender, e);
            }
            if(Session["listaFiltradaRapida"] != null)
            {
                dgvPokemons.DataSource = Session["listaFiltradaRapida"];
                dgvPokemons.DataBind();
                txtFiltroRapido_TextChanged(sender, e);
            }

            if (!IsPostBack)
            {
                PokemonNegocio pokemonNegocios = new PokemonNegocio();
                dgvPokemons.DataSource = pokemonNegocios.listarConSP();
                Session.Add("listaDePokemons", pokemonNegocios.listarConSP());
                dgvPokemons.DataBind();

                ddlCriterio.Items.Add("Empieza con:");
                ddlCriterio.Items.Add("Termina con:");
                ddlCriterio.Items.Add("Contiene:");
            }
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?Id=" + valor);
        }


        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if(Session["listaFiltradaAvanzada"] == null && Session["listaFiltradaRapida"] == null)
            {
                PokemonNegocio pokemonNegocios = new PokemonNegocio();
                dgvPokemons.DataSource = pokemonNegocios.listarConSP();
                dgvPokemons.DataBind();
            }
       
            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();

        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listaPokemons = (List<Pokemon>)Session["listaDePokemons"];
            dgvPokemons.DataSource = listaPokemons.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()));
            dgvPokemons.DataBind();

            Session.Add("listaFiltradaRapida", listaPokemons);
        }

        protected void ckbFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = ckbFiltroAvanzado.Checked;
            txtFiltroRapido.Enabled = !ckbFiltroAvanzado.Checked;

            if (!ckbFiltroAvanzado.Checked)
            {
                PokemonNegocio pokemonNegocio = new PokemonNegocio();
                dgvPokemons.DataSource = pokemonNegocio.listarConSP();
                dgvPokemons.DataBind();
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            
            if(ddlCampo.Text == "Número")
            {
                ddlCriterio.Items.Add("Mayor a:");
                ddlCriterio.Items.Add("Menor a:");
                ddlCriterio.Items.Add("Igual a:");
            }   
            else
            {
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Empieza con:");
                ddlCriterio.Items.Add("Termina con:");
                ddlCriterio.Items.Add("Contiene:");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            PokemonNegocio pokemonNegocio = new PokemonNegocio();
            List<Pokemon> listaFiltrada = pokemonNegocio.filtrar(ddlCampo.SelectedValue.ToString(), ddlCriterio.SelectedValue.ToString(), txbFiltroAvanzado.Text, ddlEstado.SelectedValue.ToString());
            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();

            Session.Add("listaFiltradaAvanzada", listaFiltrada);
        }
    }
}