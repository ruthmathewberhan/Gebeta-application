<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="FirstProj.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/food_description.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="head"> <center> Categories for Ethiopian Food
    </center> 
       </h1> 
      
       <div id="category" class="">
        
        <asp:Button ID="breakfast_button" CssClass="btn btn-info" role="button" runat="server" Text="breakfast" OnClick="breakfast_button_Click" />

        <asp:Button ID="misa_button" CssClass="btn btn-info" role="button" runat="server" Text="main" OnClick="misa_button_Click" />

        <asp:Button ID="fasting_button" CssClass="btn btn-info" role="button" runat="server" Text="fasting" OnClick="fasting_button_Click" />

        <asp:Button ID="non_fasting_button" CssClass="btn btn-info" role="button" runat="server" Text="non-fasting" OnClick="non_fasting_button_Click" />

        <asp:Button ID="fast_button" CssClass="btn btn-info" role="button" runat="server" Text="Fast Food" OnClick="fast_food_button_Click" />

       </div>
        <div class="row new-row" style="margin-left: 25%;">
        <%=getWhileLoopData()%>
        </div>

        <h1 class="search_cat pt-4 ml-5" ID="no_match_cat" runat="server" Visible="False">No Matching Results Found</h1>
    
    <script src="./assets/js/getrecipe.js"></script>
</asp:Content>
