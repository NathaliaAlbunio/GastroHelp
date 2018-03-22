<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MinhaGeladeira.aspx.cs" Inherits="GastroHelp.WebUI.MinhaGeladeira" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/MinhaGeladeira.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 align="center">MINHA GELADEIRA</h2>
    <div class="container-center">
        <div class="row">
            <div class="col-md-6">
                <h2>Tenho</h2>
                <table style="width: 100%">
                    <tr>
                        <th>Leite</th>
                    </tr>
                    <tr>
                        <th>Ovos</th>
                    </tr>
                    <tr>
                        <th>Achocolatado</th>
                    </tr>
                    <tr>
                        <th>Farinha</th>
                    </tr>

                </table>
            </div>
            <div class="col-md-6">
                <h2>Posso fazer...</h2>
                <table style="width: 100%">
                    <tr>
                        <th>Bolo de chocolate</th>

                    </tr>
                </table>
            </div>
        </div>

    </div>
</asp:Content>
