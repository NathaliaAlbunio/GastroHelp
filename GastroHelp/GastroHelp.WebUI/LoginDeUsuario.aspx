<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginDeUsuario.aspx.cs" Inherits="GastroHelp.WebUI.LoginDeUsuario" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/login.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row main">
        <div class="main-login main-center">
            <h5><b>Bem-vindo de volta ao GastroHelp®</b></h5>
            <form class="form-horizontal" runat="server" action="#">
                <!--NOME DE USUÁRIO-->
                <div class="form-group">
                    <label for="username" class="cols-sm-2 control-label">Nome de Usuário</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user" aria-hidden="true"></i></span>
                            <asp:TextBox ID="TxtNomeUsuario" runat="server" CssClass="form-control" placeholder="Digite seu nome de usuário" />

                        </div>
                    </div>
                </div>
                <!-- SENHA -->
                <div class="form-group">
                    <label for="password" class="cols-sm-2 control-label">Senha</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock" aria-hidden="true"></i></span>
                            <asp:TextBox ID="TxtSenha" runat="server" CssClass="form-control" placeholder="Digite sua senha" type="password" />
                        </div>
                    </div>
                </div>
                <!-- ENTRAR -->
                <div class="form-group">
                    <div class="col-md-12 text-center">
                        <a href="<%= ResolveUrl("~/CadastroDeUsuario.aspx") %>" style="color: white; text-align: center;">Criar conta</a> ou <a style="color: white">Recuperar senha</a>
                    </div>
                </div>
                <%--<div class="form-group">
                    <div class="col-md-12 text-center">
                        <asp:CheckBox ID="ckLembrarSenha" runat="server" />
                        Lembrar senha
                    </div>
                </div>--%>
                <div class="form-group">
                    <div class="col-md-12 text-center">
                        <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btn btn-default btn-lg btn-block login-button" OnClick="btnEntrar_Click" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>