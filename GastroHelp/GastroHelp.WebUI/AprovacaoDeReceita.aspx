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
                                <HeaderStyle Width="40%" />
                                <ItemStyle Width="40%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCategoria" runat="server"
                                        Text='<%# Bind("Categoria.Nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Publicada?">
                                <HeaderStyle Width="10%" CssClass="text-center" />
                                <ItemStyle Width="10%" CssClass="text-center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAceita" runat="server"
                                        Text='<%# Bind("EstaAceita") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&nbsp;" ShowHeader="False">
                                <HeaderStyle Width="15%" CssClass="text-center" />
                                <ItemStyle Width="15%" CssClass="text-center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnAceitar" runat="server" Width="16px" Height="16px" ToolTip="Editar" OnClick="btnAceitar_Click" CommandArgument='<%# Eval("Id_Receita") %>'> 
                                        <span class="glyphicon glyphicon-ok" aria-hidden="true" style="color: #000000 !important;"></span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnExcluir" runat="server" Width="16px" Height="16px" ToolTip="Excluir" OnClick="bntExcluir_Click" CommandArgument='<%# Eval("Id_Receita") %>' OnClientClick='if (!confirm("Deseja realmente remover este registro?")) return false;'>
                                        <span class="glyphicon glyphicon-remove" aria-hidden="true" style="color: #000000 !important;"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>