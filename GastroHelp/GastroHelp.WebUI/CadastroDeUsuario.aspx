<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroDeUsuario.aspx.cs" Inherits="GastroHelp.WebUI.CadastroDeUsuario" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/Cadastro.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row main">
        <div class="main-login main-center">
            <h5><b>Cadastre-se no GastroHelp® é grátis</b></h5>
            <form runat="server" method="post" action="#">
                <!-- NOME -->
                <div class="form-group">
                    <label for="name" class="cols-sm-2 control-label">Seu Nome</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user" aria-hidden="true"></i></span>
                            <%--<input type="text" class="form-control" name="name" id="name" placeholder="Digite seu nome" />--%>
                            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" placeholder="Digite seu nome" />
                        </div>
                    </div>
                </div>
                <!-- E-MAIL -->
                <div class="form-group">
                    <label for="email" class="cols-sm-2 control-label">Seu E-mail</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-envelope" aria-hidden="true"></i></span>
                            <asp:TextBox ID="Txtemail" runat="server" CssClass="form-control" placeholder="Digite seu e-mail" />
                        </div>
                    </div>
                </div>
                <!-- NOME DE USUÁRIO -->
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
                <!-- CONFIRME SUA SENHA -->
                <div class="form-group">
                    <label for="confirm" class="cols-sm-2 control-label">Confirme sua senha</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock" aria-hidden="true"></i></span>
                            <asp:TextBox ID="TxtConfirmarSenha" runat="server" CssClass="form-control" placeholder="Digite sua senha novamente" type="password" />
                        </div>
                    </div>
                </div>

                <div class="form-group ">
                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-default btn-lg btn-block login-button" OnClick="btnCadastrar_Click" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
