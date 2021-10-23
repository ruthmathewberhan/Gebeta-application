<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="True" CodeBehind="admin_newRecipe.aspx.cs" Inherits="FirstProj.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Bootsrap 4 css -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900" rel="stylesheet">

    <link rel="stylesheet" href="assets/css/admin_newRecpie.css">
    <title> Admin new Recpie</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1> New Recepie</h1>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">
        <div class="row">
            <div class="col-sm-3">
                <form>
                    <div class="form-group">
                        <label for="inputId">Recpie Id:</label>
                        <input type="text" class="form-control input" id="id"  placeholder="Id" runat="server">
                    </div>
                </form>
            </div>
        </div>
        <div class="row rowspace">
            <div class="col-sm clo">
                <asp:Button ID="Button1" runat="server" Text="display" OnClick="Button1_Click"  CssClass="btn"/>
            </div>
        </div>
    </div>

        <%=DisplayRecpieTitle() %>
        <%=DisplayIngedients() %>
        <%=DisplayMiddleHtml() %>
        <%=DisplayStep() %>
        <%=DisplayDetails()%>


            
        <div class="row rowspace">
            <div class="col-sm-3 clo">
                <asp:Button CssClass="btn" ID="Button2" runat="server" Text="Accept" OnClick="Button2_Click" />
            </div>
            <div class="col-sm-3 clo">
                <asp:Button CssClass="btn" ID="Button3" runat="server" Text="Denay" OnClick="Button3_Click" />
            </div>
        </div>
              

                

    <script src="assets/js/chef.js"></script>

</asp:Content>
