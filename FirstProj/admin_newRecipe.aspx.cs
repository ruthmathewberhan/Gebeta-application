using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstProj
{
    public partial class WebForm10 : System.Web.UI.Page
    {

        public int recipe_id;


        // start a connection string b/n the database and ui
        string ConnectionStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        // id of the ingredinet
        int Ing_Id;
        // name of the ingredinet
        string Ing_Name;

        string quantity;
        string unit;
        string select;
        string stepNum;
        string steps;
        string dish;
        string meal;
        string season;
        string serving;
        string time;
        string title;
        string desc;
        string image;
        string video;
        int chief;

        // list if strings
        List<string> ingNameList = new List<string>();
        List<int> ingIdList = new List<int>();
        List<string> QuantityList = new List<string>();
        List<string> uniList = new List<string>();
        List<string> stepNumList = new List<string>();
        List<string> stepsList = new List<string>();




        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // on display

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                recipe_id = Convert.ToInt32(id.Value);


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }



        }


        // method to display the detailed information for a specfic recpie
        public string DisplayRecpieTitle()
        {
            string htmlStr = "";

            try
            {
                // connect to the sql using the connection string
                SqlConnection Con = new SqlConnection(ConnectionStr);

                // check wetheer the sql connection is open or closed 
                // if true open it
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                // the comand for selecting the information for specfic recpie id
                SqlCommand command = new SqlCommand("SELECT * from recipe_table_temp where recipe_ID ='" + recipe_id + "'", Con);
                // the data reader
                SqlDataReader dataReader = command.ExecuteReader();

                /// check if there is a recpie for the given repie id
                if (dataReader.HasRows)
                {
                    // if true while the reader is reading the data
                    while (dataReader.Read())
                    {
                        // save the recpie information for display
                        string recpieTitle = dataReader.GetString(1);
                        title = recpieTitle;
                        string recpieDescription = dataReader.GetValue(2).ToString();
                        desc = recpieDescription;
                        string recpieServing = dataReader.GetValue(3).ToString();
                        serving = recpieServing;
                        string recpieTime = dataReader.GetValue(4).ToString();
                        time = recpieTime;
                        string recpieImg_link = dataReader.GetValue(5).ToString();
                        image = recpieImg_link;
                        string link = recpieImg_link.Substring(1);
                        chief = Int32.Parse(dataReader.GetValue(6).ToString());
                        video = dataReader.GetValue(7).ToString();

//Response.Write(source);
                        htmlStr += $"" +
                            $"<div class='content border'>" +
                            $"<div class='row rowspace'>" +
                            $"<label class='label'> Recpie Title: </label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                            $"<label class='display'>{recpieTitle}</label>" +
                            $"</div>" +
                            $"<div class='row rowspace'>" +
                            $"<label class='label'> Recpie Description: </label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                            $"</div>" +
                            $"<div class='row rowspace'>" +
                            $"<div class='card'>" +
                            $"<div class='card-body'>" +
                            $"<p class='display'>{recpieDescription}</p>" +
                            $"</div>" +
                            $"</div>" +
                            $"</div>" +
                            $"<div class='row rowspace'>" +
                            $"<div class='col-sm'>" +
                            $"<div class='row'>" +
                            $"<label class='label'> Serving Quantity:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                            $"<label class='display'>{recpieServing}</label>" +
                            $"</div>" +
                            $"<div class='row'>" +
                            $"<label class=;label'> Total Cooking Tme: </label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                            $"<label class='display'> {recpieTime}</label>" +
                            $"</div>" +
                            $"</div>" +
                            $"<div class='col-sm'>" +
                            $"<div class='card'>" +
                            $"<div class='card-body'>" +
                            $"<img class='card-img-top' src='{link}' alt='Card image cap'>" +
                            $"</div>" +
                            $"</div>" +
                            $"</div>" +
                            $"</div>" +
                            $"<hr>" +
                            $"<div class='row rowspace'>" +
                            $"<h2> Ingriedents</h2>" +
                            $"</div>" +
                            $"<div class='row'>" +
                            $"<div class='col-sm border'>" +
                            $"<label class='label'> Ingriedents </label>" +
                            $"</div>" +
                            $"<div class='col-sm border'>" +
                            $"<label class='label'> Quantity </label>" +
                            $"</div>" +
                            $"<div class='col-sm border'>" +
                            $"<label class='label'> Unit </label>" +
                            $"</div>" +
                            $"</div>" +
                            $""
                            ;

                    }
                }

                Con.Close();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }

            return htmlStr;
        }

        // display the recpie ingredients information
        public string DisplayIngedients()
        {
            string htmlStr = "";

            try
            {

                // connect to the sql using the connection string
                SqlConnection Con2 = new SqlConnection(ConnectionStr);

                // check wetheer the sql connection is open or closed 
                // if true open it
                if (Con2.State == ConnectionState.Closed)
                {
                    Con2.Open();
                }

         
// the comand for selecting the information for specfic recpie id
                SqlCommand command1 = new SqlCommand("SELECT * from recipe_ingred_temp where recipe_ID ='" + recipe_id + "'", Con2);

                // the data reader
                SqlDataReader dataReader1 = command1.ExecuteReader();

                // ask if iteration is needed?////

                /// check if there is a recpie for the given repie id
                if (dataReader1.HasRows)
                {
                    // if true while the reader is reading the data
                    while (dataReader1.Read())
                    {
                        string ing_Id = dataReader1.GetValue(2).ToString();
                        Ing_Id = Int32.Parse(ing_Id);
                        ingIdList.Add(Ing_Id);
                        string ing_Quantity = dataReader1.GetValue(3).ToString();
                        quantity = ing_Quantity;
                        QuantityList.Add(quantity);
                        string ing_Unit = dataReader1.GetValue(4).ToString();
                        unit = ing_Unit;
                        uniList.Add(unit);

                        // the comand for selecting the information for specfic recpie id
                        SqlCommand command2 = new SqlCommand("SELECT * from ingredient_table_temp where ingredient_ID ='" + Ing_Id + "'", Con2);

                        // the data reader
                        SqlDataReader dataReader2 = command2.ExecuteReader();

                        while (dataReader2.Read())
                        {
                            string ing_Name = dataReader2.GetValue(1).ToString();
                            Ing_Name = ing_Name;
                            ingNameList.Add(Ing_Name);
                        }

                        //Response.Write(source);
                        htmlStr += $"<div class='row'>" +
                            $"<div class='col-sm border'>" +
                            $"<label class='display'>{Ing_Name}</label>" +
                            $"</div>" +
                            $"<div class='col-sm border'>" +
                            $"<label class='display'>{ing_Quantity}</label>" +
                            $"</div>" +
                            $"<div class='col-sm border'>" +
                            $"<label class='display'>{ing_Unit}</label>" +
                            $"</div>" +
                            $"</div>" +
                            $""
                            ;

                    }

                    Con2.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }


            return htmlStr;
        }

        // display the html in the middle
        public string DisplayMiddleHtml()
        {
            string htmlStr = "";

            if (id.Value != "")
            {
                htmlStr += $"<hr>" +
                                $"<div class='row rowspace'>" +
                                $"<h2> Preparation Step</h2>" +
                                $"</div>" +
                                $"<div class='row'>" +
                                $"<div class='col-sm-2 border'>" +
                                $"<label class='label'> Steps </label>" +
                                $"</div>" +
                                $"<div class='col-sm-10 border'>" +
                                $"<label class='label'> Preparation Method </label>" +
                                $"</div>" +
                                $"</div>" +
                                $"";


            }
            return htmlStr;

        }


        // display the recepie step information
        public string DisplayStep()
        {
            string htmlStr = "";

            try
            {

// connect to the sql using the connection string
                SqlConnection Con3 = new SqlConnection(ConnectionStr);

                // check wetheer the sql connection is open or closed 
                // if true open it
                if (Con3.State == ConnectionState.Closed)
                {
                    Con3.Open();
                }

                // the comand for selecting the information for specfic recpie id
                SqlCommand command3 = new SqlCommand("SELECT * from recipestep_tbl_temp where recipe_ID ='" + recipe_id + "'", Con3);

                // the data reader
                SqlDataReader dataReader3 = command3.ExecuteReader();

                if (dataReader3.HasRows)
                {
                    while (dataReader3.Read())
                    {
                        string step_Number = dataReader3.GetValue(2).ToString();
                        stepNum = step_Number;
                        stepNumList.Add(stepNum);
                        string step_Instruction = dataReader3.GetValue(3).ToString();
                        steps = step_Instruction;
                        stepsList.Add(steps);

                        htmlStr += $"<div class='row'>" +
                            $"<div class='col-sm-2 border'>" +
                            $"<label class='display'>{step_Number}</label>" +
                            $"</div>" +
                            $"<div class='col-sm-10 border'>" +
                            $"<label class='display'>{step_Instruction}</label>" +
                            $"</div>" +
                            $"</div>" +
                            $"" +
                            $"";

                    }

                }

                Con3.Close();

            }

            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + " ');</script>");

            }

            return htmlStr;
        }

        //// display the recepie detail information
        public string DisplayDetails()
        {
            string htmlStr = "";

            try
            {

                // connect to the sql using the connection string
                SqlConnection Con4 = new SqlConnection(ConnectionStr);

                // check wetheer the sql connection is open or closed 
                // if true open it
                if (Con4.State == ConnectionState.Closed)
                {
                    Con4.Open();
                }

                // the comand for selecting the information for specfic recpie id
                SqlCommand command4 = new SqlCommand("SELECT * from recipe_detail_temp where recipe_ID ='" + recipe_id + "'", Con4);

                // the data reader
                SqlDataReader dataReader4 = command4.ExecuteReader();

                if (dataReader4.HasRows)
                {

                    while (dataReader4.Read())
                    {

                        string detail_dishType = dataReader4.GetValue(2).ToString();
                        dish = detail_dishType;
                        string detail_MealCourse = dataReader4.GetValue(3).ToString();
                        meal = detail_MealCourse;
                        string detail_Season = dataReader4.GetValue(4).ToString();
                        season = detail_Season;

htmlStr += $"<hr>" +
                            $"<div class='row rowspace'>" +
                            $"<h2> Recpie Detail</h2>" +
                            $"</div>" +
                            $"<div class='row rowspace'>" +
                            $"<div class='col-sm-6'>" +
                            $"<div class='row rowspace'>" +
                            $"<label class='label'> Type of dish: </label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                            $"<label class='display'>{detail_dishType}</label>" +
                            $"</div>" +
                            $"<div class='row rowspace'>" +
                            $"<label class='label'> Couese meal: </label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                            $"<label class='display'>{detail_MealCourse}</label>" +
                            $"</div>" +
                            $"</div>" +
                            $"<div class='col-sm-6'>" +
                            $"<div class='row rowspace'>" +
                            $"<label class='label'> Season: </label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                            $"<label class='display'> {detail_Season}</label>" +
                            $"</div>" +
                            $"</div>" +
                            $"</div>" +
                            $"" +
                            $"";

                    }



                }

                Con4.Close();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }

            return htmlStr;
        }

        public string DisplayLastHtml()
        {
            string htmlStr = "";

            if (id.Value != "")
            {
                htmlStr += $"<hr>" +
                $"<div class='row rowspace'>" +
                $"<div class='col-sm-3 clo'>" +
                $"<button class='btn'> Accept </button>" +
                $"</div>" +
                $"<div class='col-sm-3 clo'>" +
                $"<button class='btn'> Deny</button>" +
                $"</div>" +
                $"</div>" +
                $"</div>" +
                $"</div>" +
                $"";
            }


            return htmlStr;
        }

        public void AddRecipe()
        {
            recipe_id = Convert.ToInt32(id.Value);
            DisplayRecpieTitle();
            //Response.Write(serving);

            try
            {

                SqlConnection con = new SqlConnection(ConnectionStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd1 = new SqlCommand("INSERT INTO dbo.Recipe_table(Recipe_Title,Description,Serving_Quantity,total_time,recipe_img_link,chef_id,video_link) " +
                    "values(@recipe_title,@description,@serving_quantity,@total_time,@recipe_img_link,@chef,@video)", con);


                cmd1.Parameters.AddWithValue("@recipe_title", title);
                Response.Write(title);
                cmd1.Parameters.AddWithValue("@description", desc);
                Response.Write(desc);
                cmd1.Parameters.AddWithValue("@serving_quantity", serving);
                Response.Write(serving);
                cmd1.Parameters.AddWithValue("@total_time", time);
                Response.Write(time);
                cmd1.Parameters.AddWithValue("@recipe_img_link", image);
                Response.Write(image);
                cmd1.Parameters.AddWithValue("@chef", chief);
                Response.Write(chief);
                cmd1.Parameters.AddWithValue("@video", video);
                Response.Write(video);


                cmd1.ExecuteNonQuery();
                Response.Write("a");


                foreach (var item in ingIdList)
                {
                    SqlCommand cmd = new SqlCommand("insert into dbo.Ingredient_table(ingredient_ID) values (@ing_id)", con);

cmd.Parameters.AddWithValue("@ing_id", item);
                    Response.Write(item);
                    cmd.ExecuteNonQuery();


                }

                Response.Write("b");

                foreach (var item in ingNameList)
                {
                    SqlCommand cmd = new SqlCommand("insert into dbo.Ingredient_table(ingredient_Name) values (@ing_name)", con);

                    cmd.Parameters.AddWithValue("@ing_name", item);
                    cmd.ExecuteNonQuery();


                }

                Response.Write("c");

                for (int i = 0; i < ingIdList.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("insert into dbo.recipe_ingredient_table(recipe_ID, ingredient_ID, Quantity, Unit) values (@recipe_ID, @ingredient_id, @quantity, @unit)", con);

                    cmd.Parameters.AddWithValue("@recipe_ID", recipe_id);
                    cmd.Parameters.AddWithValue("@ingredient_id", ingIdList[i]);
                    cmd.Parameters.AddWithValue("@quantity", QuantityList[i]);
                    cmd.Parameters.AddWithValue("@unit", uniList[i]);

                    cmd.ExecuteNonQuery();
                }
                Response.Write("d");

                for (int i = 0; i < stepNumList.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("insert into dbo.recipestep_tbl_temp(recipe_ID, step_number, instruction) values (@recipe_ID, @step_number, @instruction)", con);

                    cmd.Parameters.AddWithValue("@recipe_ID", recipe_id);
                    cmd.Parameters.AddWithValue("@step_number", stepNumList[i]);
                    cmd.Parameters.AddWithValue("@instruction", stepsList[i]);

                    cmd.ExecuteNonQuery();
                }

                Response.Write("e");

                SqlCommand detail = new SqlCommand("INSERT INTO dbo.recipe_detail_table(recipe_ID,dish_type,course_meal,season) " +
                    "values(@recipe_ID,@dish_type,@course_meal,@season)", con);

                detail.Parameters.AddWithValue("@recipe_ID", recipe_id);
                detail.Parameters.AddWithValue("@dish_type", dish);
                detail.Parameters.AddWithValue("@course_meal", meal);
                detail.Parameters.AddWithValue("@season", season);
                detail.ExecuteNonQuery();

                Response.Write("f");

                con.Close();
                Response.Write("deleted and added successfully");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }



        }

        public void Delete()
        {
            recipe_id = Convert.ToInt32(id.Value);

            try
            {

                SqlConnection con = new SqlConnection(ConnectionStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // delete from recpie table
                SqlCommand cmd1 = new SqlCommand("delete from  dbo.Recipe_table where Recipe_ID ='" + recipe_id + "'", con);

                cmd1.ExecuteNonQuery();

                // delete from ingredient table
                SqlCommand cmd2 = new SqlCommand("delete from  dbo.recipe_ingredient_table where recipe_ID ='" + recipe_id + "'", con);

                cmd2.ExecuteNonQuery();

                // delete from preparation step table
                SqlCommand cmd3 = new SqlCommand("delete from  dbo.recipe_step_table where recipe_ID ='" + recipe_id + "'", con);

                cmd3.ExecuteNonQuery();

                // from recpie detail table
                SqlCommand cmd4 = new SqlCommand("delete from  dbo.recipe_detail_table where recipe_ID ='" + recipe_id + "'", con);

                cmd4.ExecuteNonQuery();


                Response.Write("<script>alert(' Recpie Deleted Sucessfully');</script>");


}
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        public void DeleteTemp()
        {
            recipe_id = Convert.ToInt32(id.Value);
            DisplayRecpieTitle();
            try
            {

                SqlConnection con = new SqlConnection(ConnectionStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // delete from recpie table
                SqlCommand cmd1 = new SqlCommand("delete from  dbo.recipe_table_temp where recipe_ID ='" + recipe_id + "'", con);

                cmd1.ExecuteNonQuery();

                // delete from ingredient table
                SqlCommand cmd2 = new SqlCommand("delete from  dbo.recipe_ingred_temp where recipe_ID ='" + recipe_id + "'", con);

                cmd2.ExecuteNonQuery();

                // delete from preparation step table
                SqlCommand cmd3 = new SqlCommand("delete from  dbo.recipestep_tbl_temp where recipe_ID ='" + recipe_id + "'", con);

                cmd3.ExecuteNonQuery();

                // from recpie detail table
                SqlCommand cmd4 = new SqlCommand("delete from  dbo.recipe_detail_temp where recipe_ID ='" + recipe_id + "'", con);

                cmd4.ExecuteNonQuery();


                Response.Write("<script>alert(' Recpie Deleted Sucessfully');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            recipe_id = Convert.ToInt32(id.Value);

            AddRecipe();
            DeleteTemp();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DeleteTemp();
        }


    }
}