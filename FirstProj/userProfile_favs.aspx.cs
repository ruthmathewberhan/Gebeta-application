using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FirstProj
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        List<int> recipeIDs = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usertype"] != null)
                {
                    if (Session["usertype"].Equals("user"))
                    {
                        add_recipe.Visible = false;
                    }

                    else if (Session["usertype"].Equals("chef"))
                    {
                        add_recipe.Visible = true;
                        all_recipes.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {

            }



            if ( Session["usertype"] != null && Session["usertype"].Equals("user") && Request.QueryString["id"] != "")
            {
             
                int recipeID = Convert.ToInt32(Request.QueryString["id"]);
                Response.Write(recipeID);

                try
                {

                    int userIdInt = Convert.ToInt32(Convert.ToString(Session["user_id"]));

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO user_collection_table(user_ID,recipe_ID)" +
                        "values(@userID,@recipeID)", con);

                    cmd.Parameters.AddWithValue("@userID", userIdInt);
                    cmd.Parameters.AddWithValue("@recipeID", recipeID);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("success");
                }
                catch (Exception ex)
                {
                    //Response.Write(ex.Message);
                }
            }

            /* try
             {

                 if (Session["usertype"] != null)
                 {s
                     if (Session["usertype"].ToString() == "chef")
                     {
                         all_recipes.Visible = false;
                     }
                 }
             }
             catch(Exception ex)
             {

                 Response.Write("invalid");
             } */


        }

        protected void FavoritesButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile_favs.aspx");
        }
        
        protected void AllRecipe_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile_all.aspx");
        }

        protected void add_recipe_Click(object sender, EventArgs e)
        {
            Response.Redirect("chefRecipe.aspx");
        }

        public string getCollection()
        {
            if (Session["usertype"] != null)
            {
                if (Session["usertype"].Equals("user"))
                {
                    return getUserCollection();
                }

                else 
                {
                    return getChefCollection();
                }
            }
            return "";
        }

        public string getUserCollection()
        {
            string htmlStr = "";

            try
            {
                int userIdInt = Convert.ToInt32(Convert.ToString(Session["user_id"]));
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM user_collection_table WHERE user_ID='" + userIdInt + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int recipeIdInt = Convert.ToInt32(dr.GetValue(2).ToString());
                        recipeIDs.Add(recipeIdInt);
                    }
                }
                /*foreach(int i in recipeIDs)
                {
                    Response.Write(i);
                }*/
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                foreach (int i in recipeIDs)
                {
                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM recipe_table_temp WHERE recipe_ID = '" + i + "'", con);
                    SqlDataReader dr2 = cmd2.ExecuteReader();

                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            string title = dr2.GetValue(1).ToString();
                            string img_link = dr2.GetValue(5).ToString();
                            string link = img_link.Substring(1);

                            htmlStr += $"<div class=' col-5 mar-l'>" +
                                $"<h2> {title}</h2>" +
                                $"<img src='{link}' class='myFavImg'>" +
                                $"<a href='recipe.aspx' class='btn btn-primary' id='btn'>Get This Recipe</a>" +
                                $"</div>";

                        }
                    }
                }

            }

            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }



            return htmlStr;
        }

        public string getChefCollection()
        {
            string htmlStr = "";

            try
            {
                int userIdInt = Convert.ToInt32(Convert.ToString(Session["user_id"]));
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Recipe_table_temp WHERE chef_id='" + userIdInt + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr.GetValue(0).ToString());
                        string title = dr.GetValue(1).ToString();
                        string img_link = dr.GetValue(5).ToString();
                        string link = img_link.Substring(1);

                        htmlStr += $"<div class=' col-5 mar-l'>" +
                            $"<h2> {title}</h2>" +
                            $"<img src='{link}' class='myFavImg'>" +
                            $"<button class='btn btn-primary' id='btn' runat='server' onclick='fun({id})'>Get This Recipe</button>" +
                            $"</div>";
                    }
                }
                /*foreach(int i in recipeIDs)
                {
                    Response.Write(i);
                }*/
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            
            return htmlStr;
        }
    }
}