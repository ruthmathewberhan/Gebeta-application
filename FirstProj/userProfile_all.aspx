<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userProfile_all.aspx.cs" Inherits="FirstProj.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900" rel="stylesheet">	
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="./assets/css/style_user.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div style="position: absolute; top: 10%; height:100vh; margin-right:5%;" class="wrapper d-flex align-items-stretch pr-5">
			<nav  id="sidebar2">
				<div class="p-4 pt-5">
		  		<a href="#" class="img logo rounded-circle mb-5" style="background-image: url(../assets/images/logo.jpg);"></a>
          
	        <ul class="list-unstyled components mb-5">
	          <li class="active">
	            <asp:LinkButton ID="all_recipes" runat="server" OnClick="AllRecipe_Click">All Recipes</asp:LinkButton>
	           
	          </li>
            
	          <li>
                  <asp:LinkButton ID="FavoritesButton" runat="server" OnClick="FavoritesButton_Click">Your Collections</asp:LinkButton>
	        </ul>

	      </div>
    	</nav>
          </div>

        <!-- Page Content  -->
      <div id="content" class="pl-4 p-md-5">

        <asp:LinkButton CssClass="" ID="add_recipe" runat="server" Visible="false" OnClick="add_recipe_Click">Add Recipe</asp:LinkButton>
          <div style="margin-left:22%;" class="container">
              <div class="row">
                   <%=getAllRecipes()%>
              </div>
          </div> 
         
    <script src="./assets/js/all.js"></script>        
</asp:Content>