<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TelaPerfilAdm.aspx.cs" Inherits="GastroHelp.WebUI.TelaPerfilAdm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CssContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/TelaPerfilAdm.css") %>" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3" style="border: 1px solid gray;">
            <div class="row" style="background-image: url(https://pt.aliexpress.com/item/Allenjoy-photo-background-Light-gray-bubbles-shiny-bright-baby-backgrounds-for-photo-studio-foto-background/32779029108.html);">
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
                    <a href="#" style="font-family: Verdana; font-size: 16px;">MEU PERFIL</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-book" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a href="#" style="font-family: Verdana; font-size: 16px;">MINHAS RECEITAS</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-heart" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a href="#" style="font-family: Verdana; font-size: 16px;">MEUS FAVORITOS</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-cog" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a href="#" style="font-family: Verdana; font-size: 16px;">CONFIGURAÇÕES</a>
                </div>
            </div>
            <div class="row" style="padding: 20px 0px;">
                <div class="col-md-2">
                    <span class="glyphicon glyphicon-cog" aria-hidden="true"></span>
                </div>
                <div class="col-md-10">
                    <a href="#" style="font-family: Verdana; font-size: 16px;">CONFIGURAÇÕES</a>
                </div>
            </div>
        </div>

        <form runat="server" >
        <div class="col-md-9" style="border: 1px solid gray;">
            <div class="col-lg-12">
                <asp:GridView ID="grdReceitasAprovacao" runat="server" 
                    AutoGenerateColumns="false"
                    Width="100%" CssClass="Grid"
                    AlternatingRowStyle-CssClass="alt"
                    PagerStyle-CssClass="pgr" style="vertical-align: baseline">
                    <Columns>
                        <asp:TemplateField HeaderText="Nome">
                            <HeaderStyle Width="20%" />
                            <ItemStyle Width="20%" />
                            <ItemTemplate>
                                <asp:HyperLink ID="lblNome" runat="server" 
                                    Text='<%# Bind("Nome_Receita") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Usuario">
                            <HeaderStyle Width="20%" />
                            <ItemStyle Width="20%" />
                            <ItemTemplate>
                                <asp:HyperLink ID="lblUsuario" runat="server" 
                                    Text='<%# Bind("Usuario.Nome") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                   
                    </Columns>
                </asp:GridView>
            </div>
        </div>
            </form>
    </div>
</asp:Content>

