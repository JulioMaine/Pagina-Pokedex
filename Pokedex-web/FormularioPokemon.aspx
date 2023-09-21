<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="Pokedex_web.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label for="txtbID" CssClass="form-label" runat="server">Id</asp:Label>
                    <asp:TextBox ID="txtbID" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label for="txtbNombre" CssClass="form-label" runat="server">Nombre</asp:Label>
                    <asp:TextBox ID="txtbNombre" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label for="txtbNumero" CssClass="form-label" runat="server">Numero</asp:Label>
                    <asp:TextBox ID="txtbNumero" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label for="ddlTipo" CssClass="form-label" runat="server">Tipo</asp:Label>
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label for="ddlDebilidad" runat="server" Text="Label" CssClass="form-label">Debilidad</asp:Label>
                    <asp:DropDownList ID="ddlDebilidad" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Button Text="Aceptar" class="btn btn-primary" ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" />
                    <a href="TablaPokemons.aspx" class="btn btn-primary">Cancelar</a>
                    <asp:Button ID="btnEliminar" class="btn btn-danger" runat="server" Text="Borrar" OnClick="btnEliminar_Click" />
                    <asp:Button ID="btnDesactivar" class="btn btn-warning" runat="server" Text="Desactivar" OnClick="btnDesactivar_Click"/>
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label for="txtbDescripcion" CssClass="form-label" runat="server">Descripción</asp:Label>
                    <asp:TextBox ID="txtbDescripcion" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Label for="txtbUrlImagen" CssClass="form-label" runat="server">Url Imagen</asp:Label>
                            <asp:TextBox ID="txtbUrlImagen" class="form-control" runat="server" AutoPostBack="true"
                                OnTextChanged="txtbUrlImagen_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Image ID="imgPokemon" runat="server" Width="54%" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <% if (clickBorrar)
                {%>
              <div>
                   <asp:CheckBox ID="ckbEliminar" runat="server" Text="Marque para confirmar" />
                   <asp:Button ID="btnConfirmarEliminacion" runat="server" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminacion_Click" Text="Borrar" />
               </div>
            <% } %>
        </div>
    </div>

</asp:Content>
