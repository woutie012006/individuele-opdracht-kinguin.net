<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="kinguin_Clone.Register" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <form class="form-horizontal text-center" >
        <h2>Register</h2>
        <br>

        <asp:Label runat="server" Text="Name" CssClass="col-lg-2 control-label"></asp:Label><br>
        <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbName" runat="server" ErrorMessage="Name is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="Adres"></asp:Label><br>
        <asp:TextBox ID="tbAdres" runat="server" CssClass="form-control" ></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbAdres" runat="server" ErrorMessage="Adres is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="Telephone Number"></asp:Label><br>
        <asp:TextBox ID="tbTelNr" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbTelNr" runat="server" ErrorMessage="Telephone number is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>

        <asp:Label runat="server" Text="E-mail"></asp:Label><br>
        <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox><br>
        <asp:RequiredFieldValidator ControlToValidate="tbEmail" runat="server" ErrorMessage="Email is empty" CssClass="alert alert-dismissible alert-danger"></asp:RequiredFieldValidator><br>
        
         <asp:Label runat="server" Text="Nickname"></asp:Label><br>
        <asp:TextBox ID="tbNickname" runat="server" CssClass="form-control" ></asp:TextBox><br>
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
    <%--   
    <form class="form-horizontal">
  <fieldset>
    <legend>Legend</legend>
    <div class="form-group">
      <label for="inputEmail" class="col-lg-2 control-label">Email</label>
      <div class="col-lg-10">
        <input type="text" class="form-control" id="inputEmail" placeholder="Email">
      </div>
    </div>
    <div class="form-group">
      <label for="inputPassword" class="col-lg-2 control-label">Password</label>
      <div class="col-lg-10">
        <input type="password" class="form-control" id="inputPassword" placeholder="Password">
        <div class="checkbox">
          <label>
            <input type="checkbox"> Checkbox
          </label>
        </div>
      </div>
    </div>
    <div class="form-group">
      <label for="textArea" class="col-lg-2 control-label">Textarea</label>
      <div class="col-lg-10">
        <textarea class="form-control" rows="3" id="textArea"></textarea>
        <span class="help-block">A longer block of help text that breaks onto a new line and may extend beyond one line.</span>
      </div>
    </div>
    <div class="form-group">
      <label class="col-lg-2 control-label">Radios</label>
      <div class="col-lg-10">
        <div class="radio">
          <label>
            <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked="">
            Option one is this
          </label>
        </div>
        <div class="radio">
          <label>
            <input type="radio" name="optionsRadios" id="optionsRadios2" value="option2">
            Option two can be something else
          </label>
        </div>
      </div>
    </div>
    <div class="form-group">
      <label for="select" class="col-lg-2 control-label">Selects</label>
      <div class="col-lg-10">
        <select class="form-control" id="select">
          <option>1</option>
          <option>2</option>
          <option>3</option>
          <option>4</option>
          <option>5</option>
        </select>
        <br>
        <select multiple="" class="form-control">
          <option>1</option>
          <option>2</option>
          <option>3</option>
          <option>4</option>
          <option>5</option>
        </select>
      </div>
    </div>
    <div class="form-group">
      <div class="col-lg-10 col-lg-offset-2">
        <button type="reset" class="btn btn-default">Cancel</button>
        <button type="submit" class="btn btn-primary">Submit</button>
      </div>
    </div>
  </fieldset>
</form>--%>
</asp:Content>
