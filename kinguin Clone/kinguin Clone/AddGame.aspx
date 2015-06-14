<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGame.aspx.cs" Inherits="kinguin_Clone.AddGame" EnableEventValidation="false" %>
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
    <form class="form-horizontal">
        <h2>Add Game</h2>
        <br>

        <asp:Label runat="server" Text="Name" CssClass="col-lg-2 control-label"></asp:Label><br>
        <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbName" runat="server" ErrorMessage="Name was not entered" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="Platform"></asp:Label><br>
        <asp:FileUpload ID="fuPicture" runat="server" CssClass="form-control"/>
        <asp:RequiredFieldValidator ControlToValidate="fuPicture" runat="server" ErrorMessage="No Picture was loaded" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="Description"></asp:Label><br>
        <textarea id="tbDescription" cols="20" rows="5" runat="server" CssClass="form-control"></textarea><br>
        <asp:RequiredFieldValidator ControlToValidate="tbDescription" runat="server" ErrorMessage="Description was not entered" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="Release Date"></asp:Label><br>
        <asp:Calendar ID="clDate" runat="server"></asp:Calendar><br/>
        <br>


        <asp:Label runat="server" Text="Specifications"></asp:Label><br>
        <textarea id="tbSpecifications" cols="20" rows="5" runat="server" CssClass="form-control"></textarea><br>
        <asp:RequiredFieldValidator ControlToValidate="tbSpecifications" runat="server" ErrorMessage="Specifications where not entered" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>


        <asp:Label runat="server" Text="Platform"></asp:Label><br>
        <asp:DropDownList ID="ddPlatform" runat="server" CssClass="form-control"></asp:DropDownList>
        <asp:RequiredFieldValidator ControlToValidate="ddPlatform" runat="server" ErrorMessage="Platform was not chosen" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>


        <asp:Label runat="server" Text="Platform"></asp:Label><br>
        <asp:DropDownList ID="ddCategory" runat="server" CssClass="form-control"></asp:DropDownList>
        <asp:RequiredFieldValidator ControlToValidate="ddCategory" runat="server" ErrorMessage="Category was not chosen" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>
        <br>
        <br>
        <asp:Button ID="btnAddGame" runat="server" Text="Button" OnClick="btnAddGame_OnClick" CssClass="btn btn-default"/>
    </form>
</asp:Content>