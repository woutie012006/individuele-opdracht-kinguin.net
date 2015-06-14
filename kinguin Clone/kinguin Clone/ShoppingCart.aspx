<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Kinguin_Clone.ShoppingCart" %>
<%@ MasterType virtualpath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="tableDiv" style="display: flex; justify-content: center; align-items: center; margin-top: 20%; margin-bottom: 20%;">
        <table class="table table-bordered table-striped">

            <thead>
            <tr>
                <th>Item Name</th>
                <th>Description</th>
                <th>Price</th>
            </tr>
            </thead>

            <tbody>
            <asp:ListView ID="ItemView" OnItemDataBound="ItemView_OnItemDataBoundView_ItemDataBound" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Description") %></td>
                        <td><%# Eval("Price") %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            </tbody>
        </table>

    </div>


</asp:Content>