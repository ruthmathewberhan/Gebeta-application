<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="admin_dashboard.aspx.cs" Inherits="FirstProj.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Admin Dashbord</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1> Dashboard</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cardBox">
            <div class="card">
                <div>
                    <div class="numbers"> 1,452</div>
                    <div class="cardName"> Users</div>
                </div>
                <div class="iconBox">
                    <i class="fas fa-users" aria-hidden="true"></i>
                </div>
            </div>
            <div class="card">
                <div>
                    <div class="numbers"> 150</div>
                <div class="cardName"> Chef</div>
                </div>
                <div class="iconBox">
                    <i class="fas fa-utensils" aria-hidden="true"></i>
                </div>
            </div>
            <div class="card">
                <div>
                    <div class="numbers"> 20,000</div>
                <div class="cardName"> Recpies</div>
                </div>
                <div class="iconBox">
                    <i class="fas fa-cookie" aria-hidden="true"></i>
                </div>
            </div>
        </div>

        <div class="details">
            <div class="newRecpies">
                <div class="cardHeader">
                    <h2> New Recipies</h2>
                </div>
                <table>
                    <thead>
                        <tr>
                            <td> Recpie name</td>
                            <td> Recpie Desciption</td>
                            <td>Serving Quantity</td>
                            <td> Total Time</td>
                        </tr>
                    </thead>
                    <tbody>
                        <%=DisplayNewRecipie() %>
                    </tbody>
                </table>

            </div>
        </div>
</asp:Content>
