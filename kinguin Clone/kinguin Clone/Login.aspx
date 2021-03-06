﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="kinguin_Clone.Login" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ MasterType virtualpath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="display: flex; justify-content: center; align-items: center; margin-top: 20%; margin-bottom: 20%;">
        <asp:Login ID="LoginForm" runat="server" OnAuthenticate="LoginForm_OnAuthenticate"></asp:Login>
    </div>
    <asp:HyperLink ID="hlRegister" runat="server" href="/Register.aspx">Don't have a account yet ? click here.</asp:HyperLink>
</asp:Content>