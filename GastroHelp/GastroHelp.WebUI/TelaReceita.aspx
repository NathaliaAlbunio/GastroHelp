﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TelaReceita.aspx.cs" Inherits="GastroHelp.WebUI.TelaReceita" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
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
        <div class="col-md-6 text-center">
            <img id="imgRec" runat="server" class="img-rounded" style="height: 300px;" />
        </div>
    </div>
    <%-- FAVORITAR --%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:LinkButton ID="btnFavoritar" runat="server" CssClass="btn btn-danger btn-circle" OnClick="btnFavoritar_Click">
                 <span class="glyphicon glyphicon-heart" aria-hidden="true"></span> Favoritar
            </asp:LinkButton>
        </div>
    </div>
    <%-- INGREDIENTES --%>
    <div class="form-group">
        <div class="col-md-12">
            <h3 class="ingredients-title box-title">
                <span class="glyphicon glyphicon-cutlery" style="padding-right: 10px;"></span>INGREDIENTES:
            </h3>
            <asp:Literal ID="lblIngredientes" runat="server"></asp:Literal>
        </div>
    </div>
    <%-- MODO DE PREPARO --%>
    <div class="form-group">
        <div class="col-md-12" style="padding-bottom: 25px;">
            <h3 class="ingredients-title box-title">
                <span class="glyphicon glyphicon-cutlery" style="padding-right: 10px;"></span>MODO DE PREPARO:
            </h3>
            <asp:Literal ID="lblModoDePreparo" runat="server"></asp:Literal>
        </div>
    </div>
    <%-- COMENTÁRIO --%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:TextBox ID="txtComentario" runat="server" Rows="5" CssClass="form-control" placeholder="Deixe aqui seu comentário" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-danger" Text="Enviar" OnClick="btnEnviar_Click" />
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-12">
            <asp:DataList ID="gridViewComentario" CssClass="table text-center" runat="server" RepeatColumns="1" RepeatLayout="Table">
                <ItemTemplate>
                    <div class="form-group">
                        <div class="col-md-2">
                            <img class="img-circle" src="Images/profile.png" style="width: 100px;" />
                        </div>
                        <div class="col-md-10 text-left">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <label><%# Eval("Usuario.Nome") %></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <label><%# Eval("DataHora") %></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <span><%# Eval("texto") %></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
