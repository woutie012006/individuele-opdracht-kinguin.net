<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="kinguin_Clone.UserPage" %>
<%@ MasterType virtualpath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <asp:Label ID="lblName" runat="server" Text="Name : "></asp:Label>
    <asp:Label ID="lblAdres" runat="server" Text="Adres : "></asp:Label>
    <asp:Label ID="lblPhonenr" runat="server" Text="Phone number : "></asp:Label>
    <asp:Label ID="lblKinguinBalance" runat="server" Text="Kinguin Balace : "></asp:Label>



    <asp:HyperLink ID="hlChangeUserinfo" runat="server">Verander uw gebruikersinfo</asp:HyperLink>
    <asp:HyperLink ID="hlAddGame" runat="server">Voeg een game toe</asp:HyperLink>
    <asp:HyperLink ID="hlAddObject" runat="server">Voeg een verkoopobject toe</asp:HyperLink>

</asp:Content>
