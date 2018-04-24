<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MinhaGeladeira.aspx.cs" Inherits="GastroHelp.WebUI.MinhaGeladeira" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" class="form-horizontal">
        <div class="row">
            <div class="col-md-12 text-center">
                <h3>MINHA GELADEIRA</h3>
                <hr />
            </div>
        </div>

        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Panel ID="pnlMsg" runat="server">
                    <p class="bg-danger" style="padding: 15px; font-weight: bold;">
                        <asp:Label ID="lblMsg" runat="server" />
                    </p>
                    <br />
                </asp:Panel>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6 text-center">
                <img src="<%= ResolveUrl("~/Images/geladeira2.png") %>" style="height: 450px;" />
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Ingredientes:</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group form-group-lg">
                            <div class="col-md-12">
                                <div class="input-group">
                                    <asp:TextBox ID="txtIngrediente" runat="server" CssClass="form-control" />
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="btnAdicionar" runat="server" CssClass="btn btn-danger btn-lg" OnClick="btnAdicionar_Click">
                                            <span class="glyphicon glyphicon-plus-sign" aria-hidden="true"></span>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="list-group">
                            <asp:Repeater ID="rptIngredientes" runat="server">
                                <ItemTemplate>
                                    <button type="button" class="list-group-item"><%# Container.DataItem %></button>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-danger btn-lg btn-block" OnClick="btnBuscar_Click">
                        <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                        Buscar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Panel ID="pnlReceitas" runat="server" Visible="false">
                    <h3 style="margin-top: 0px;">POSSÍVEIS RECEITAS...</h3>
                    <hr />
                </asp:Panel>
            </div>
        </div>

        <asp:Repeater ID="rptReceitas" runat="server" OnItemCommand="rptReceitas_ItemCommand">
            <ItemTemplate>
                <div class="row">
                    <div class="col-md-3">
                        <img class="img-responsive" src="<%# ResolveUrl(string.Format("~/Images/{0}", Eval("Foto"))) %>" />
                    </div>
                    <div class="col-md-9">
                        <h3><%# Eval("Nome_Receita") %></h3>
                        <p>
                            <%# Eval("Subtitulo") %>
                        </p>
                        <p>
                            <asp:LinkButton ID="btnVerMais" runat="server" CssClass="btn btn-danger" CommandName="VerMais" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id_Receita") %>'>
                                <span>Ver mais...</span>
                            </asp:LinkButton>
                        </p>
                    </div>
                </div>
                <hr />
            </ItemTemplate>
        </asp:Repeater>
    </form>
</asp:Content>
