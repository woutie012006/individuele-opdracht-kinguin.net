<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BecomeSeller.aspx.cs" Inherits="kinguin_Clone.BecomeSeller" %>
<%@ MasterType virtualpath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    
    
        <asp:Label runat="server" Text="Seller name" CssClass="col-lg-2 control-label"></asp:Label><br>
        <asp:TextBox ID="tbSellername" runat="server" CssClass="form-control"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbSellername" runat="server" ErrorMessage="Sellername is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="Bank account"></asp:Label><br>
        <asp:TextBox ID="tbBankaccount" runat="server" CssClass="form-control"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbBankaccount" runat="server" ErrorMessage="Banaccount is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>
    <br>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_OnClick" />


</asp:Content>
