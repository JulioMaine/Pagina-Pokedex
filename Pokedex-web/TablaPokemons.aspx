<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TablaPokemons.aspx.cs" Inherits="Pokedex_web.TablaPokemons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-1" style="width: 25px">
            </div>
            <div class="col-4">
                <div>
                    <asp:Label ID="Label1" runat="server" CssClass="fs-6 h1 font-weight-bold" Text="Buscar nombre:"></asp:Label>
                </div>
                <div class="d-inline">
                    <asp:TextBox ID="txtFiltroRapido" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroRapido_TextChanged" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-2" style="display: flex; flex-direction: column; justify-content: end">
                <asp:CheckBox ID="ckbFiltroAvanzado" CssClass="form-check-inline" OnCheckedChanged="ckbFiltroAvanzado_CheckedChanged" AutoPostBack="true" Text="Filtro avanzado" runat="server" />
            </div>
            <div class="col-1" style="width: 25px">
            </div>
        </div>
        <% if (FiltroAvanzado)
            { %>
        <div class="row mt-3">
            <div class="col-1" style="width: 25px">
            </div>
            <div class="col">
                <asp:Label ID="Label2" runat="server" Text="Campo"></asp:Label>
                <asp:DropDownList ID="ddlCampo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Tipo" />
                    <asp:ListItem Text="Número" />
                </asp:DropDownList>
            </div>
            <div class="col">
                <div class="col-1" style="width: 25px">
                </div>
                <div class="col">
                    <asp:Label ID="Label3" runat="server" Text="Criterio"></asp:Label>
                    <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col">
                <asp:Label ID="Label4" runat="server" Text="Filtro"></asp:Label>
                <asp:TextBox ID="txbFiltroAvanzado" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="Label5" runat="server" Text="Estado"></asp:Label>
                <asp:DropDownList ID="ddlEstado" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Todos" />
                    <asp:ListItem Text="Activos" />
                    <asp:ListItem Text="Inactivos" />
                </asp:DropDownList>
            </div>
            <div class="col-1" style="width: 25px">
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-1" style="width: 25px">
            </div>
        <div class="col-1">
            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
        </div>

         </div>
    <% } %>
    <div class="row mt-3">
        <div class="col-1" style="width: 25px">
        </div>
        <div class="col">
            <asp:GridView ID="dgvPokemons" runat="server" AutoGenerateColumns="false" CssClass="table"
                OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged" DataKeyNames="Id"
                OnPageIndexChanging="dgvPokemons_PageIndexChanging" AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Número" DataField="Numero" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                    <asp:BoundField HeaderText="Debilidad" DataField="Debilidad.Descripcion" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍️" />
                </Columns>
            </asp:GridView>
            <a href="FormularioPokemon.aspx" class="btn btn-primary">Agregar</a>
        </div>
        <div class="col-1" style="width: 25px">
        </div>
    </div>
    </div>
</asp:Content>
