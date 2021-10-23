<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="categoryDrinks.aspx.cs" Inherits="FirstProj.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/food_description.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="head"> <center> Best Ethiopian Alcholic and Non-Alchlic drinks Recipes 
    </center> 
       </h1> 
      <center><p >These recipes far surpass your basic grilled and yaltetebse meat</p>
      </center> 

       <div id="category" class="">
        
       

        <asp:Button ID="alcholic_drink_button" CssClass="btn btn-info" role="button" runat="server" Text="alcoholic" OnClick="alcholic_drink_button_Click" />

        <asp:Button ID="non_alcholic_drink_button" CssClass="btn btn-info" role="button" runat="server" Text="non-alcoholic" OnClick="non_alcholic_drink_button_Click" />

       </div>
    

    <div class="container">

        <%=getWhileLoopData()%>

        <h1 class="search_cat pt-4" ID="no_match_cat" runat="server" Visible="False">No Matching Results Found</h1>

      <!-- <div class="row new-row">
         
            <div class="bb col-xs-12 col-md-8">
                <div class="card new" style="width: 650px">
                <img src="./assets/images/kitfo.PNG" class="card-img-top" alt="...">
                <div class="card-body">
                    <p>photo by mekdi,</p>
                  <h5 class="card-title">Card title</h5>
                  <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.
                      Lorem ipsum dolor sit amet consectetur adipisicing elit. Aliquam assumenda voluptate recusandae. Recusandae sapiente ducimus atque cumque, eum maiores corporis tempora repellat ad consectetur reiciendis quia quisquam alias temporibus doloremque?
                      Lorem, ipsum dolor sit amet consectetur adipisicing elit. Quod cum provident, dolore error tempora perferendis deserunt nemo eos amet explicabo unde facilis cupiditate laborum nobis porro quisquam placeat fugit enim.
                  </p>
                  <a href="recipe.aspx" class="btn btn-primary" id="btn">Get This Recipe</a>
                </div>
              </div></div>
            <div class=" col-xs-6 col-md-4 ">
                <div class="row  average">
                    <p>Average Reaview</p> <br>
                    <p>4/6</p> 
                </div>
                <div class="row  average1">
                    <p>Good</p> 
                     <p> Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla sequi explicabo aliquam esse temporibus quae aliquid possimus? Odio ratione sed excepturi earum, dolor voluptatem libero quis soluta quasi, a consequuntur.</p>
                </div>
                <div class="row  average1">
                    <p>veryGood</p> 
                     <p> Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla sequi explicabo aliquam esse temporibus quae aliquid possimus? Odio ratione sed excepturi earum, dolor voluptatem libero quis soluta quasi, a consequuntur.</p>
                </div></div>
            </div>-->
    
    </div>
</asp:Content>