<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GastroHelp.WebUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-responsive">
        <asp:DataList ID="gridView" CssClass="table" runat="server" RepeatColumns="4" RepeatLayout="Table">
            <ItemTemplate>
                <div class="row">
                    <div class="col-md-12 text-center">
                        <div class="row">
                            <div class="col-md-12">
                                <img class="img-responsive" src="Images/Cerejas.jpg" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <h3>Teste</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <h4>Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.</h4>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>

</asp:Content>
