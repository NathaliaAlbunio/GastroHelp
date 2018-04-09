<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TelaReceita.aspx.cs" Inherits="GastroHelp.WebUI.TelaReceita" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h2>
                <asp:Label ID="lblNomeReceita" runat="server" />
            </h2>
            <h4>
                <asp:Label ID="lblCategoria" runat="server" />
            </h4>
            <h4>
                <asp:Label ID="lblUsuario" runat="server" />
            </h4>
            <h4>
                <asp:Label ID="lblNivel" runat="server" />
            </h4>
            <h5 class="text-justify">
                <asp:Label ID="lblResumo" runat="server" />
            </h5>
        </div>
        <div class="col-md-6">
            <img class="img-rounded img-responsive" src="Images/bacalhau.jpg" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <h3 class="ingredients-title box-title">
                <span class="glyphicon glyphicon-cutlery" style="padding-right: 10px;"></span>INGREDIENTES:
            </h3>
            <asp:Literal ID="lblIngredientes" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12" style="padding-bottom: 25px;">
            <h3 class="ingredients-title box-title">
                <span class="glyphicon glyphicon-cutlery" style="padding-right: 10px;"></span>MODO DE PREPARO:
            </h3>
            <asp:Literal ID="lblModoDePreparo" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
