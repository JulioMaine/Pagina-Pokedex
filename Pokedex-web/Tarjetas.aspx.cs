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
    public partial class Tarjetas : System.Web.UI.Page
    {
        public List<Pokemon> ListaPokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio pokemonNegocio = new PokemonNegocio();
            ListaPokemon = pokemonNegocio.listarConSP();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaPokemon;
                repRepetidor.DataBind();
            }

        }

        protected void btnId_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}