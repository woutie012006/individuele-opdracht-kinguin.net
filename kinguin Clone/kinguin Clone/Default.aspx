<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="kinguin_Clone._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="jumbotron" class="jumbotron alert alert-dismissible alert-info" runat="server">
        <br>
        <a href="GamesPage.aspx"><asp:Image ID="imgJumbotron"  runat="server" Width="100%" /></a>
        <br>
        <br>
      
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Kinguin gives you more for less</h2>
            <p>
               Kinguin.net has been a market leader for years and will be for years to come, with our razersharp prices and our awesome website. We will rule
                over everyone who dares to defy us. You shall buy from  kinguin.net, for we are the best.

            </p>
            <p>
                <a class="btn btn-default" href="http://kinguin.net">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Our games</h2>
            <p>
                Want to get some sweet games, say no more we have everything, so click down below and feast your eyes.
            </p>
            <p>
                <a class="btn btn-default" href="/GamesPage.aspx">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Asp.net</h2>
            <p>
               This awesome page was created in ASP.NET, want to find out more, click down below.
            </p>
            <p>
                <a class="btn btn-default" href="http://www.ASP.NET">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>