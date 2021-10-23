<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="chefRecipe.aspx.cs" Inherits="FirstProj.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/chef.css">
    <title>Chef</title>
    <script type="text/javascript">

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p runat="server" id="show_success" class="success" visible="false">Successfully Added!</p>
    <form method="post">
        
        <fieldset>
            <p runat="server" id="add_success" visible="false" style="color:greenyellow; font-size:25px; text-align:center;">Recipe Added Successfully!</p>
            <div class="container mt-5 text-center">
                <h2 class="title">ADD YOUR RECIPE</h2>
                <div>
                    <div class="form-group" style="text-align: left">
                        <label class="inputs" for="RecipeTitile">Recipe title*</label>
                        <br>
                        <asp:TextBox ID="RecipeTitle" runat="server" placeholder="title" class="form-control inputs"></asp:TextBox>
                    </div>
                    <div class="form-group" style="text-align: left">
                        <label class="inputs" for="RecipeIntro">Description*</label>
                        <br>
                        <textarea class="form-control inputs" name="" id="RecipeIntro" cols="30" rows="4" runat="server"></textarea>

                    </div>
                    <div class="d-flex formBox ">
                        <div class="servings-times quantity inputsHalf" id="servings-times">
                            <label for="servingSize">Serving Quantity</label>
                            <asp:DropDownList CssClass="" ID="servingQuantity" runat="server">
                                <asp:ListItem Text="1" Value="1" />
                                <asp:ListItem Text="2" Value="2" />
                                <asp:ListItem Text="3" Value="3" />
                                <asp:ListItem Text="4" Value="4" />
                                <asp:ListItem Text="5" Value="5" />
                                <asp:ListItem Text="6" Value="6" />
                                <asp:ListItem Text="7" Value="7" />
                                <asp:ListItem Text="8" Value="8" />
                                <asp:ListItem Text="9" Value="9" />
                                <asp:ListItem Text="10" Value="10" />
                                <asp:ListItem Text="11" Value="11" />
                                <asp:ListItem Text="12" Value="12" />
                                <asp:ListItem Text="13" Value="13" />
                                <asp:ListItem Text="14" Value="14" />
                                <asp:ListItem Text="15" Value="15" />
                                <asp:ListItem Text="16" Value="16" />
                                <asp:ListItem Text="17" Value="17" />
                                <asp:ListItem Text="18" Value="18" />
                                <asp:ListItem Text="19" Value="19" />
                                <asp:ListItem Text="20" Value="20" />

                            </asp:DropDownList>
                        </div>
                        <div class="servings-times inputsHalf" id="servings-times4">
                            <label for="totalTime" style="margin-right: 38%;">Total Time</label><br>
                            <span id="totalTimeTip"><span
                                data-reactroot=""><a class="toolTip"></a></span></span>
                            <asp:TextBox ID="totalTime" runat="server" class="inputs" placeholder="hour:minute"></asp:TextBox>

                        </div>
                    </div>
                    <%-- image--%>

            <div class="row">
                    <div class="col">
                        <center>
                            <img class="mt-3" id="imgview" height="150px" width="150px" src="./Uploaded_Imgs/breakfast2.jpg" />
                        </center>
                    </div>
                </div>
            <div class="row">
                    <div class="col">
                        <asp:FileUpload onchange="readURL(this);" CssClass="w-75 ml-5 ml-3 mt-3" ID="FileUpload1" runat="server" />
                    </div>
                </div>

                    <%-- end image--%>

                    <%-- video link--%>
                    <asp:TextBox ID="video_link" runat="server" class=" inputs w-75 ml-0 pl-0 mt-3" placeholder="video link"></asp:TextBox>

                    <%-- ingridient start--%>

                    <hr style="width: 85%; margin-left: 45px;">

                    <h2 style="text-align: left; margin-left: 45px; margin-bottom: 20px;">INGREDIENTS</h2>
                    <div class="form-group" style="text-align: left">
                        <label class="inputs" for="name">Ingredient(s)*</label>
                        <br>
                        <ul class="ml-2" id="dynamic_list" runat="server" clientidmode="Static">
                            <!-- Ingredient list -->
                        </ul>
                        <input type="text" class="form-control inputs" id="ingredient" placeholder="title" value="">
                    </div>
                    <div class="formBox clearfix">
                        <div class="servings-times inputsHalf" id="servings-times5">
                            <label for="ingredientQuantity">Quantity*</label><br>
                            <span><span data-reactroot=""><a
                                class="toolTip"></a></span></span>
                            <input id="quantity" type="text" maxlength="150" value="" placeholder="eg., 2, 1 1/3, .5">
                        </div>
                        <div class="servings-times inputsHalf" id="servings-times2">
                            <label for="servingSizeUnit" style="margin-right: 53%;">Unit</label>
                            <div id="servingSizeUnit">
                                <div data-reactroot="" class="selectStyled">
                                    <select id="unit">
                                        <option value="person">teaspoon</option>
                                        <option value="people">cup</option>
                                        <option value="serving">gram</option>
                                        <option value="servings">kg</option>
                                        <option value="cup">litre</option>
                                        <option value="cups">gallon</option>              
                                        <option value="bags">dozen</option>
                                        <option value="liter">lbs</option>
                                        <option value="liters">tablespoon</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:Button ID="add-btn" Style="margin-top: 3%; width: 25%;" class="btn btn-primary">ADD INGREDIENT</asp:Button>


                    <%-- ingridient end--%>

                    <%-- start preparation --%>


        <hr style="width: 85%; margin-left: 45px;">
                    <h2 style="text-align: left; margin-left: 45px; margin-bottom: 20px;">PREPARATION</h2>
                    <ul id="preparation_list">
                    <!-- Ingredient list -->
                </ul>
                    <div class="form-group" style="text-align: left">
                        <label class="inputs" for="name">Step Number*</label>
                        <div data-reactroot="" class="selectStyled">
                                <input class="ml-5" id="select" placeholder="step number" type="text" maxlength="150" value=""/>
                        </div>
                        <br>
                        <label class="inputs" for="steps">Instruction*</label>
                        <input id="steps" placeholder="step eg., Enter ingredients step…" class="form-control inputs" type="text" maxlength="150" value=""/>

                    </div>
                    <asp:Button id="prep_btn" Style="margin-top: 3%; width: 32%;" class="btn btn-primary">ADD PREPARATION STEP</asp:Button>

                    <%-- end preparation --%>

                    <hr style="width: 85%; margin-left: 45px;">
                    <h2 style="text-align: left; margin-left: 45px; margin-bottom: 20px;">DETAILS</h2>

                    <div class="form-group" style="text-align: left">
                        <label class="inputs" for="name">Type of dish</label>
                        <br>
                        <select id="dish" class="inputs form-control" name="dish">
                            <option value="stew">stew</option>
                            <option value="bread">bread</option>
                            <option value="other">other</option>

                           
                        </select>

                    </div>
                    <div class="form-group" style="text-align: left">
                        <label class="inputs" for="name">Course meal</label>
                        <br>
                        <select id="meal" class="inputs form-control" name="meal">
                            <option value="fast-food">fast food</option>
                            <option value="main-dish">main dish</option>
                            <option value="breakfast">breakfast</option>
                            <option value="breakfast">Alcoholic</option>
                            <option value="breakfast">Non-Alcoholic</option>
                        </select>


                </div>
                    <div class="form-group" style="text-align: left">
                        <label class="inputs" for="name">Season</label>
                        <br>
                        <select id="season" class="inputs form-control" name="season">
                            <option value="fasting">fasting</option>
                            <option value="fasting">non-fasting</option>
                        </select>

                    </div>

                </div>
                <asp:Button ID="Button1" runat="server" Text="Add Recipe" Style="margin-top: 3%; width: 25%;" CssClass="btn btn-primary mb-3" OnClick="AddIngredient" />
            </div>
           
        </fieldset>
    </form>
    <!--container end-->
    <script src="assets/js/chef.js"></script>

</asp:Content>