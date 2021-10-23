<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="admin_update.aspx.cs" Inherits="FirstProj.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <!-- Bootsrap 4 css -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900" rel="stylesheet">

    <link rel="stylesheet" href="assets/css/admin_newRecpie.css">
    <title> Recpie</title>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <h1> Update Recepie</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <!-- display recepie title -->
            
                <div class="content border">

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
                    
                        <form>
                            <div class="form-group">
                                <label for="inputTitle">Recpie Title:</label>
                                <input type="text" class="form-control input" ID="title"  placeholder="title" runat="server">
                                
                              </div>
                        </form>
                    
                    
                          <form>
                            <div class="form-group">
                                <label for="inputDescription">Recepie Description:</label>
                                <textarea type="text" class="form-control input" id="description"  placeholder="Description" rows="3" runat="server">
                                </textarea>
                              </div>
                        </form>
                    
                    
                            <form>
                                <div class="form-group">
                                    <label for="inputQuantity">Serving Quantity:</label>
                                    <input type="text" class="form-control input" id="quantity"  placeholder="serving quantnty" runat="server">
                                    
                                  </div>
                            </form>
                    
                    
                            <form>
                                <div class="form-group">
                                    <label for="inputTime">Total cooking time:</label>
                                    <input type="text" class="form-control input" id="time"  placeholder="total cooking time" runat="server">
                                    
                                  </div>
                            </form>
                    
                    
                            <form>
                                <div class="form-group">
                                    <label for="inputUrl">Image URL:</label>
                                    <input type="text" class="form-control input" id="imageUrl"  placeholder="image url" runat="server">
                                    
                                  </div>
                            </form>
                    
                    <hr>
                       
                    <!-- display recpie detail -->
                    <div class="row rowspace">
                        <h2> Recpie Detail</h2>    
                    </div>

                    <div class="form-group">
                        <label for="selectDish" runat="server"> Type of Dish</label>
                        <select class="form-control" id="dish">
                          <option value="stew">stew</option>
                          <option value="bread">bread</option>
                          <option value="other">other</option>
                        </select>
                      </div>

                      <div class="form-group">
                        <label for="selectMeal" runat="server">Course Meal</label>
                        <select class="form-control" id="meal" runat="server">
                          <option value="fast-food">fast-food</option>
                          <option value="main-dish">main dish</option>
                          <option value="breakfast">breakfast</option>
                        </select>
                      </div>

                      <div class="form-group">
                        <label for="selectSeason" runat="server">Season</label>
                        <select class="form-control" id="season">
                          <option value="fasting"> fasting </option>
                          <option value="non-fasting"> non-fasting</option>
                        </select>
                      </div>
                    <hr>

                    <div class="row rowspace">
                        <div class="col-sm clo">
                            <asp:Button CssClass="btn" ID="button1" runat="server" Text="Update" OnClick="button1_Click" />
                            
                        </div>
                        <div class="col-sm clo">

                           <asp:Button CssClass="btn" ID="button3" runat="server" Text="Delete" OnClick="button3_Click"  />
                        </div>
                    </div>
                    
                </div>    



</asp:Content>
