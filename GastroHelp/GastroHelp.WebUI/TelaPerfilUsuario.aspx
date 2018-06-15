<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TelaPerfilUsuario.aspx.cs" Inherits="GastroHelp.WebUI.TelaPerfil" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3" style="border: 1px solid gray;">
            <div class="row">
                <div class="col-md-12 text-center">
                    <img class="img-circle" src="Images/profile.png" style="padding-top: 15px;">
                </div>
            </div>
            <div class="row" style="border-bottom: 1px solid gray; padding: 10px 0px 10px 0px;">
                <div class="col-md-12 text-center">
                    <asp:Label ID="lblNomeUsuario" runat="server" class="control-label" />
                </div>
            </div>
            <div class="row" style="padding: 20px 0px; border-bottom: 1px solid gray;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a style="color: #000000 !important;" href="#">MEU PERFIL</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px; border-bottom: 1px solid gray;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-book" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a style="color: #000000 !important;" href="#">MINHAS RECEITAS</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px; border-bottom: 1px solid gray;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-heart" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a style="color: #000000 !important;" href="#">MEUS FAVORITOS</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-cog" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a style="color: #000000 !important;" href="#">CONFIGURAÇÕES</a>
                </div>
            </div>
        </div>
        <div class="col-md-9">
            <div class="row">
                <div class="col-md-12">
                    <h4>
                        <i class="glyphicon glyphicon-heart" aria-hidden="true"></i>
                        MINHAS RECEITAS
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="grdMinhasReceitas" runat="server" AutoGenerateColumns="false" Width="100%"
                        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
                        <Columns>
                            <asp:TemplateField HeaderText="Nome">
                                <HeaderStyle Width="70%" />
                                <ItemStyle Width="70%" />
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkNome" runat="server" NavigateUrl='<%# ResolveUrl("~/TelaReceita.aspx?id=" + Eval("Id_Receita")) %>'
                                        Text='<%# Bind("Nome_Receita") %>' Style="color: #000000 !important;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Categoria">
                                <HeaderStyle Width="30%" />
                                <ItemStyle Width="30%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCategoria" runat="server"
                                        Text='<%# Bind("Categoria.Nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-md-12">
                    <h4>
                        <i class="glyphicon glyphicon-list" aria-hidden="true"></i>
                        FAVORITOS
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="grdMeusFavoritos" runat="server" AutoGenerateColumns="false" Width="100%"
                        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
                        <Columns>
                            <asp:TemplateField HeaderText="Nome">
                                <HeaderStyle Width="70%" />
                                <ItemStyle Width="70%" />
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkNome" runat="server" NavigateUrl='<%# ResolveUrl("~/TelaReceita.aspx?id=" + Eval("Id_Receita")) %>'
                                        Text='<%# Bind("Nome_Receita") %>' Style="color: #000000 !important;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Categoria">
                                <HeaderStyle Width="30%" />
                                <ItemStyle Width="30%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCategoria" runat="server"
                                        Text='<%# Bind("Categoria.Nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
