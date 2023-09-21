<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Tarjetas.aspx.cs" Inherits="Pokedex_web.Tarjetas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row row-cols-1 row-cols-md-3 g-4">

            <%--         <% 
            foreach (dominio.Pokemon item in ListaPokemon)
            { %>

        <div class="col">
            <div class="card">
                <img src="<%: item.UrlImagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: item.Nombre %></h5>
                    <p class="card-text"><%: item.Descripcion %></p>
                    <a href="Default.aspx?ID=<%:item.Id %>">Detalle</a>
                </div>
            </div>
        </div>

        <%  }   %>--%>

            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <img src="<%#Eval("UrlImagen")%>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                <p class="card-text"><%#Eval("Descripcion")%></p>
                                <asp:Button Text="Capturar ID" ID="btnId" CommandArgument='<%#Eval("Id") %>' CommandName="PokemonId" CssClass="btn btn-primary" OnClick="btnId_Click" runat="server" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
