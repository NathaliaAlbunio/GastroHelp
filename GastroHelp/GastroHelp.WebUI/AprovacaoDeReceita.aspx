<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AprovacaoDeReceita.aspx.cs" Inherits="GastroHelp.WebUI.AprovacaoDeReceita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-12 text-center">
                    <h3>Receitas aguardando aprovação</h3>
                    <hr />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-12">
                    <asp:GridView ID="grdAprovacao" AutoGenerateColumns="false" Width="100%"
                        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="Nome Da Receuta">
                                <HeaderStyle Width="35%" />
                                <ItemStyle Width="35%" />
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkNome" runat="server" NavigateUrl='<%# ResolveUrl("~/TelaReceita.aspx?id=" + Eval("Id_Receita")) %>'
                                        Text='<%# Bind("Nome_Receita") %>' Style="color: #000000 !important;" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Categoria">
                                <HeaderStyle Width="50%" />
                                <ItemStyle Width="50%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCategoria" runat="server"
                                        Text='<%# Bind("Categoria.Nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                           <%-- <asp:TemplateField HeaderText="&nbsp;" ShowHeader="False">
                                <HeaderStyle Width="15%" CssClass="text-center" />
                                <ItemStyle Width="15%" CssClass="text-center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnAceitar" runat="server" Width="16px" Height="16px" ToolTip="Aceitar">
                                        <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="bntExcluir" runat="server" Width="16px" Height="16px" ToolTip="Aprovar">
                                        <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
    <%--<div class="w3-container">
                <div class="row">
                    <div class="col-md-3">
                        <img class="img-responsive" src="Images/dgfdsggfd.jpg" width="100%" />
                    </div>
                    <div class="col-md-9">
                        <h3>Bolo de Laranja da Tia Nath</h3>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                        </p>


                        <button class="btn btn-primary">
                            Ver mais...
                        </button>
                        <button class="btn btn-success">
                            Aprovar
                        </button>
                        <button class="btn btn-danger">
                            Recusar
                        </button>

                    </div>
                </div>
            </div>--%>
    <%--   <br />
            <div class="w3-container">
                <div class="row">
                    <div class="col-md-3">
                        <img class="img-responsive" src="Images/dgfdsggfd.jpg" width="100%" />
                    </div>
                    <div class="col-md-9">
                        <h3>Brigadeiro Fit de Banana</h3>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                        </p>

                        <p>
                            <button class="btn btn-primary">
                                Ver mais...
                            </button>
                            <button class="btn btn-success">
                                Aprovar
                            </button>
                            <button class="btn btn-danger">
                                Recusar
                            </button>

                        </p>
                    </div>
                </div>
            </div>--%>
</asp:Content>
