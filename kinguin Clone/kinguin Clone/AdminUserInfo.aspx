<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUserInfo.aspx.cs" Inherits="kinguin_Clone.AdminUserInfo" %>
<%@ MasterType virtualpath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    
     <div id="tableDiv" style="display: flex; justify-content: center; align-items: center; margin-top: 20%; margin-bottom: 20%;">
        <table class="table table-bordered table-striped">

            <thead>
            <tr>
                <th>UserNr</th>
                <th>Email</th>
                <th>Name</th>
                <th>Adres</th>
                <th>Kinguin Balance</th>

            </tr>
            </thead>

            <tbody>
            <asp:ListView ID="UserView" OnItemDataBound="UserView_OnItemDataBound" runat="server">
                <ItemTemplate>
                    <tr>
                         <td><%#
                this.Eval("UserNr") %></td>
                         <td><%#
                this.Eval("Email") %></td>
                        <td><%#
                this.Eval("Name") %></td>
                        <td><%#
                this.Eval("Adres") %></td>
                        <td><%#
                this.Eval("KinguinBalance") %></td>

                    </tr>
                </ItemTemplate>
            </asp:ListView>
            </tbody>
        </table>

    </div>
</asp:Content>
