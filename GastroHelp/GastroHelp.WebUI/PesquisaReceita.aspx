<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PesquisaReceita.aspx.cs" Inherits="GastroHelp.WebUI.PesquisaReceita" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 text-center">
            <asp:Panel ID="pnlReceitasPesq" runat="server" Visible="false">
                <h3 style="margin-top: 0px;">POSSÍVEIS RECEITAS...</h3>
                <hr />
            </asp:Panel>
        </div>
    </div>
    <asp:Repeater ID="rptReceitasPesq" runat="server" OnItemCommand="rptReceitasPesq_ItemCommand">
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
                        <asp:LinkButton ID="btnVerMaisPesq" runat="server" CssClass="btn btn-danger" CommandName="VerMais" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id_Receita") %>'>
                            <span>Ver mais...</span>
                        </asp:LinkButton>
                    </p>
                </div>
            </div>
            <hr />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

