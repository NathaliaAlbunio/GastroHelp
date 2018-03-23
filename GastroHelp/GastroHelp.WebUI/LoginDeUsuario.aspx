<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginDeUsuario.aspx.cs" Inherits="GastroHelp.WebUI.LoginDeUsuario" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/login.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row main">
        <div class="main-login main-center">
            <h5><b>Bem-vindo de volta ao GastroHelp®</b></h5>
            <form runat="server" method="post" action="#">
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
                    <a>Criar conta</a> ou <a>Recuperar senha</a>
                    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btn btn-default btn-lg btn-block login-button" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
