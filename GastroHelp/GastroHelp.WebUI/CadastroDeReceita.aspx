﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroDeReceita.aspx.cs" Inherits="GastroHelp.WebUI.CadastroDeReceita" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/CadastroDeReceita.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-12">
            <div class="main-login main-center">
                <h1><b>Cadastro de Receita</b></h1>
                <form class="form-horizontal center" runat="server">

                    <!-- NOME DA RECEITA -->
                    <div class="form-group">
                        <div class="col-md-8">
                            <label for="nomedareceita">Nome da Receita</label>
                            <asp:TextBox ID="txtNomeDaReceita" runat="server" CssClass="form-control" />
                        </div>
                    </div>

                    <%--  INGREDIENTES--%>
                    <div class="form-group">
                        <div class="col-md-8">
                            <label for="ingredientes control-label">Ingredientes</label>
                            <asp:TextBox ID="txtIngredientes" runat="server" CssClass="form-control" TextMode="MultiLine" />
                            <div class="col-md-4 alert alert-warning" role="alert">
                                Escreva um ingrediente por linha.
                                <br />
                                Não use hífen, numeração ou outro marcador para separar os ingredientes                                                                                             
                            </div>
                        </div>
                    </div>

                    <%--  PREPARO --%>
                        <div class="form-group">
                            <div class="col-md-8">
                                <label for="preparo control-label">Preparo</label>
                                <asp:TextBox ID="txtModoPreparo" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                <div class="col-md-4 alert alert-warning" role="alert">
                                    Escreva um passo por linha.
                                <br />
                                    Não use hífen, numeração ou outro marcador para separar os passos                                                                                              
                                </div>
                            </div>
                        </div>

                    <%-- NÍVEL DE DIFICULDADE --%>
                    <div class="form-group">
                        <div class="col-md-8">
                            <label for="nivel control-label">Nível de Dificuldade</label>
                            <br />
                            <asp:RadioButton ID="rbFacil" runat="server" GroupName="nivel" />
                            Fácil<br>
                            <asp:RadioButton ID="rbMedio" runat="server" GroupName="nivel" />
                            Médio<br>
                            <asp:RadioButton ID="rbDificil" runat="server" GroupName="nivel" />
                            Díficil
                        </div>
                    </div>

                    <%-- CATEGORIA --%>
                    <div class="form-group">
                        <div class="col-md-5">
                            <label for="categoria control-label">Categoria</label>
                            <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="Server">
                                <asp:ListItem Text="Doces" Value="doces" />
                                <asp:ListItem Text="Salgados" Value="salgados" />
                                <asp:ListItem Text="Assados" Value="assados" />
                                <asp:ListItem Text="Fritos" Value="fritos" />
                                <asp:ListItem Text="Cozidos" Value="cozidos" />
                            </asp:DropDownList>
                            <%-- <asp:Button Text="Selecione" OnClick="Selecao" runat="Server" />--%>
                        </div>
                    </div>

                    <%-- IMAGEM --%>
                    <div class="form-group">
                        <div class="col-md-8">
                            <label for="imagem control-label">Clique aqui para adicionar uma imagem!</label>
                            <input id="file" name="file" type="file" />
                        </div>
                    </div>
                    <%-- DICAS --%>
                    <div class="form-group">
                        <div class="col-md-8">
                            <label id="lblDicas" runat="server" cv="control-label">Dicas</label>
                            <asp:TextBox ID="txtDicas" runat="server" Rows="5" CssClass="form-control" placeholder="Deixe aqui dicas para o preparo dessa receita" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                    <%-- RENDIMENTO --%>
                    <div class="form-group">
                        <div class="col-md-1">
                            <label for="rendimento control-label">Rendimento</label>
                            <asp:TextBox ID="txtRendimento" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Porções</h5>
                        </div>

                    </div>

                    <%-- BOTÃO --%>
                    <div id=".botaodecoração">
                        <div class="form-group">
                            <div class="col-md-1">
                                <asp:Button ID="btnCadastrarReceita" runat="server" type="button" class="btn btn-warning" Text="Cadastrar Receitar" OnClick="btnCadastrar_Click" />
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
