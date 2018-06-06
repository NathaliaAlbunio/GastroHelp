<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TelaPerfilUsuario.aspx.cs" Inherits="GastroHelp.WebUI.TelaPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CssContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/TelaPerfil.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3" style="border: 1px solid gray;">
            <div class="row" style="background-image: url(https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRwj9HkjgeHc5mQLAv95KkZmgwydo4cvirG0L97Z3-atlqJ_7T7wA);">
                <div class="col-md-12 text-center">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-circle" src="Images/profile.png" style="padding-top: 15px;">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label class="control-label" style="padding: 10px 0px;">u@gmail.com</label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a href="#" font-family: Verdana; font-size: 16px;">MEU PERFIL</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-book" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a href="#"  font-family: Verdana; font-size: 16px;">MINHAS RECEITAS</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-heart" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a href="#" font-family: Verdana; font-size: 16px;">MEUS FAVORITOS</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-cog" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a href="#"  font-family: Verdana; font-size: 16px;">CONFIGURAÇÕES</a>
                </div>
            </div>
        </div>
        <%--Favoritos--%>
        <div class="col-md-9" style="border: 1px solid gray;">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <h1 class="ingredients-title box-title">
                            <i class="glyphicon glyphicon-heart" aria-hidden="true">FAVORITOS</i>
                        </h1>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-9">
            <asp:DataList ID="dgwfavorito" CssClass="table 0-center" runat="server" RepeatColumns="4" RepeatLayout="Table">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <a href="<%# ResolveUrl(string.Format("~/TelaReceita.aspx?id={0}", Eval("Id_Receita"))) %>">
                                <img class="img-responsive" src="<%# ResolveUrl((string)Eval("FotoUrl")) %>" />
                            </a>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-12">
                                <a href="<%# ResolveUrl(string.Format("~/TelaReceita.aspx?id={0}", Eval("Id_Receita"))) %>" style="color: #000000 !important;">
                                    <h3 style="color: #000000 !important;"><%# Eval("Nome_Receita") %></h3>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h4><%# Eval("Subtitulo") %></h4>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
