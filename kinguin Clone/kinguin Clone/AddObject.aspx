<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddObject.aspx.cs" Inherits="kinguin_Clone.AddObject" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>

<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br><br>

    <asp:Label runat="server" Text="Name" CssClass="col-lg-2 control-label"></asp:Label><br>
    <asp:DropDownList ID="ddlGame" runat="server"></asp:DropDownList><br>
    <asp:RequiredFieldValidator ControlToValidate="ddlGame" runat="server" ErrorMessage="Game was not entered" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

    <%--<asp:Label runat="server" Text="Name" CssClass="col-lg-2 control-label"></asp:Label><br>
    <asp:DropDownList ID="ddlCount" runat="server"></asp:DropDownList><br>
    <asp:RequiredFieldValidator ControlToValidate="ddlCount" runat="server" ErrorMessage="Game was not entered" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>--%>

    <asp:Label runat="server" Text="Price" CssClass="col-lg-2 control-label"></asp:Label><br>
    <asp:TextBox ID="tbPrice" runat="server" TextMode="Number"></asp:TextBox></br>
    <asp:RequiredFieldValidator runat="server" ErrorMessage="Price is empty" ControlToValidate="tbPrice" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

    <asp:Label runat="server" Text="Code" CssClass="col-lg-2 control-label"></asp:Label><br>
    <asp:TextBox ID="tbCode" runat="server" TextMode="Number"></asp:TextBox><br>
    <asp:RequiredFieldValidator runat="server" ErrorMessage="Code is empty" ControlToValidate="tbCode" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_OnClick"/>
</asp:Content>