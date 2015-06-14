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
                                    <a href="#"><%#
                this.Eval("Name") %></a>
                                </h4>
                                <p><%#
                this.Eval("Description") %></p>
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
                                <%#
                this.Eval("CopyNr") %>
                                <span class="pull-right"><%#
                this.Eval("Price") %></span>

                                <asp:HyperLink ID="btnPutInCart" CssClass="btn btn-default" runat="server" Text="put in Cart"/>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:ListView>
            </div>

        </div>

    </div>

</asp:Content>