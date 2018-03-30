<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TelaPerfil.aspx.cs" Inherits="GastroHelp.WebUI.TelaPerfil" %>

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
                            <img class="img-circle" src="http://static1.purepeople.com.br/people/3/54/70/83/@/2263952-shawn-mendes-150x150-2.jpg" style="padding-top: 15px;">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label class="control-label" style="padding: 10px 0px;">john.doe@gmail.com</label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a href="#" style="color: #000000; font-family: Verdana; font-size: 16px;">MEU PERFIL</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-book" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a href="#" style="color: #000000; font-family: Verdana; font-size: 16px;">MINHAS RECEITAS</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-heart" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a href="#" style="color: #000000; font-family: Verdana; font-size: 16px;">MEUS FAVORITOS</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-cog" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a href="#" style="color: #000000; font-family: Verdana; font-size: 16px;">CONFIGURAÇÕES</a>
                </div>
            </div>
        </div>
        <div class="col-md-9" style="border: 1px solid gray;">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <h1 class="ingredients-title box-title">
                            <i class="glyphicon glyphicon-heart" aria-hidden="true"> FAVORITOS</i>
                        </h1>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <%--UM--%>
                            <div class="thumbnail">
                                <img class="img-responsive" src="Images/bolo-decorado-simples.jpg" />
                                <div class="caption">
                                    <h3>Bolo de banana</h3>
                                    <a href="#" class="btn btn-primary btn-block" role="button">Ver receita</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <%--DOIS--%>
                            <div class="thumbnail">
                                <img class="img-responsive" src="Images/bolo-decorado-simples.jpg" />
                                <div class="caption">
                                    <h3>Bolo de banana</h3>
                                    <a href="#" class="btn btn-primary btn-block" role="button">Ver receita</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <%--TRES--%>
                            <div class="thumbnail">
                                <img class="img-responsive" src="Images/bolo-decorado-simples.jpg" />
                                <div class="caption">
                                    <h3>Bolo de banana</h3>
                                    <a href="#" class="btn btn-primary btn-block" role="button">Ver receita</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-4">
                                <%--UM--%>
                                <div class="thumbnail">
                                    <img class="img-responsive" src="Images/bolo-decorado-simples.jpg" />
                                    <div class="caption">
                                        <h3>Bolo de banana</h3>
                                        <a href="#" class="btn btn-primary btn-block" role="button">Ver receita</a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <%--DOIS--%>
                                <div class="thumbnail">
                                    <img class="img-responsive" src="Images/bolo-decorado-simples.jpg" />
                                    <div class="caption">
                                        <h3>Bolo de banana</h3>
                                        <a href="#" class="btn btn-primary btn-block" role="button">Ver receita</a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <%--TRES--%>
                                <div class="thumbnail">
                                    <img class="img-responsive" src="Images/bolo-decorado-simples.jpg" />
                                    <div class="caption">
                                        <h3>Bolo de banana</h3>
                                        <a href="#" class="btn btn-primary btn-block" role="button">Ver receita</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
