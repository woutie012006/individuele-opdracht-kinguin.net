<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeUserInfo.aspx.cs" Inherits="kinguin_Clone.ChangeUserInfo" %>
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

        <asp:Label runat="server" Text="NickName"></asp:Label><br>
        <asp:TextBox ID="tbNickname" runat="server" CssClass="form-control"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbNickname" runat="server" ErrorMessage="NickName is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>
        
          <asp:Label id="lblSellerName" Visible="False" runat="server" Text="SellerName"></asp:Label><br>
        <asp:TextBox ID="tbSellerName" runat="server" CssClass="form-control" Visible="False"></asp:TextBox><br>
        <asp:RequiredFieldValidator ID="tbSellerNameVal" ControlToValidate="tbSellerName" runat="server" ErrorMessage="SellerName is empty" CssClass="alert alert-dismissible alert-danger" Enabled="False"></asp:RequiredFieldValidator><br>
        
           <asp:Label ID="lblBankAccount" Visible="False" runat="server" Text="BankAccount"></asp:Label><br>
        <asp:TextBox ID="tbBankAccount" runat="server" CssClass="form-control" Visible="False"></asp:TextBox><br>
        <asp:RequiredFieldValidator ID="tbBankAccountVal" ControlToValidate="tbBankAccount" runat="server" ErrorMessage="SellerName is empty" CssClass="alert alert-dismissible alert-danger" Enabled="False"></asp:RequiredFieldValidator><br>
        

        <br>
        <br>

        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-default" OnClick="btnSubmit_OnClick"/>

    </form>


</asp:Content>