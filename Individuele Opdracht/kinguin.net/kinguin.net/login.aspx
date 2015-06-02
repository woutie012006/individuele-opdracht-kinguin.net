<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="kinguin.net.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
 <div style="display:flex;justify-content:center;align-items:center; margin-top: 20%; margin-bottom: 20%;">
    <asp:Login ID="LoginForm" runat="server" OnAuthenticate="LoginForm_OnAuthenticate"></asp:Login>   
 </div>
</asp:Content>
