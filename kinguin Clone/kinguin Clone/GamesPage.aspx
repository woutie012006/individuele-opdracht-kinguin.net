<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GamesPage.aspx.cs" Inherits="Kinguin_Clone.GamesPage" %>
<%@ MasterType virtualpath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br>
    <br>
    <br>

    <div class="row text-center">


        <asp:ListView ID="GamesView" OnItemDataBound="GamesView_OnItemDataBound_ItemDataBound" runat="server">
            <ItemTemplate>

                <div class="col-md-3 col-sm-6 hero-feature">
                    <div class="thumbnail">
                        <asp:Image ID="IMGGame" runat="server"/>
                        <div class="caption">
                            <h3><%# Eval("Name") %></h3>
                            <p><%# Eval("Description") %></p>
                            <h3></h3>
                            <p>
                                <%--<asp:HyperLink ID="btnBuyNow" CssClass="btn btn-primary" runat="server" Text="Buy Now!" />--%>
                                <asp:HyperLink ID="btnMoreInfo" CssClass="btn btn-default" runat="server" Text="More Info"/>
                            </p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>

    </div>

</asp:Content>