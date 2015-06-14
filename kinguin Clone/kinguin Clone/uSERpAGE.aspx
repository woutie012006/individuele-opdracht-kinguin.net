<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="kinguin_Clone.UserPage" %>
<%@ MasterType virtualpath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <asp:Label ID="lblName" runat="server" Text="Name : "></asp:Label><br>
    <asp:Label ID="lblAdres" runat="server" Text="Adres : "></asp:Label><br>
    <asp:Label ID="lblPhonenr" runat="server" Text="Phone number : "></asp:Label><br>
    <asp:Label ID="lblKinguinBalance" runat="server" Text="Kinguin Balace : "></asp:Label><br>
    <br><br><br>


    <asp:HyperLink ID="hlChangeUserinfo" runat="server" NavigateUrl="ChangeUserInfo.aspx" Visible="False">Change UserInfo</asp:HyperLink><br>
    <asp:HyperLink ID="hlAddGame" runat="server" NavigateUrl="AddGame.aspx" Visible="False">Add a game</asp:HyperLink><br>
    <asp:HyperLink ID="hlAddObject" runat="server" NavigateUrl="AddObject.aspx" Visible="False">Add Selling object</asp:HyperLink><br>

</asp:Content>