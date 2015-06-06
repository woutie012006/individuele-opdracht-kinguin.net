<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GamesPage.aspx.cs" Inherits="kinguin_Clone.GamesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br>
    <br>
    <br>

    <div class="row text-center">


        <asp:ListView ID="GamesView" OnItemDataBound="GamesView_OnItemDataBound_ItemDataBound" runat="server">
            <ItemTemplate>

                <div class="col-md-3 col-sm-6 hero-feature">
                    <div class="thumbnail">
                        <asp:Image ID="IMGGame" runat="server" />
                        <div class="caption">
                            <h3><%# Eval("name") %></h3>
                            <p><%# Eval("description") %></p>
                            <h3></h3>
                            <p>
                                <asp:HyperLink ID="btnBuyNow" CssClass="btn btn-primary" runat="server" Text="Buy Now!" />
                                <asp:HyperLink ID="btnMoreInfo" runat="server" CssClass="btn btn-default" Text="More Info" />
                            </p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>

    </div>

</asp:Content>
