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
        <%-- IMAGEM DA RECEITA --%>
        <div class="col-md-6">
            <img class="img-rounded img-responsive" src="Images/bacalhau.jpg" />
        </div>
    </div>
    <%-- FAVORITAR --%>
    <div class="row">
        <div class="col-md-12">
            <asp:LinkButton ID="btnFavoritar" runat="server" CssClass="btn btn-danger btn-circle btn-lg">
                 <span class="glyphicon glyphicon-heart" aria-hidden="true"></span> Favoritar</asp:LinkButton>
        </div>
    </div>
    <%-- INGREDIENTES --%>
    <div class="row">
        <div class="col-md-12">
            <h3 class="ingredients-title box-title">
                <span class="glyphicon glyphicon-cutlery" style="padding-right: 10px;"></span>INGREDIENTES:
            </h3>
            <asp:Literal ID="lblIngredientes" runat="server"></asp:Literal>
        </div>
    </div>
    <%-- MODO DE PREPARO --%>
    <div class="row">
        <div class="col-md-12" style="padding-bottom: 25px;">
            <h3 class="ingredients-title box-title">
                <span class="glyphicon glyphicon-cutlery" style="padding-right: 10px;"></span>MODO DE PREPARO:
            </h3>
            <asp:Literal ID="lblModoDePreparo" runat="server"></asp:Literal>
        </div>
    </div>
    <%-- COMENTÁRIO --%>
    <div class="row">
        <div class="col-md-12">
            <strong>Katheleen Alves</strong> <span class="text-muted">comentado há 5 de agosto</span>
            <img class="img-responsive user-photo" src="https://ssl.gstatic.com/accounts/ui/avatar_2x.png">
            <asp:TextBox ID="txtComentario" runat="server" Rows="5" CssClass="form-control" placeholder="Escreva aqui um comentário sobre a receita" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
</asp:Content>
