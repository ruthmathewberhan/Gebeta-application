<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="admin_newRecipeList.aspx.cs" Inherits="FirstProj.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Bootsrap 4 css -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900" rel="stylesheet">
    
    <link rel="stylesheet" href="assets/css/admin_newRecpie.css">

    <!--  table function -->

    <script type="text/javascript">
        //$(document).ready(function () {
        //   $('#myTable').DataTable();
        //});
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });

    </script>

    



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1> New Recepie List</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
        <div class="content">
            <div class="row">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GebetaRecipesDBConnectionString %>" SelectCommand="SELECT [recipe_ID], [recipe_title], [description], [serving_quantity], [total_time] FROM [recipe_table_temp]"></asp:SqlDataSource>

                <div class="col">
                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="recipe_ID" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="recipe_ID" HeaderText="recipe_ID" InsertVisible="False" ReadOnly="True" SortExpression="recipe_ID" />
                            <asp:BoundField DataField="recipe_title" HeaderText="recipe_title" SortExpression="recipe_title" />
                            <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                            <asp:BoundField DataField="serving_quantity" HeaderText="serving_quantity" SortExpression="serving_quantity" />
                            <asp:BoundField DataField="total_time" HeaderText="total_time" SortExpression="total_time" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            
            <hr>

            <div class="row rowspace">
                <div class="col clo">
                    <span class="btn"><a href="admin_newRecipe.aspx"> Go To recpie </a></span>
                    
                </div>
            </div>
        </div>

    <script type="text/javascript">
        
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });

    </script>
    
</asp:Content>
