<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="FirstProj.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./assets/css/adminLogin.css">
    <title>Admin Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mycontainer">
    <div class="center">
      <div class="login-box">
        <h6>ADMIN SIGN IN</h6>
          <div>
            <div class = "text-box">
                <p class="invalid" id="invalid_cred" runat="server" visible="false">Invalid Credentials!</p>
              <i class="fas fa-user"></i>
                <asp:TextBox ID="TextBoxUName" placeholder="Username" runat="server"></asp:TextBox>
            </div>
            <div class="form-group text-box">
              <i class="fas fa-user-lock"></i>
                <asp:TextBox ID="TextBoxPass" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <asp:Button ID="loginAdmin"  class="btn" runat="server" Text="Login" OnClick="loginAdmin_Click" />
          </div>
      </div>
    </div>
  </div>
</asp:Content>
