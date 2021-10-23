<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="FirstProj.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./assets/css/signInUp.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mycontainer">
        <div class="center">
            <div class="login-box">
                <h1>Sign Up </h1>
                <div>


                    <form method="POST" action="/register">
                        <div class="text-box">
                            <p id="successID" runat="server" visible="false" style="color:green;">Sign up Successful. Go to user Login to Login</p>
                            <p id="ExistedID" runat="server" visible="false" >Member Already Exist with this username, try another username</p>
                            <p id="emptyID" runat="server" visible="false" >every boxes should be filled!!</p>

                            <i class="fas fa-user"></i>
                            <asp:TextBox ID="TextBoxFName" placeholder="Full Name" runat="server"></asp:TextBox>
                        </div>

                        <div class="text-box">
                            <i class="fas fa-user"></i>
                            <asp:TextBox ID="TextBoxUName" placeholder="User Name" runat="server"></asp:TextBox>
                        </div>
                        <div class="text-box">
                            <i class="fas fa-envelope"></i>
                            <asp:TextBox ID="TextBoxEmail" placeholder="Email" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group text-box">
                            <i class="fas fa-user-lock"></i>
                            <input id="new-id" />
                            <asp:TextBox ID="TextBoxPass" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group text-box">
                            <i class="fas fa-user"></i>
                            <asp:DropDownList CssClass="text-box" ID="DropDownListUType" runat="server">
                                <asp:ListItem Text="User Type" Value="select" />
                                <asp:ListItem Text="Chef" Value="chef" />
                                <asp:ListItem Text="User" Value="user" />
                            </asp:DropDownList>
                        </div>

                        <asp:Button ID="Button1" class="btn" runat="server" Text="Register" OnClick="Button1_Click" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
