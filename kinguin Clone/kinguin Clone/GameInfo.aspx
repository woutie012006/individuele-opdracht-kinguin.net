<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameInfo.aspx.cs" Inherits="kinguin_Clone.GameInfo" %>

<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br>
    <br>
    <!-- Page Content -->
    <div class="container">

        <div class="row">
            <div class="col-md-9">
                <asp:ListView ID="GameView" OnItemDataBound="GamesView_OnItemDataBound_ItemDataBound" runat="server">
                    <ItemTemplate>

                        <div class="thumbnail">
                            <asp:Image ID="imgGame" CssClass="img-responsive" runat="server"/>
                            <div class="caption-full">
                                <h4>
                                    <a href="#"><%# Eval("name") %></a>
                                </h4>
                                <p><%# Eval("description") %></p>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:ListView>

                <br>
                <br>

                <asp:ListView ID="ObjectView" OnItemDataBound="ObjectView_OnItemDataBound" runat="server">
                    <ItemTemplate>

                        <div class="row">
                            <div class="col-md-12">
                                <%# Eval("copyNr") %>
                                <span class="pull-right"><%# Eval("price") %></span>

                                <asp:HyperLink ID="btnPutInCart" CssClass="btn btn-default" runat="server" Text="put in cart"/>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:ListView>
            </div>

        </div>

    </div>

</asp:Content>