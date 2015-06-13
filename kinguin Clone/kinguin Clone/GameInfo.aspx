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
                            <asp:Image ID="imgGame" CssClass="img-responsive" runat="server" />
                            <div class="caption-full">
                                <%--<h4 class="pull-right"><%# Eval("price") %></h4>   needs an extra function to get the average prce point or max and min.--%>
                                <h4><a href="#"><%# Eval("name") %></a></h4>
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
                                <%# Eval("copyNr") %>>
                            <span class="pull-right"><%# Eval("price") %></span>
                                <%--<p>This product was great in terms of quality. I would definitely buy another!</p>--%>
                               <%-- <asp:Button ID="btnPutInCart" runat="server" Text="Put in cart" />--%>
                                <asp:HyperLink ID="btnPutInCart" CssClass="btn btn-default" runat="server" Text ="put in cart"/>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:ListView>

                <!-- reviews-->
                <%--<div class="well">
                <hr>

                <div class="row">
                    <div class="col-md-12">
                        <span class="glyphicon glyphicon-star"></span>
                        <span class="glyphicon glyphicon-star"></span>
                        <span class="glyphicon glyphicon-star"></span>
                        <span class="glyphicon glyphicon-star"></span>
                        <span class="glyphicon glyphicon-star-empty"></span>
                        Anonymous
                            <span class="pull-right">10 days ago</span>
                        <p>This product was great in terms of quality. I would definitely buy another!</p>
                    </div>
                </div>

                <hr>

                <div class="row">
                    <div class="col-md-12">
                        <span class="glyphicon glyphicon-star"></span>
                        <span class="glyphicon glyphicon-star"></span>
                        <span class="glyphicon glyphicon-star"></span>
                        <span class="glyphicon glyphicon-star"></span>
                        <span class="glyphicon glyphicon-star-empty"></span>
                        Anonymous
                            <span class="pull-right">12 days ago</span>
                        <p>I've alredy ordered another one!</p>
                    </div>
                </div>

                <hr>

                <div class="row">
                    <div class="col-md-12">
                        <span class="glyphicon glyphicon-star"></span>
                        <span class="glyphicon glyphicon-star"></span>
                        <span class="glyphicon glyphicon-star"></span>
                        <span class="glyphicon glyphicon-star"></span>
                        <span class="glyphicon glyphicon-star-empty"></span>
                        Anonymous
                            <span class="pull-right">15 days ago</span>
                        <p>I've seen some better than this, but not at this price. I definitely recommend this item.</p>
                    </div>
                </div>

            </div>--%>
            </div>

        </div>

    </div>
    <!-- /.container -->

</asp:Content>
