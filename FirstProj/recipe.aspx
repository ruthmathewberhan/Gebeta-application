<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="recipe.aspx.cs" Inherits="FirstProj.WebForm2" enableSessionState="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom css -->
    <link rel="stylesheet" href="../assets/css/recipe.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%=get_recipe() %>

        <div class="reviews ps-3 mt-3 pt-3">
            <h3 class="h3">leave a review</h3>
            <div class="bold-hr"></div>
            <div class="review"><textarea class="form-control mt-4" placeholder="Write Your Review" id="review_Textarea" runat="server" height="50px"></textarea></div>

            <form action="/action_page.php">
          <label for="rate">Rating:</label>
          <select id="rate" name="cars" runat="server">
            <option value="1">1/5</option>
            <option value="2">2/5</option>
            <option value="3">3/5</option>
            <option value="4">4/5</option>
              <option value="5">5/5</option>
          </select>
  
</form>
            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Review" OnClick="Button1_Click" />
            <p runat="server" id="review" style="color:red;" visible="false">You have to login to give a review!</p>
            <h3 class="h3 pt-5">reviews</h3>
            <p id="no_rev" style="color:brown;" runat="server">No reviews yet</p>
            <%=getReviews()%>
        </div>
</asp:Content>