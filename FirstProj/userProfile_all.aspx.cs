using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstProj
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        List<int> IDS = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            int user_id;

            if (Session["user_id"] != null)
            {
               user_id = Convert.ToInt32(Session["user_id"].ToString());
            }
            else
            {
                user_id = 0;
            }

            
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


        public string getAllRecipes()
        {
            string htmlStr = "";


            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //Session["id"] = 1;
                    SqlCommand cmd2 = new SqlCommand("SELECT * from recipe_table_temp", con);

                    SqlDataReader dr2 = cmd2.ExecuteReader();


                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            int id = Convert.ToInt32(dr2.GetValue(0).ToString());
                            string title = dr2.GetValue(1).ToString();
                            string img_link = dr2.GetValue(5).ToString();
                            string link = img_link.Substring(1);

                            //Response.Write(source);
                            htmlStr += $"<div class = 'col-4'>" +
                                $"<div class='card new' style='width: 100%;'>" +
                                $"<img src='{link}' style='height: 150px;' alt='...'>" +
                                $"<a class='title-link' href='recipe.aspx'>{title}</a>" +
                                $"<button class='btn' onclick='fun2({id})'>Add to Collection</button>" +
                                $"</div>" +
                                $"</div>";
                        }
                    }
                

                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }


            return htmlStr;
        }

        
    }
}