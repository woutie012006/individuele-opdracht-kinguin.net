<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddObject.aspx.cs" Inherits="Kinguin_Clone.AddObject" %>

<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Label runat="server" Text="Name" CssClass="col-lg-2 control-label"></asp:Label><br>
    <asp:DropDownList ID="ddlGame" runat="server"></asp:DropDownList><br>
    <asp:RequiredFieldValidator ControlToValidate="ddlGame" runat="server" ErrorMessage="Game was not entered" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

    <%--<asp:Label runat="server" Text="Name" CssClass="col-lg-2 control-label"></asp:Label><br>
    <asp:DropDownList ID="ddlCount" runat="server"></asp:DropDownList><br>
    <asp:RequiredFieldValidator ControlToValidate="ddlCount" runat="server" ErrorMessage="Game was not entered" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>--%>

    <asp:Label runat="server" Text="Price" CssClass="col-lg-2 control-label"></asp:Label><br>
    <asp:TextBox ID="tbPrice" runat="server" TextMode="Number"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ErrorMessage="Price is empty" ControlToValidate="tbPrice" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator>

    <asp:Label runat="server" Text="Code" CssClass="col-lg-2 control-label"></asp:Label><br>
    <asp:TextBox ID="tbCode" runat="server" TextMode="Number"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ErrorMessage="Code is empty" ControlToValidate="tbCode" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator>

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick=""/>
</asp:Content>