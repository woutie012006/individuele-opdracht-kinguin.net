﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="kinguin_Clone.Register" EnableEventValidation="false" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>

<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <form class="form-horizontal text-center">
        <h2>Register</h2>
        <br>

        <asp:Label runat="server" Text="Name" CssClass="col-lg-2 control-label"></asp:Label><br>
        <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbName" runat="server" ErrorMessage="Name is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="Adres"></asp:Label><br>
        <asp:TextBox ID="tbAdres" runat="server" CssClass="form-control"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbAdres" runat="server" ErrorMessage="Adres is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="Telephone Number"></asp:Label><br>
        <asp:TextBox ID="tbTelNr" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbTelNr" runat="server" ErrorMessage="Telephone number is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="E-mail"></asp:Label><br>
        <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbEmail" runat="server" ErrorMessage="Email is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="Nickname"></asp:Label><br>
        <asp:TextBox ID="tbNickname" runat="server" CssClass="form-control"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbNickname" runat="server" ErrorMessage="Nickname is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="Password"></asp:Label><br>
        <asp:TextBox ID="tbPassword1" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbPassword1" runat="server" ErrorMessage="Password is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="Re-enter Password"></asp:Label><br>
        <asp:TextBox ID="tbPassword2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbPassword2" runat="server" ErrorMessage="Password is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>
        <asp:CompareValidator runat="server" ErrorMessage="Passwords don't match" ControlToValidate="tbPassword1" ControlToCompare="tbPassword2"></asp:CompareValidator>

        <br>
        <br>

        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-default" OnClick="btnSubmit_OnClick"/>

    </form>

</asp:Content>