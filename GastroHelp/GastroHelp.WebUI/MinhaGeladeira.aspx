<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MinhaGeladeira.aspx.cs" Inherits="GastroHelp.WebUI.MinhaGeladeira" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 text-center">
            <h3>MINHA GELADEIRA</h3>
            <hr />
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
                    <form class="form-horizontal">
                        <div class="form-group form-group-lg">
                            <div class="col-md-12">
                                <div class="input-group">
                                    <input type="text" class="form-control">
                                    <div class="input-group-btn">
                                        <button class="btn btn-danger btn-lg">
                                            <span class="glyphicon glyphicon-plus-sign" aria-hidden="true"></span>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="list-group">
                        <button type="button" class="list-group-item">Brownie de Chocolate</button>
                        <button type="button" class="list-group-item">Dapibus ac facilisis in</button>
                        <button type="button" class="list-group-item">Morbi leo risus</button>
                        <button type="button" class="list-group-item">Porta ac consectetur ac</button>
                        <button type="button" class="list-group-item">Vestibulum at eros</button>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <button class="btn btn-danger btn-lg btn-block">
                        <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                        Buscar
                    </button>
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-12 text-center">
            <h3 style="margin-top: 0px;">POSSÍVEIS RECEITAS...</h3>
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <img class="img-responsive" src="<%= ResolveUrl("~/Images/dgfdsggfd.jpg") %>" />
        </div>
        <div class="col-md-9">
            <h3>Bolo de Laranja</h3>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </p>
            <p>
                <button class="btn btn-danger">
                    Ver mais...
                </button>
            </p>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-3">
            <img class="img-responsive" src="Images/dgfdsggfd.jpg" />
        </div>
        <div class="col-md-9">
            <h3>Bolo de Laranja</h3>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </p>
            <p>
                <button class="btn btn-danger">
                    Ver mais...
                </button>
            </p>
        </div>
    </div>
    <hr />
</asp:Content>
