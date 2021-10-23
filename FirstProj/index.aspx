<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FirstProj.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom css -->
    <link rel="stylesheet" href="./assets/css/home.css">
    <!-- Google Font -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Merriweather&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Rubik:wght@500&family=Source+Serif+Pro:wght@300&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Rubik:wght@400;500&family=Source+Serif+Pro:wght@400&display=swap" rel="stylesheet">
     <title>Home</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

    <div class="">
        <img src="./assets/images/breakfast2.jpg" class="img-fluid r-home" alt="Different Ethiopian Foods">
        <div class="r-centered1"> <p id="new" >  Find a Recipe</p></div>
        
        <div class="r-centered">
            <tr>           
                <td id="policeprofileachievement" colspan="2" align="center">
                    <i class="fas fa-search icon"></i>
                    <asp:TextBox ID="Txtsearch" runat="server" CssClass="search_box"></asp:TextBox>
                    <asp:Button ID="Button1" CssClass="search_btn" runat="server" Text="search" OnClick="Button1_Click" />

                 </td>
            </tr>
           </div>
      
    </div>

        <div class="container">
            <h1 class="search-res pt-4" ID="search_res" runat="server" Visible="False">Search Results</h1>
            <div style="margin-bottom:5%;" class ="row container pt-4">
                <%=search_result()%>
                <h1 class="search_cat pt-4" ID="no_res" runat="server" Visible="False">No Results Found</h1>
            </div>
         </div>


    
    <div class="container-fluid mb-5 pl-5">
        <h1 class="titles ms-5 mt-5">FOODS</h1>
        <div class="row mb-5 pb-3">
            <div class="col-md-3 r-mr">
                <a class="img-links" href="#">
                    <div class="card ms-5 food-imgs">
                        <asp:ImageButton CssClass="card-img-top r-card-img" ID="fasting" runat="Server" ImageUrl="~/assets/images/vegan2.jpg" OnClick="fastingClick"></asp:ImageButton>
                        <p class="img-text veg ms-0">Fasting Foods</p>
                    </div> 
                    
                </a>
                
            </div>

            <div class="col-md-3 r-mr">
                <a href="#">
                    <div class="card ms-5 food-imgs">
                        <asp:ImageButton CssClass="card-img-top r-card-img" ID="img_non_fast" runat="Server" ImageUrl="~/assets/images/kitfo.jpg" OnClick="nonfastClick"></asp:ImageButton>
                        <p class="img-text non-veg ms-0">Non-Fasting Foods</p>
                    </div>
                    
                      
                </a>
            </div>

            <div class="col-md-3">
                <a href="#">
                    <div class="card ms-5 food-imgs">
                        <asp:ImageButton CssClass="card-img-top r-card-img" ID="img_breakfast" runat="Server" ImageUrl="~/assets/images/breakfast2.jpg" OnClick="breakfastClick"></asp:ImageButton>
                        <p class="img-text ms-0 b-fast">Breakfast</p>
                    </div>
                      
                </a>   
            </div>
        </div>

        <div class="row">

            <div class="col-md-3 r-mr">
                <a href="#">
                    <div class="card ms-5 food-imgs">
                        <asp:ImageButton CssClass="card-img-top r-card-img" ID="fast_img" runat="Server" ImageUrl="~/assets/images/fast-food.jpg" OnClick="fastClick"></asp:ImageButton>
                        <p class="img-text f-food ms-0">Fast-Food</p> 
                    </div>
                       
                </a> 
            </div>

            <div class="col-md-3">
                <a href="#">
                    <div class="card ms-5 food-imgs">
                        <asp:ImageButton CssClass="card-img-top r-card-img" ID="main" runat="Server" ImageUrl="~/assets/images/home-1.jpg" OnClick="mainClick"></asp:ImageButton>
                        <p class="img-text f-food ms-0">Main Dishes</p> 
                    </div>
                       
                </a> 
            </div>
        </div>

        <h1 class="titles mr-5 mt-5 ">DRINKS</h1>
        <div class="row">

            <div class="col-md-3 r-mr">
                <a href="#">
                    <div class="card ms-5 food-imgs">
                        <asp:ImageButton CssClass="card-img-top r-card-img" ID="alc" runat="Server" ImageUrl="~/assets/images/alc.jpg" OnClick="alcClick"></asp:ImageButton>
                        <p class="img-text alcoholic ms-0">Alcoholic</p>
                    </div>
                    
                </a> 
            </div>

            <div class="col-md-3">
                <a href="#">
                    <div class="card ms-5 food-imgs">
                        <asp:ImageButton CssClass="card-img-top r-card-img" ID="non_alc" runat="Server" ImageUrl="~/assets/images/cofee-3.jpg" OnClick="nonClick"></asp:ImageButton>
                        <p class="img-text n-alcoholic ms-0">Non-Alcholic</p>
                    </div>
                    
                </a>  
            </div>
        </div>
        
    </div>


    </div>
    
    <script src="./assets/js/getrecipe.js"></script>
</asp:Content>