<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TelaPerfil.aspx.cs" Inherits="GastroHelp.WebUI.TelaPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CssContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/TelaPerfil.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="gastrohelp"></div>
    <aside id="telainicial" class="sidebar sidebar-default open" role="navigation">

        <div class="sidebar-header header-cover" style="background-image: url(https://2.bp.blogspot.com/-2RewSLZUzRg/U-9o6SD4M6I/AAAAAAAADIE/voax99AbRx0/s1600/14%2B-%2B1%2B%281%29.jpg);">
            <div class="topo"></div>
            <button type="button" class="sidebar-toggle">
                <i class="icon-material-sidebar-arrow"></i>
            </button>
            <div class="imagemusuario">
                <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/53474/atom_profile_01.jpg">
            </div>
        </div>
    </aside>
    <h2 class="text-center">Favoritos</h2>
    <br />
    <div class="row">
        <div class="col-xs-6 col-md-3">
            <div class="thumbnail">
                <img class="img-responsive" src="Images/BoloDeBanana.jpg" />
                <div class="caption">
                    <h3>Bolo de banana</h3>
                    <a href="#" class="btn btn-primary" role="button">Ver receita</a>
                </div>
            </div>
            <div class="thumbnail">
                <img class="img-responsive" src="Images/BoloDeBanana.jpg" />
                <div class="caption">
                    <h3>Bolo de banana</h3>
                    <a href="#" class="btn btn-primary" role="button">Ver receita</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
