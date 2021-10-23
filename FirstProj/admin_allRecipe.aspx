<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="admin_allRecipe.aspx.cs" Inherits="FirstProj.WebForm11" %>
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
    <h1> All Recepies</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="content">
            <div class="row">
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GebetaRecipesDBConnectionString %>" SelectCommand="SELECT [Recipe_ID], [Recipe_Title], [Description], [Serving_Quantity], [total_time] FROM [Recipe_table]"></asp:SqlDataSource>
                <div class="col">
                    <asp:GridView CssClass="" class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Recipe_ID" DataSourceID="SqlDataSource2">
                        <Columns>
                            <asp:BoundField DataField="Recipe_ID" HeaderText="Recipe_ID" InsertVisible="False" ReadOnly="True" SortExpression="Recipe_ID" />
                            <asp:BoundField DataField="Recipe_Title" HeaderText="Recipe_Title" SortExpression="Recipe_Title" />
                            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                            <asp:BoundField DataField="Serving_Quantity" HeaderText="Serving_Quantity" SortExpression="Serving_Quantity" />
                            <asp:BoundField DataField="total_time" HeaderText="total_time" SortExpression="total_time" />
                        </Columns>
                        
                    </asp:GridView>
                </div>
            </div>
        <div class="row rowspace">
                <div class="col clo">
                    <span class="btn"><a href="admin_update.aspx"> Go To recipie </a></span>
                    
                </div>
            </div>
    </div>

</asp:Content>
