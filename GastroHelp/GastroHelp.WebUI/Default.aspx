<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GastroHelp.WebUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
            border: none !important;
            width: 25%;
        }
    </style>
    <asp:DataList ID="gridView" CssClass="table text-center" runat="server" RepeatColumns="4" RepeatLayout="Table">
        <ItemTemplate>
            <div class="row">
                <div class="col-md-12">
                    <a href="<%# ResolveUrl(string.Format("~/TelaReceita.aspx?id={0}", Eval("Id_Receita"))) %>">
                        <img class="img-responsive" style="border:solid"  width:"250px"  height:"300px" src="<%# ResolveUrl((string)Eval("FotoUrl")) %>" />
                    </a>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <a href="<%# ResolveUrl(string.Format("~/TelaReceita.aspx?id={0}", Eval("Id_Receita"))) %>" style="color: #000000 !important;">
                        <h3 style="color: #000000 !important;"><%# Eval("Nome_Receita") %></h3>
                    </a>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h4><%# Eval("Subtitulo") %></h4>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
