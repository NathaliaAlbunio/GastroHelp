﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="CadastroDeReceita.aspx.cs" Inherits="GastroHelp.WebUI.CadastroDeReceita" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/CadastroDeReceita.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="background-color: white;">
        <div class="col-md-8 col-md-offset-2">
            <div class="main-login">
                <h1><b>Cadastro de Receita</b></h1>
                <asp:Panel ID="pnlMsg" runat="server" Visible="false">
                    <div class="form-group">
                        <div class="col-md-12 text-center">
                            <div class="alert alert-danger" role="alert">
                                <asp:Label ID="lblMsg" runat="server" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <!-- NOME DA RECEITA -->
                <div class="form-group">
                    <div class="col-md-12">
                        <label for="nomedareceita">Nome da Receita</label>
                        <asp:TextBox ID="txtNomeDaReceita" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <%--  INGREDIENTES--%>
                <div class="form-group">
                    <div class="col-md-12">
                        <label for="ingredientes control-label">Ingredientes</label>
                        <asp:TextBox ID="txtIngredientes" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Escreva aqui os ingredientes um por linha, e depois selecione a opção de marcadores para que fique em tópicos " />
                    </div>
                </div>

                <%--  PREPARO --%>
                <div class="form-group">
                    <div class="col-md-12">
                        <label for="preparo control-label">Preparo</label>
                        <asp:TextBox ID="txtModoPreparo" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Escreva aqui os passos um por linha, e depois selecione a opção de marcadores numerados para que fique em tópicos "></asp:TextBox>
                    </div>
                </div>

                <%-- NÍVEL DE DIFICULDADE --%>
                <div class="form-group">
                    <div class="col-md-12">
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
                    <div class="col-md-12">
                        <label for="categoria control-label">Categoria</label>
                        <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="Server">
                            <asp:ListItem Text="Doces" Value="doces" />
                            <asp:ListItem Text="Salgados" Value="salgados" />
                            <asp:ListItem Text="Assados" Value="assados" />
                            <asp:ListItem Text="Fritos" Value="fritos" />
                            <asp:ListItem Text="Cozidos" Value="cozidos" />
                        </asp:DropDownList>
                    </div>
                </div>

                <%-- IMAGEM --%>
                <div class="form-group">
                    <div class="col-md-12">
                        <asp:FileUpload ID="fupArquivo" runat="server" />
                    </div>
                </div>

                <%-- RESUMO --%>
                <div class="form-group">
                    <div class="col-md-12">
                        <label id="lblResumo" runat="server" cv="control-label">Resumo</label>
                        <asp:TextBox ID="txtResumo" runat="server" Rows="5" CssClass="form-control"
                            placeholder="Escreva um breve resumo da sua receita. Exemplo: Esse bolo é feito com muito amor e chocolate "
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>

                <%-- DICAS --%>
                <div class="form-group">
                    <div class="col-md-12">
                        <label id="lblDicas" runat="server" cv="control-label">Dicas</label>
                        <asp:TextBox ID="txtDicas" runat="server" Rows="5" CssClass="form-control"
                            placeholder="Deixe aqui dicas para o preparo dessa receita" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>

                <%-- RENDIMENTO --%>
                <div class="form-group">
                    <div class="col-md-12">
                        <label for="rendimento control-label">Rendimento</label>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtRendimento" runat="server" CssClass="form-control" Width="50px"></asp:TextBox>
                                </td>
                                <td style="padding-left: 10px;">
                                    <span>Porções</span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <%-- BOTÃO --%>
                <div id=".botaodecoração">
                    <div class="form-group">
                        <div class="col-md-12">
                            <asp:Button ID="btnCadastrarReceita" runat="server" type="button" class="btn btn-danger"
                                Text="Cadastrar Receitar" OnClick="btnCadastrar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtIngredientes").cleditor({ height: 250 });
            $("#MainContent_txtModoPreparo").cleditor({ height: 250 });
        });
    </script>
</asp:Content>
